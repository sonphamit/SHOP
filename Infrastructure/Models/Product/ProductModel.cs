﻿using Infrastructure.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Images = new List<ResourceModel>();
        }
        public string Id { get; set; }
        [Required]
        public string SupplierId { get; set; } = string.Empty;
        [Required]
        public string CategoryId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Name is at least 3 chars.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Production Code is required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Production Code is 8 chars.")]
        public string ProductionCode { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public Gender Gender { get; set; } = Gender.ALL;
        [Required(ErrorMessage = "Unit Price is required")]
        public uint UnitPrice { get; set; }
        [Required(ErrorMessage = "Discount is required")]
        public decimal Discount { get; set; } = 0;
        [Required(ErrorMessage = "Units In Stock is required")]
        public uint UnitsInStock { get; set; }
        public uint UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
        public virtual List<ResourceModel> Images { get; set; }

    }
    
}
