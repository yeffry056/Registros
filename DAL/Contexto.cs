using Microsoft.EntityFrameworkCore;
using Registros.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Permisos> Permisos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Registros.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombre = "Jefferson",
                Alias = "Yeffry",
                Email = "prueba@gmail.com",
                Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"//clave: 1234
            });
        }
    }
}
