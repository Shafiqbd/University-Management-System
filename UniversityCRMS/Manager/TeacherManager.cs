using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMS.Gateway;
using UniversityCRMS.Models;

namespace UniversityCRMS.Manager
{
    public class TeacherManager
    {
        TeacherGatway aTeacherGatway = new TeacherGatway();

        public List<Designation> GetAllDesignation()
        {
            return aTeacherGatway.GellAllDesignation();
        }

        public string AddTeacher(Teacher aTeacher)
        {
            if (aTeacherGatway.SearchTeacher(aTeacher))
            {
                return "Duplicate Teacher";
            }
            aTeacherGatway.AddTeacher(aTeacher);
            return "Insert Succesfull";
        }

    //    public List<Teacher> GetAllTeacher()
    //    {
            
    //    }
        public List<Teacher> GetAllTeacher(string departmentCode)
        {
            return aTeacherGatway.GetAllTeacher(departmentCode);
        }

        public List<Course> GetAllCourse(string departmentCode)
        {
            return aTeacherGatway.GetAllCourse(departmentCode);
        }

        public string AssignCourse(AssignCourse assignCourse)
        {
            if (aTeacherGatway.IsExitsCourse(assignCourse.Course))
            {
                return "Course Already Assigned";
            }
             aTeacherGatway.AssignCourse(assignCourse);
            return "Course Assigne Successful";
        }

        public Teacher GetTeacherDetails(int id)
        {
            return aTeacherGatway.GetTeacherDetails(id);
        }

        public Course GetCourseDetails(string code)
        {
            return aTeacherGatway.GetCourseDetails(code);
        }
    }
}