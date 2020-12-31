using Shared.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public interface IBaseEntity
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }

    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Id = CommonHelper.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
