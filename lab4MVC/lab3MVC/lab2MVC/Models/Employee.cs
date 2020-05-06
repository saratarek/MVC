using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab2MVC
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range (1000,5000)]
        public int Salary { get; set; }
        [Required]
        public string Address { get; set;}
    }
}