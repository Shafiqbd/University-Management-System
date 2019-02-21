using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCRMS.Models;

namespace UniversityCRMS.Gateway
{
    public class TeacherGatway:Gateway
    {
        public List<Designation> GellAllDesignation()
        {
            List<Designation> aList= new List<Designation>();
            Query= "SELECT * FROM Designations";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.No = Reader["ID"].ToString();
                aDesignation.Name = Reader["Designation"].ToString();
                aList.Add(aDesignation);
            }
            Reader.Close();
            Connection.Close();
            return aList;
        }

        public bool AddTeacher(Teacher aTeacher)
        {
            Query = "INSERT INTO Teachers(Name,Address,Email,Contact,Designation,Department,Credit) VALUES(@Name,@Address,@Email,@Contact,@Designation,@Department,@Credit)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name", aTeacher.Name);
            Command.Parameters.AddWithValue("Address", aTeacher.Address);
            Command.Parameters.AddWithValue("Email", aTeacher.Email);
            Command.Parameters.AddWithValue("Contact", aTeacher.ContactNo);
            Command.Parameters.AddWithValue("Designation", aTeacher.Designation);
            Command.Parameters.AddWithValue("Department", aTeacher.Department);
            Command.Parameters.AddWithValue("Credit", aTeacher.CreditToBeTaken);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }
        public bool SearchTeacher(Teacher aTeacher)
        {
            Query = "SELECT * FROM  Teachers where Email = (@Email)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Email", aTeacher.Email);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Connection.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        public List<Teacher> GetAllTeacher(string departmentCode)
        {
            List<Teacher> teacherlist;
            Query = "SELECT * FROM Teachers where Department='"+departmentCode+"' ";

            teacherlist = new List<Teacher>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.ID = (int) Reader["ID"];
                aTeacher.Name = Reader["Name"].ToString();
                teacherlist.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teacherlist;
        }

        public List<Course> GetAllCourse(string departmentCode)
        {
            List<Course> courses;
            Query = "SELECT * FROM Courses where Department='" + departmentCode + "' ";

            courses = new List<Course>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Code = Reader["Code"] as string;
                course.Name = Reader["Name"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public bool AssignCourse(AssignCourse assignCourse)
        {
            Query = "INSERT INTO CourseAssignToTeacher(course,teacher) VALUES(@course,@teacher)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("course", assignCourse.Course);
            Command.Parameters.AddWithValue("teacher", assignCourse.Teacher);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public Teacher GetTeacherDetails(int id)
        {
            Query = "SELECT Credit,(select isnull(sum(Courses.Credit),0) from Courses,CourseAssignToTeacher where Courses.Code=CourseAssignToTeacher.Course and CourseAssignToTeacher.Teacher = (@Id)) as TakenCredit FROM  Teachers where ID = (@Id)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Id", id);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            Teacher teacher = new Teacher();
            while (Reader.Read())
            {
                teacher.CreditToBeTaken = (double) Reader["Credit"];
                teacher.RemainingCredit= (double)Reader["TakenCredit"];
                teacher.RemainingCredit = teacher.CreditToBeTaken - teacher.RemainingCredit;
            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }

        public Course GetCourseDetails(string code)
        {
            Query = "SELECT * FROM  Courses where Code = (@Code)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", code);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            Course course = new Course();
            while (Reader.Read())
            {
                course.Name = Reader["Name"].ToString();
                course.Credit = (double) Reader["Credit"];
            }
            Reader.Close();
            Connection.Close();
            return course;
        }

        public bool IsExitsCourse(string course)
        {
            Query = "SELECT * FROM  CourseAssignToTeacher where Course = (@Course)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Course", course);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }
    }
}