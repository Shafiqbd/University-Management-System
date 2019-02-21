using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityCRMS.Models
{
    public class ContextUniversity:DbContext
    {
        public DbSet<Student> Students { get; set; } 
    }
}