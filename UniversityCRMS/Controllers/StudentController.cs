using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMS.Manager;
using UniversityCRMS.Models;

namespace UniversityCRMS.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager aStudentManager=new StudentManager();
        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
                aStudent.RegistrationNo = aStudentManager.AddStudent(aStudent);
                if (aStudent.RegistrationNo== "Email Already Exits")
                {
                    ViewBag.Departments = departmentManager.ViewDepartment();
                    ViewBag.Result = aStudent.RegistrationNo;
                    return View();
                }
                ViewBag.Departments = departmentManager.ViewDepartment();
                return View(aStudent);
        }

        //enroll in a course
        public ActionResult Enrollment()
        {
            ViewBag.StudentReg = aStudentManager.GetAllRegistration();
            return View();
        }
        [HttpPost]
        public ActionResult Enrollment(Student aStudent)
        {
            ViewBag.Result = aStudentManager.EnrollInCourse(aStudent);
            ViewBag.StudentReg = aStudentManager.GetAllRegistration();
            return View();
        }
        public JsonResult StudentDetails(string RegistrationNo)
        {
            var studentDetails = aStudentManager.GetStudentDetails(RegistrationNo);
            return Json(studentDetails);
        }
        public JsonResult ShowCourse(string RegistrationNo)
        {
            var studentDetails = aStudentManager.GetStudentDetails(RegistrationNo);
            TeacherManager aTeacherManager=new TeacherManager();
            var course = aTeacherManager.GetAllCourse(studentDetails.DepartmentId);
            return Json(course);
        }

        //Result
        public ActionResult StudentResult()
        {
            ViewBag.StudentReg = aStudentManager.GetAllRegistration();
            ViewBag.Grades = GetAllGrade();
            return View();
        }
        [HttpPost]
        public ActionResult StudentResult(Student aStudent)
        {
            
            ViewBag.Result = aStudentManager.AddGrade(aStudent);
            ViewBag.StudentReg = aStudentManager.GetAllRegistration();
            ViewBag.Grades = GetAllGrade();
            return View();
        }
        public JsonResult ShowAvaiableCourse(string RegistrationNo)
        {
            var course = aStudentManager.GetAvaiableCourse(RegistrationNo);
            return Json(course);
        }
        private List<string> GetAllGrade()
        {
            List<string> grades = new List<string>
            {
                "A+","A","A-","B+","B","B-","C+","C","C-","D+","D","D-","F"
            };
            return grades;
        }

        //result view
        public ActionResult ResultView()
        {
            ViewBag.StudentReg = aStudentManager.GetAllRegistration();
            ViewBag.Grades = GetAllGrade();
            return View();
        }
        public JsonResult ShowAvaiableCourseResult(string RegistrationNo)
        {
            var course = aStudentManager.GetAvaiableCourse(RegistrationNo);
            
            return Json(aStudentManager.GetAllCourseResult(course, RegistrationNo));
        }
    }
}