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
        // GET: Teacher/List?searchText=alex
        public ActionResult List(string searchText=null)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            List<Teacher> teachers = teacherDataController.ListTeachers(searchText);
            return View(teachers);
        }

        // GET: /Teacher/show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacherDetails = teacherDataController.GetTeacher(id);
            return View(teacherDetails);
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher NewTeacher = teacherDataController.GetTeacher(id);


            return View(NewTeacher);
        }


        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher model)
        {
            
            bool isStateValid = true; 
            if (string.IsNullOrEmpty(model.FirstName))
            {
                /*Manual add error to model state*/
                ModelState.AddModelError("FirstName", "First Name is required");
                isStateValid = false;
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                /*Manual add error to model state*/
                ModelState.AddModelError("LastName", "Last Name is required");
                isStateValid = false;
            }

            if (isStateValid && ModelState.IsValid)
            {
                TeacherDataController teacherDataController = new TeacherDataController();
                teacherDataController.AddTeacher(model);

                return RedirectToAction("List");
            }
            else
            {
                return View("New",model);
            }

            
        }

        /// <summary>
        /// Displays form to update Teacher details
        /// </summary>
        /// <param name="id">Teacher Id</param>
        /// <returns>Update page with prefilled existing values</returns>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher selectedTeacher = controller.GetTeacher(id);

            return View(selectedTeacher);
        }


        /// <summary>
        /// Updates Teacher details using AJAX
        /// </summary>
        /// <param name="id">Teacher Id</param>
        /// <returns>Update page with prefilled existing values</returns>
        public ActionResult AjaxUpdate(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher selectedTeacher = controller.GetTeacher(id);
            return View(selectedTeacher);
        }


        /// <summary>
        /// Updates the Teader data and redirects to show if update successful
        /// </summary>
        /// <param name="model">form data as teacher object from view</param>
        /// <returns>redirects to show page</returns>
        [HttpPost]
        public ActionResult Update(Teacher model)
        {
            bool isStateValid = true;
            if (string.IsNullOrEmpty(model.FirstName))
            {
                /*Manual add error to model state*/
                ModelState.AddModelError("FirstName", "First Name is required");
                isStateValid = false;
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                /*Manual add error to model state*/
                ModelState.AddModelError("LastName", "Last Name is required");
                isStateValid = false;
            }

            if (isStateValid && ModelState.IsValid)
            {
                TeacherDataController teacherDataController = new TeacherDataController();
                teacherDataController.UpdateTeacher(model);

                return RedirectToAction("Show/" + model.TeacherId);
            }
            else
            {
                return View("Update", model);
            }

        }
    }
}