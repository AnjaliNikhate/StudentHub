using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentWebApplication.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name should only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course is required")]
        [StringLength(50, ErrorMessage = "Course must be less than 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Course should only contain letters and spaces")]
        public string Course { get; set; }

        [Required(ErrorMessage = "College is required")]
        [StringLength(100, ErrorMessage = "College must be less than 100 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "College should only contain letters and spaces")]
        public string College { get; set; }
    }
}