using MySql.Data.MySqlClient;
using n01519708_assignment3_w2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01519708_assignment3_w2022.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext schoolDbContext = new SchoolDbContext();

        /// <summary>
        /// Returns a list of Teachers
        /// </summary>
        /// <param name="searchText">takes in search text (optional)</param>
        /// <returns>A list of Teacher objects</returns>
        /// Example : /api/TeacherData/listteachers
        /// Example : /api/TeacherData/listteachers/alex
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{searchText?}")]
        public List<Teacher> ListTeachers(string searchText = null)
        {
            
            MySqlConnection connection = schoolDbContext.AccessDatabase();

            connection.Open();

            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandText = "SELECT * FROM teachers WHERE LOWER(teacherfname) like LOWER(@key) OR LOWER(teacherlname) LIKE LOWER(@key)";
            mySqlCommand.Parameters.AddWithValue("@key", "%" + searchText + "%");
            mySqlCommand.Prepare();

            MySqlDataReader resultSet = mySqlCommand.ExecuteReader();

            List<Teacher> teachersList = new List<Teacher>();

            while (resultSet.Read())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherId = Convert.ToInt32(resultSet["teacherid"]);
                teacher.FirstName = resultSet["teacherfname"].ToString();
                teacher.LastName = resultSet["teacherlname"].ToString();
                teacher.EmployeeNumber = resultSet["employeenumber"].ToString();
                teacher.HireDate = Convert.ToDateTime(resultSet["hiredate"]);
                teacher.Salary = Convert.ToDecimal(resultSet["salary"]);
                teachersList.Add(teacher);
            }

            connection.Close();

            return teachersList;
        }

        /// <summary>
        /// Gets details of a teachers from id
        /// </summary>
        /// <param name="id">teacher id</param>
        /// <returns>Returns Teacher details</returns>
        /// Example: /api/TeacherData/getteacher/1
        [HttpGet]
        public Teacher GetTeacher(int id)
        {
            MySqlConnection connection = schoolDbContext.AccessDatabase();
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM teachers AS t LEFT JOIN classes AS c ON t.teacherid = c.teacherid WHERE t.teacherid = " + id;

            MySqlDataReader result = command.ExecuteReader();

            Teacher teacherDetails = new Teacher();

            while (result.Read())
            {
                teacherDetails.TeacherId = Convert.ToInt32(result["teacherid"]);
                teacherDetails.FirstName = result["teacherfname"].ToString();
                teacherDetails.LastName = result["teacherlname"].ToString();
                teacherDetails.EmployeeNumber = result["employeenumber"].ToString();
                teacherDetails.HireDate = Convert.ToDateTime(result["hiredate"]);
                teacherDetails.Salary = Convert.ToDecimal(result["salary"]);

                if (!Convert.IsDBNull(result["classcode"]))
                {
                    teacherDetails.Subject = new Subject()
                    {
                        ClassCode = result["classcode"].ToString(),
                        ClassId = Convert.ToInt32(result["classid"]),
                        ClassName = result["classname"].ToString(),
                        FinishDate = Convert.ToDateTime(result["finishdate"]),
                        StartDate = Convert.ToDateTime(result["startdate"])
                    };
                }
            }

            return teacherDetails;
        }

        /// <summary>
        /// Deletes an Teacher from the connected MySQL Database if the ID of that author exists
        /// </summary>
        /// <param name="id">The ID of the teacher.</param>
        /// <example>POST /api/TeacherData/DeleteTeacher/30</example>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
 
            MySqlConnection Conn = schoolDbContext.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Delete from teachers where teacherid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            Conn.Close();

        }


        /// <summary>
        /// Adds a Teacher to the MySQL Database.
        /// </summary>
        /// <param name="NewTeacher">An object of type Teacher that map to the columns of the Teachers table.</param>
        /// <example>
        /// POST api/TeacherData/AddTeacher 
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"FirstName":"Hitesh",
        ///	"LastName":"Patel",
        ///	"EmployeeNumber":"E12345",
        ///	"Salary":"45.66"
        /// }
        /// </example>
        [HttpPost]
        public void AddTeacher([FromBody] Teacher NewTeacher)
        {
      
            MySqlConnection Conn = schoolDbContext.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TeacherFname,@TeacherLname,@EmployeeNumber, CURRENT_DATE(), @Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.FirstName);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.LastName);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }
    }
}
