using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace UniversityCRMS.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid contact")]
        [Display(Name = "Contact")]
        public string ContactNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string DepartmentId { get; set; }

        [Required]
        [Display(Name = "Registration No")]
        public string RegistrationNo { get; set; }
        [Required]
        public string Course { get; set; }

        public string CourseName { get; set; }
        [Required]
        public string Grade { get; set; }

    }
}