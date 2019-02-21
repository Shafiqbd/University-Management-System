using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMS.Gateway;
using UniversityCRMS.Models;

namespace UniversityCRMS.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway=new StudentGateway();

        public string AddStudent(Student aStudent)
        {
            if (aStudentGateway.IsExitsMail(aStudent.Email))
            {
                return "Email Already Exits";
            }
            return aStudentGateway.AddStudent(aStudent);
        }

        public List<Student> GetAllRegistration()
        {
            return aStudentGateway.GetAllRegistration();
        }

        public Student GetStudentDetails(string registrationNo)
        {
            return aStudentGateway.GetStudentDetails(registrationNo);
        }

        public string EnrollInCourse(Student aStudent)
        {
            if (aStudentGateway.IsExitsEnroll(aStudent))
            {
                return "This student Already enroll in this course";
            }
            return aStudentGateway.EnrollInCourse(aStudent); ;
        }

        public string AddGrade(Student aStudent)
        {
            if (aStudentGateway.IsExitsGrade(aStudent))
            {
                return aStudentGateway.UpdateGrade(aStudent);
            }
            return aStudentGateway.AddGrade(aStudent);
        }

        public List<Course> GetAvaiableCourse(string registrationNo)
        {
            return aStudentGateway.GetAvaiableCourse(registrationNo);
        }

        public List<Course> GetAllCourseResult(List<Course> course, string registrationNo)
        {
            return aStudentGateway.GetAllCourseResult(course,registrationNo);
        }
    }
}