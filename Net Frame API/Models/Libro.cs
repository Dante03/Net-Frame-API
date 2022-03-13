using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Frame_API.Models
{

    [Table("Libro")]
    public partial class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Libro { get; set; }

        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string Editorial { get; set; }

        [StringLength(50)]
        public string Area { get; set; }
    }
}
