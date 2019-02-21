using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using UniversityCRMS.Models;

namespace UniversityCRMS.Gateway
{
    public class CourseGatway:Gateway
    {
        public List<Semester> GetAllSemester()
        {
            List<Semester> aList;
            Query = "SELECT * FROM Samesters ";

            aList = new List<Semester>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Semester aSemester = new Semester();
                aSemester.No = Reader["No"].ToString();
                aSemester.Name = Reader["Name"].ToString();
                aList.Add(aSemester);
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }
        public bool AddCourse(Course aCourse)
        {
            Query = "INSERT INTO Courses(Code,Name,Credit,Descriptions,Department,Samester,status) VALUES(@Code,@Name,@Credit,@Description,@Department,@Semester,'availavle')";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", aCourse.Code);
            Command.Parameters.AddWithValue("Name", aCourse.Name);
            Command.Parameters.AddWithValue("Credit", aCourse.Credit);
            Command.Parameters.AddWithValue("Description", aCourse.Description);
            Command.Parameters.AddWithValue("Department", aCourse.Department);
            Command.Parameters.AddWithValue("Semester", aCourse.Semester);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public bool SearchCourse(Course aCourse)
        {
            Query= "SELECT * FROM  Courses where Code = (@Code) OR Name=(@Name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", aCourse.Code);
            Command.Parameters.AddWithValue("Name", aCourse.Name);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {

                Reader.Close();
                Connection.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        //room
        public string AllocateRoom(AllocateRoom allocate)
        {
            Query = "INSERT INTO RoomAllocation(Course,Room,Day,StartTime,EndTime) VALUES(@Course,@Rooms,@Day,@TimeFrom,@TimeTo)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Course", allocate.Course);
            Command.Parameters.AddWithValue("Rooms", allocate.Rooms);
            Command.Parameters.AddWithValue("Day", allocate.Day);
            Command.Parameters.AddWithValue("TimeFrom", allocate.TimeFrom);
            Command.Parameters.AddWithValue("TimeTo", allocate.TimeTo);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return "Room Allocation Successful";
        }

        public List<Rooms> GetAllRooms()
        {
            List<Rooms> rooms = new List<Rooms>();
            Query = "SELECT * FROM Rooms ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Rooms aRoom = new Rooms();
                aRoom.RoomNo = (int)Reader["RoomNo"];
                aRoom.Name = Reader["Name"].ToString();
                rooms.Add(aRoom);
            }
            Reader.Close();
            Connection.Close();
            return rooms;
        }

        public List<Schedule> GetSchedule(string code)
        {
            List<Schedule> aList;
            Query = "SELECT Courses.Name as Title,Courses.Code as Code,Samesters.Name as Semester FROM Samesters,courses where department  = '" + code + "' and  Courses.Samester=Samesters.NO";

            aList = new List<Schedule>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Schedule course = new Schedule();
                course.Name = Reader["Title"].ToString();
                course.CouseCode = Reader["Code"].ToString();
                aList.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return FindScheduleRoom(aList);
        }

        public List<Schedule> FindScheduleRoom(List<Schedule> schedules)
        {
            List<Schedule> aList = new List<Schedule>();
            foreach (var schedule in schedules)
            {

                Schedule aShedule = new Schedule();
                aShedule.Name = schedule.Name;
                aShedule.CouseCode = schedule.CouseCode;
                Query = "select Rooms.Name as Room, Day, StartTime = (right(convert(varchar(20), StartTime, 100), 7)),EndTime = (right(convert(varchar(20), EndTime, 100), 7)) from Courses,RoomAllocation,Rooms where Rooms.RoomNO = RoomAllocation.Room and Courses.Code = RoomAllocation.Course and Courses.Name = '"+ schedule.Name+ "' ";

                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Command.ExecuteNonQuery();
                Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    aShedule.SeheduleInfo += "R.No: " + Reader["Room"].ToString() + " " + Reader["Day"].ToString() + " " + Reader["StartTime"].ToString() + " " + Reader["EndTime"].ToString() + " ";

                    
                    while (Reader.Read())
                    {
                        aShedule.SeheduleInfo += "R.No: " + Reader["Room"].ToString() + " " + Reader["Day"].ToString() + " " + Reader["StartTime"].ToString() + " " + Reader["EndTime"].ToString() + " ";

                    }

                }
                else
                {
                    aShedule.SeheduleInfo = "Not Schefuled Yet";
                }
                aList.Add(aShedule);
                Reader.Close();
                Connection.Close();
            }
            return aList;
        }

        //allocation
        public bool SearchBeetweenTime(AllocateRoom allocate)
        {
            //DateTime startTime = DateTime.Parse(allocate.TimeFrom).AddMinutes(DateTime.Parse("0:01 AM").Minute);
            //DateTime temp = DateTime.Parse("0:01 AM");
            //DateTime endTime = DateTime.Parse(allocate.TimeTo);

            //string startTimeS = startTime.TimeOfDay.ToString();
            //string endTimeS = (endTime.Subtract(temp)).ToString();
            Query = "SELECT * FROM RoomAllocation WHERE Room=" + allocate.Rooms + " AND day='" + allocate.Day + "' AND StartTime>= '" + allocate.TimeFrom + "' and StartTime<'" + allocate.TimeTo + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {

                Reader.Close();
                Connection.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        public bool SearchBefore(AllocateRoom allocate)
        {
             
            Query = "select endtime from RoomAllocation where Room=" + allocate.Rooms + " AND day='" + allocate.Day + "' AND StartTime<='"+allocate.TimeFrom+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                string temp =  Reader["endtime"].ToString();
                DateTime endTime = DateTime.Parse(temp);
                DateTime startTime = DateTime.Parse(allocate.TimeFrom);

                int minutes = (int) (startTime.Subtract(endTime).TotalMinutes);
                if (minutes < 0)
                {

                    Reader.Close();
                    Connection.Close();
                    return true;
                }
            }
            Reader.Close();
            Connection.Close();
            return false;
        }
    }
}