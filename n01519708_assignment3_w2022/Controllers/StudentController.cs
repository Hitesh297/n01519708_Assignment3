using n01519708_assignment3_w2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01519708_assignment3_w2022.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/List
        // GET: Student/List?searchText=alex
        public ActionResult List(string searchText = null)
        {
            StudentDataController studentDataController = new StudentDataController();
            List<Student> students = studentDataController.ListStudents(searchText);
            return View(students);
        }

        // GET: /Student/show/{id}
        public ActionResult Show(int id)
        {
            StudentDataController studentDataController = new StudentDataController();
            Student studentDetails = studentDataController.GetStudent(id);
            return View(studentDetails);
        }
    }
}