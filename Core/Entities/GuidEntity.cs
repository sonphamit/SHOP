using Core.Helpers;
using System;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public abstract class GuidEntity : BaseEntity
    {
        public string Id { get; set; }

        public GuidEntity()
        {
            Id = CommonHelper.NewGuid();
        }
    }

}
