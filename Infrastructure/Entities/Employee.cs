using Infrastructure.Enums;
using SharedCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Employee
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public UserType UserType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
