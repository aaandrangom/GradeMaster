using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calificaciones.Modelos
{
    public class Grade
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public double Grades { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
