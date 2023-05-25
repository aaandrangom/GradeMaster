using Calificaciones.Modelos;
using Grades.UAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Grades.WebMVC.Controllers
{
    public class GradesController : Controller
    {
        private Crud<Grade> grades = new Crud<Grade>();
        private string Url = "https://localhost:7189/api/grades";

        // GET: ProvinciasController
        public ActionResult Index()
        {
            var datos = grades.Select(Url);
            return View(datos);
        }

        // GET: ProvinciasController/Details/5
        public ActionResult Details(int id)
        {
            var datos = grades.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: ProvinciasController/Create
        public ActionResult Create()
        {
            var students = new Crud<Student>().Select(Url.Replace("grades", "students"))
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name + " " + s.Lastname

                })
                .ToList();

            ViewBag.students = students;
         

            return View();
        }

        // POST: ProvinciasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grade datos)
        {
            try
            {
                grades.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProvinciasController/Edit/5
        public ActionResult Edit(int id)
        {
            var students = new Crud<Grade>().Select(Url.Replace("students", "grades"))
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Subject
                })
                .ToList();

            ViewBag.grades = grades;

            var datos = grades.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: ProvinciasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Grade datos)
        {
            try
            {
                grades.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: ProvinciasController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = grades.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: ProvinciasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Grade datos)
        {
            try
            {
                grades.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
