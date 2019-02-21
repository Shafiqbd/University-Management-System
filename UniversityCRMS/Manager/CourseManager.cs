using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCRMS.Gateway;
using UniversityCRMS.Models;

namespace UniversityCRMS.Manager
{
    public class CourseManager
    {
        CourseGatway aCourseGatway = new CourseGatway();

        public List<Semester> GetAllSemester()
        {
            return aCourseGatway.GetAllSemester();
        }

        public string AddCourese(Course aCourse)
        {
            if (aCourseGatway.SearchCourse(aCourse))
            {
                return "Duplicate Couse";
            }
            aCourseGatway.AddCourse(aCourse);
            return "Insert Succesfull";
        }

        //room

        public string AllocateRoom(AllocateRoom allocate)
        {
            if (aCourseGatway.SearchBeetweenTime(allocate))
            {
                return "This time slot is booked";
            }
            if (aCourseGatway.SearchBefore(allocate))
            {
                return "This time slot is booked";
            }
            //if (aCourseGatway.CheckRoomTime(allocate))
            //{

            //}
            return aCourseGatway.AllocateRoom(allocate);
        }

        public List<Rooms> GetAllRooms()
        {
            return aCourseGatway.GetAllRooms();
        }

        public List<Schedule> GetSchedule(string code)
        {
            return aCourseGatway.GetSchedule(code);
        }
    }
}