using Microsoft.EntityFrameworkCore;
using PrestamosWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosWPF.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Database.db");
        }

    }
}
