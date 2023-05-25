namespace Calificaciones.Modelos
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set;}
        public int Age { get; set; }
        public string? Address { get; set; }

        public List<Grade>? Grades { get; set; }
    }   
}