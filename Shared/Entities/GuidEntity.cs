using Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public interface IBaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }

    }

    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Id = CommonHelper.NewGuid();
            CreatedBy = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
