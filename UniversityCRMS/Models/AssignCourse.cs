using System.ComponentModel.DataAnnotations;

namespace UniversityCRMS.Models
{
    public class AssignCourse
    {
        [Required]
        public string Departments { get; set; }
        [Required]
        public int Teacher { get; set; }
        [Required]
        public string Course { get; set; }
    }
}