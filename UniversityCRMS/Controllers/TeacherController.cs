using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using UniversityCRMS.Manager;
using UniversityCRMS.Models;

namespace UniversityCRMS.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager aTeacherManager=new TeacherManager();
        // GET: Teacher
        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Designation = aTeacherManager.GetAllDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            ViewBag.Result=aTeacherManager.AddTeacher(aTeacher);
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Designation = aTeacherManager.GetAllDesignation();
            return View();
        }
        public ActionResult AssignCourse()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult AssignCourse(AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Result = aTeacherManager.AssignCourse(assignCourse);
            }
            ViewBag.Departments = departmentManager.ViewDepartment();
            return View();
        }

        public JsonResult ShowTeacher(Department department)
        {
            var teacher = aTeacherManager.GetAllTeacher(department.Code);
            return Json(teacher);
        }

        public JsonResult ShowCourse(Department department)
        {
            var course = aTeacherManager.GetAllCourse(department.Code);
            return Json(course);
        }

        public JsonResult DetailsTeacher(Teacher aTeacher)
        {
            var teacher = aTeacherManager.GetTeacherDetails(aTeacher.ID);
            return Json(teacher);
        }

        public JsonResult DetailsCourse(Course aCourse)
        {
            var course = aTeacherManager.GetCourseDetails(aCourse.Code);
            return Json(course);
        }
    }
}