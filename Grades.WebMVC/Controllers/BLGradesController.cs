using Calificaciones.Modelos;
using Grades.Models;
using Grades.UAPI;
using Microsoft.AspNetCore.Mvc;

namespace Grades.WebMVC.Controllers
{
    public class BLGradesController : Controller
    {
        private Crud<double> average = new Crud<double>();

        private Crud<Student> students = new Crud<Student>();
        private string Url = "https://localhost:7189/api/students";
        public double GetAverage(int id)
        {
            var data = students.Select_ById(Url, id.ToString());

            double average = 0;
            double count = 0;
            double sum = 0;

            foreach(Grade g in data.Grades)
            {
                sum += g.Grades;
                count++;
            }

            average = sum / count;

            return average;
        }
    }
}
