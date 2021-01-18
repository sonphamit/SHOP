using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infrastructure.Extentions
{
    public static class PagingExtension
    {

        public static async Task<Pagination<TModel>> ToPagingAsync<TEntity, TModel>(this IQueryable<TEntity> source,
            IMapper mapper
            , int? index = null
            , int? size = null
            , int from = 0)
        {
            if (index.HasValue && from > index.Value) throw new ArgumentException($"From: {from} > Index: {index.Value}, must From <= Index");

            var count = await source.CountAsync();

            if (index.HasValue && size.HasValue)
            {
                index -= 1;
                source = source.Skip((index.Value - from) * size.Value).Take(size.Value);
            }

            var items = await mapper.ProjectTo<TModel>(source).ToListAsync();

            var list = new Pagination<TModel>
            {
                Index = index,
                Size = size,
                From = from,
                Count = count,
                Items = items
            };

            if (index.HasValue)
                list.Index += 1;

            if (size.HasValue)
                list.Pages = (int)Math.Ceiling(count / (double)size);

            return list;
        }
    }


    public class Pagination<T>
    {
        public Pagination()
        {
            Items = new T[0];
        }

        public Pagination(IEnumerable<T> source, int index, int size, int from)
        {
            var enumerable = source as T[] ?? source.ToArray();

            if (from > index)
                throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

            if (source is IQueryable<T> querable)
            {
                Index = index;
                Size = size;
                From = from;
                Count = querable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Index.HasValue && Size.HasValue)
                    querable = querable.Skip((Index.Value - From) * Size.Value).Take(Size.Value);

                Items = querable.ToList();
            }
            else
            {
                Index = index;
                Size = size;
                From = from;

                Count = enumerable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Index.HasValue && Size.HasValue)
                    Items = enumerable.Skip((Index.Value - From) * Size.Value).Take(Size.Value).ToList();
                else
                    Items = enumerable.ToList();
            }
        }

        public int From { get; set; }
        public int? Index { get; set; }
        public int? Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public IList<T> Items { get; set; }
        public bool HasPrevious => Index - From - 1 > 0;
        public bool HasNext => Index - From + 1 < Pages;
    }

}
