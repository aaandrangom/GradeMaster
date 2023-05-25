using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calificaciones.Modelos;

namespace Grades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLStudentsController : ControllerBase
    {
        private readonly DataContext _context;

        public BLStudentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Promedio/5
        [HttpGet("{id}")]
        public ActionResult<double> GetPromedio(int id)
        {
            if (_context.Student == null)
            {
                return NotFound();
            }
            Student student = _context.Student.Include(g => g.Grades)
                .First(g => g.Id == id);

            double average = 0;
            double grades = 0;
            double count = 0;

            foreach (Grade g in student.Grades)
            {
                grades += g.Grades;
                count ++;
            }

            average = grades / count;

            if (student == null)
            {
                return NotFound();
            }

            return Math.Round(average, 1);
        }
    }
}
