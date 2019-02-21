using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMS.Manager;
using UniversityCRMS.Models;

namespace UniversityCRMS.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentManager departmentManager = new DepartmentManager();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            ViewBag.Result = departmentManager.AddDepartment(aDepartment);
            return View();
        }

        public ActionResult ViewDepartment()
        {
            return View(departmentManager.ViewDepartment());
        }

        [HttpGet]
        public ActionResult CourseDetails()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult CourseDetails(string d)
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            return View();
        }
        public JsonResult ShowCourse(Department department)
        {
            var course = departmentManager.CourseDetails(department.Code);
            return Json(course);
        }
    }
}