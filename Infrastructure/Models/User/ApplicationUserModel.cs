﻿using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class ApplicationUserModel
    { 
        public string Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FullName { get; set; }
        public UserType UserType { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        public string Address { get; set; }
    }
}
