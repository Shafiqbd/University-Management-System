using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCRMS.Models;

namespace UniversityCRMS.Gateway
{
    public class StudentGateway:Gateway
    {
        public string AddStudent(Student aStudent)
        {
            string id = SearchValue(aStudent);
            Query = "INSERT INTO Students(RegistrationNo,Name,Email,Contact,Department,Date,Address) VALUES(@RegistrationNo,@Name,@Email,@Contact,@Department,@Date,@Address)";
            string reg = aStudent.DepartmentId + "-" + aStudent.Date.Year+"-"+id;
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name", aStudent.Name);
            Command.Parameters.AddWithValue("RegistrationNo", reg);
            Command.Parameters.AddWithValue("Email", aStudent.Email);
            Command.Parameters.AddWithValue("Contact", aStudent.ContactNo);
            Command.Parameters.AddWithValue("Department", aStudent.DepartmentId);
            Command.Parameters.AddWithValue("Date", aStudent.Date);
            Command.Parameters.AddWithValue("Address", aStudent.Address);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return reg;
        }

        private string SearchValue(Student aStudent)
        {
            Query = "select count(id)+1 as ID from Students where Department = '"+aStudent.DepartmentId+"' and year(date) = '"+aStudent.Date.Year+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            int ID = 0;
            if (Reader.Read())
            {
                ID=(int) Reader["ID"];
            }
            Reader.Close();
            Connection.Close();
            return ID.ToString("000");
        }

        public List<Student> GetAllRegistration()
        {
            List<Student> students;
            Query = "SELECT ID,RegistrationNo FROM Students ";

            students = new List<Student>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent=new Student();
                aStudent.Id =(int) Reader["ID"];
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString();
                students.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public Student GetStudentDetails(string registrationNo)
        {
            Student aStudent = new Student();
            Query = "select * from Students where ID = '" + registrationNo + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                aStudent.Name = Reader["Name"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentId = Reader["Department"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        public bool IsExitsMail(string email)
        {
            Query = "SELECT * FROM  Students where Email = @Email";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Email", email);
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

        public String EnrollInCourse(Student aStudent)
        {
            Query = "INSERT INTO StudentEnroll(StudentID,Course,Date) VALUES(@StudentID,@Course,@Date)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("StudentID", aStudent.RegistrationNo);
            Command.Parameters.AddWithValue("Course", aStudent.Course);
            Command.Parameters.AddWithValue("Date", aStudent.Date);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return "Insert Succesful";
        }

        public bool IsExitsEnroll(Student aStudent)
        {
            Query = "select * from StudentEnroll where StudentID='"+aStudent.RegistrationNo+"' and Course='"+aStudent.Course+"'";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                Connection.Close();
                Reader.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        public string AddGrade(Student aStudent)
        {
            Query = "INSERT INTO Results(StudentID,Course,Grade) VALUES(@StudentID,@Course,@Grade)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("StudentID", aStudent.RegistrationNo);
            Command.Parameters.AddWithValue("Course", aStudent.Course);
            Command.Parameters.AddWithValue("Grade", aStudent.Grade);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return "Result Insert Succesful";
        }

        public List<Course> GetAvaiableCourse(string registrationNo)
        {
            List<Course> courses;
            Query = "select * from StudentEnroll,Courses where Courses.Code=StudentEnroll.Course and StudentID=ISNUll((select id from Students where ID='" + registrationNo+"'),0)";

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

        public bool IsExitsGrade(Student aStudent)
        {
            Query = "select * from Results where StudentID='"+aStudent.RegistrationNo+"' and Course ='"+aStudent.Course+"'";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                Connection.Close();
                Reader.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        public string UpdateGrade(Student aStudent)
        {
            Query = "UPDATE Results SET Grade = '"+aStudent.Grade+"' WHERE StudentID='"+aStudent.RegistrationNo+"' and Course='"+aStudent.Course+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return "Result Updated";
        }

        public List<Course> GetAllCourseResult(List<Course> course, string registrationNo)
        {
            List<Course> aCourses=new List<Course>();
            foreach (Course aCourse in course)
            {
                Query = "select grade from Results where StudentID="+registrationNo+" and Course='"+aCourse.Code+"'";
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Command.ExecuteNonQuery();
                Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Course cours=new Course();
                    cours.Grade = Reader["grade"].ToString();
                    cours.Code = aCourse.Code;
                    cours.Name = aCourse.Name;
                    aCourses.Add(cours);
                }
                else
                {
                    Course cours = new Course();
                    cours.Grade = "Not Passed";
                    cours.Code = aCourse.Code;
                    cours.Name = aCourse.Name;
                    aCourses.Add(cours);
                }
                Reader.Close();
                Connection.Close();
            }

            return aCourses;
        }
    }
}