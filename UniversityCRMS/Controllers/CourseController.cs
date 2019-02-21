using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCRMS.Manager;
using UniversityCRMS.Models;

namespace UniversityCRMS.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager aCourseManager=new CourseManager();

        // GET: Course
        [HttpGet]
        public ActionResult SaveCourse()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Semesters = aCourseManager.GetAllSemester();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Semesters = aCourseManager.GetAllSemester();
            ViewBag.Result=aCourseManager.AddCourese(aCourse);
            return View();
        }

        //room
        [HttpGet]
        public ActionResult AllocateRoom()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Rooms = aCourseManager.GetAllRooms();
            return View();
        }
        [HttpPost]
        public ActionResult AllocateRoom(AllocateRoom allocate)
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Rooms = aCourseManager.GetAllRooms();
            ViewBag.Result = aCourseManager.AllocateRoom(allocate);
            return View();
        }
        public JsonResult GetAllCourse(Department department)
        {
            var course = departmentManager.CourseDetails(department.Code);
            return Json(course);
        }


        [HttpGet]
        public ActionResult ScheduleRoom()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Rooms = aCourseManager.GetAllRooms();
            return View();
        }
        public JsonResult Schedule(Department department)
        {
            var course = aCourseManager.GetSchedule(department.Code);
            return Json(course);
        }
    }
}