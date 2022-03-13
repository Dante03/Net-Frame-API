using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndWebApp.Models
{
    public class Mostrador
    {
        public int Id_LibAut { get; set; }
        public int Id_Autor { get; set; }
        public int Id_Libro { get; set; }
        [ForeignKey("Id_Libro")]
        public Libro Libro { get; set; }
        [ForeignKey("Id_Autor")]
        public Autor Autor { get; set; }
    }
}