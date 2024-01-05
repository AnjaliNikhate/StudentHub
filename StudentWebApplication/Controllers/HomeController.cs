using StudentWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebApplication.Controllers
{
    public class HomeController : Controller
    {
        IRepo repo;
        public HomeController()
        {
            repo = new ActualRepo();
        }
        public ActionResult Index()
        {
            return View(repo.GetAllStudents().OrderBy(s => s.Id));
        }

        public ActionResult IndexById(int id)
        {
            return View(repo.GetStudent(id));
        }

        public ActionResult Delete(int id)
        {
            bool deletionResult = repo.DeleteStudent(id);

            if (!deletionResult)
            {
                return HttpNotFound("Employee not found.");
            }

            TempData["SuccessMessage"] = "Student deleted successfully.";
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var studentToUpdate = repo.GetStudent(id);

            if (studentToUpdate == null)
            {
                return HttpNotFound();
            }

            return View(studentToUpdate);
        }

        [HttpPost]
        public ActionResult SaveUpdate(Student updatedStudent)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateStudent(updatedStudent);
                TempData["SuccessMessage"] = "Student updated successfully.";
                return RedirectToAction("Index");
            }

            return View("Update", updatedStudent);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(Student newStudent)
        {
            if (ModelState.IsValid)
            {
                if (repo.GetStudent(newStudent.Id) != null)
                {
                    ModelState.AddModelError("Id", "Student with this ID already exists.");
                    return View("AddStudent", newStudent);
                }

                repo.AddStudent(newStudent);
                TempData["SuccessMessage"] = "Student added successfully.";
                return RedirectToAction("Index");
            }

            return View("AddStudent", newStudent);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}