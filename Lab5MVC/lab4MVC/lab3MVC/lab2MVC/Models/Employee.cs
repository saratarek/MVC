//using lab2MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //public int? Fk_DepartmentId { get; set; }
        [Required]
        [Range (1000,5000)]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set;}

        //[ForeignKey("Fk_DepartmentId")]
        //public virtual Department Department { get; set; }
    }
}