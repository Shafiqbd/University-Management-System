using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCRMS.Models
{
    public class AllocateRoom
    {
        //public int Id { get; set; }
        [Required]
        public string Department { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string Rooms { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        public string TimeFrom { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{hh:mm:ss}")]
        public string TimeTo { get; set; }

    }
}