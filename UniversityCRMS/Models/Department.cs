using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityCRMS.Models 
{
    public class Department
    {
        [Required(ErrorMessage = "Please enter a code")]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Please enter a code between 2-7 character")]
        public String Code { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public String Name { get; set; }
    }
}