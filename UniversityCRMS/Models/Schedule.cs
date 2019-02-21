using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCRMS.Models
{
    public class Schedule
    {
        public string Department { get; set; }
        [Display(Name = "Couse Code")]
        public string CouseCode { get; set; }
        public string Name { get; set; }
        [Display(Name = "Shedule Info")]
        public string SeheduleInfo { get; set; }
    }
}