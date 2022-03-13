using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Frame_API.Models
{
    [Table("Autor")]
    public partial class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Autor { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Nacionalidad { get; set; }

        [StringLength(5)]
        public string Edad { get; set; }
    }
}
