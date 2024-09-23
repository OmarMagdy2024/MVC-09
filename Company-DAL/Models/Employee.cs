using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Company_DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,
        [EnumMember(Value = "Female")]
        Female = 2
    }
    public class Employee : ModelBase
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Range(21, 65)]
        [Required(ErrorMessage = "Age Is Required")]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Salary Is Required")]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "HiringDate Is Required")]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }

        [Required(ErrorMessage = "DepartmentId Is Required")]
        public int? DepartmentId { get; set; }

        [NotMapped]
        public IFormFile Image {  get; set; }
        public string ImageName { get; set; }
    }

}
