using n01519708_assignment3_w2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01519708_assignment3_w2022.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List
        public ActionResult List()
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            List<Teacher> teachers = teacherDataController.ListTeachers();
            return View(teachers);
        }

        // GET: /Teacher/show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacherDetails = teacherDataController.GetTeacher(id);
            return View(teacherDetails);
        }
    }
}