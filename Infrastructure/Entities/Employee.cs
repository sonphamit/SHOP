using SharedCore.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Employee
    {
        public Employee()
        {
            Id = CommonHelper.NewGuid();
        }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
