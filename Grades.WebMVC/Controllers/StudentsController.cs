using Grades.UAPI;
using Calificaciones.Modelos;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Grades.WebMVC.Controllers
{
    public class StudentsController : Controller
    {
        private Crud<Student> students = new Crud<Student>();
        private string Url = "https://localhost:7189/api/students";

        // GET: StudentsController
        public ActionResult Index()
        {
            var datos = students.Select(Url);
            return View(datos);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            var datos = students.Select_ById(Url, id.ToString());
            var bLGradesController = new BLGradesController();
            double average = bLGradesController.GetAverage(id);
            ViewBag.Average = average;
            return View(datos);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]                   
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student datos)
        {
            try
            {
                students.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: CantonesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = students.Select_ById(Url, id.ToString());
            return View(data);
        }

        // POST: CantonesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student datos)
        {
            try
            {
                students.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: CantonesController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = students.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: CantonesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student datos)
        {
            try
            {
                students.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
