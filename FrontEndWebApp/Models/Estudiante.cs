using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEndWebApp.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        public int Id_Lector { get; set; }

        [StringLength(5)]
        public string CI { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Carrera { get; set; }

        [StringLength(5)]
        public string Edad { get; set; }
    }
}
