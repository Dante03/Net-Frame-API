﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndWebApp.Models
{
    [Table("Prestamo")]
    public class Prestamo
    {
        public int Id_Prestamo { get; set; }
        public int Id_Lector { get; set; }
        public int Id_Libro { get; set; }
        public string Fecha_Prestamo { get; set; }
        public string Fecha_Devuelto { get; set; }
        public string Devuelto { get; set; }
        [ForeignKey("Id_Lector")]
        public Estudiante Estudiante { get; set; }
        [ForeignKey("Id_Libro")]
        public Libro Libro { get; set; }

    }
}
