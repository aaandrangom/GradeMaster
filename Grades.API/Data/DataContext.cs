using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Calificaciones.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Calificaciones.Modelos.Student> Student { get; set; } = default!;

        public DbSet<Calificaciones.Modelos.Grade>? Grade { get; set; }
    }
