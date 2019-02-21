using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMS.Gateway;
using UniversityCRMS.Models;

namespace UniversityCRMS.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public string AddDepartment(Department aDepartment)
        {
            if (aDepartmentGateway.SearchDepartment(aDepartment))
            {
                return "Duplicate Department";
            }
            aDepartmentGateway.AddDepartment(aDepartment);
            return "Insert Succesfull";
        }

        public List<Department> ViewDepartment()
        {
            return aDepartmentGateway.ViewDepartment();
        }

        public List<Course> CourseDetails(string code)
        {
            return aDepartmentGateway.CourseDetails(code);
        }
    }
}