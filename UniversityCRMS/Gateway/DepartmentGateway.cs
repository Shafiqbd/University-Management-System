using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCRMS.Models;

namespace UniversityCRMS.Gateway
{
    public class DepartmentGateway : Gateway
    {
        public bool AddDepartment(Department aDepartment)
        {
            Query = "INSERT INTO Departments(code,name) VALUES(@Code,@Name)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", aDepartment.Code);
            Command.Parameters.AddWithValue("Name", aDepartment.Name);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }
        

        public bool SearchDepartment(Department aDepartment)
        {
            Query = "SELECT * FROM  Departments where Code = @Code OR Name= @Name";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", aDepartment.Code);
            Command.Parameters.AddWithValue("Name", aDepartment.Name);
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

        public List<Department> ViewDepartment()
        {
            List<Department> aDeptList;
            Query = "SELECT * FROM Departments ";

            aDeptList = new List<Department>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Code = Reader["Code"].ToString();
                aDepartment.Name = Reader["Name"].ToString();
                aDeptList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return aDeptList;
        }

        public List<Course> CourseDetails(string department)
        {
            List<Course> aList;
            Query = "SELECT Courses.Name as Title,Courses.Code as Code,Samesters.Name as Semester FROM Samesters,courses where department  = '" + department + "' and  Courses.Samester=Samesters.NO";
            
            aList = new List<Course>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Name = Reader["Title"].ToString();
                course.Code = Reader["Code"].ToString();
                course.Semester = Reader["Semester"].ToString();
                aList.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return FindTeacherName(aList);
        }

        private List<Course> FindTeacherName(List<Course> courses)
        {
            List<Course> aList= new List<Course>();
            foreach (var course in courses)
            {
                Query = "select Teachers.Name as Teacher from CourseAssignToTeacher,Teachers where Teachers.ID = CourseAssignToTeacher.Teacher and Course = '" + course.Code + "'";
                
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Command.ExecuteNonQuery();
                Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.Name = course.Name;
                    aCourse.Code = course.Code;
                    aCourse.Semester = course.Semester;
                    aCourse.Teacher= Reader["Teacher"].ToString();
                    aList.Add(aCourse);
                }
                else
                {
                    Course aCourse = new Course();
                    aCourse.Name = course.Name;
                    aCourse.Code = course.Code;
                    aCourse.Semester = course.Semester;
                    aCourse.Teacher= "Not Assigned Yet";
                    aList.Add(aCourse);
                }
                Reader.Close();
                Connection.Close();
            }
            return aList;
        }
    }
}