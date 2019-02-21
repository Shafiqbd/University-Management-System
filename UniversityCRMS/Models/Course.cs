using System.ComponentModel.DataAnnotations;

namespace UniversityCRMS.Models
{
    public class Course
    {
        [Required]
        [MinLength(5,ErrorMessage = "Please enter a code grater than 5 char")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Please enter credit between 0.5 to 5.0")]
        public double Credit { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Semester { get; set; }
        [Display (Name = "Assigned To")]
        public string Teacher { get; set; }

        public string Grade { get; set; }
    }
}