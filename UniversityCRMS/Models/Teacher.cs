using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityCRMS.Models
{
    public class Teacher
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required]
        public int ContactNo { get; set; }

        [Required]
        public int Designation { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public double CreditToBeTaken { get; set; }

        [Required]
        public double RemainingCredit { get; set; }
    }
}