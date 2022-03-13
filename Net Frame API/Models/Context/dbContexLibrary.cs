using System.Data.Entity;

namespace Net_Frame_API.Models.Context
{
    public class dbContexLibrary : DbContext
    {
        public dbContexLibrary() : base("name=dbContextBiblioteca")
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<Mostrador> Counter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Autor>()
                .Property(e => e.Nacionalidad)
                .IsUnicode(false);

            modelBuilder.Entity<Autor>()
                .Property(e => e.Edad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.CI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Carrera)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Edad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Libro>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Libro>()
                .Property(e => e.Editorial)
                .IsUnicode(false);

            modelBuilder.Entity<Libro>()
                .Property(e => e.Area)
                .IsUnicode(false);
        }
    }
}