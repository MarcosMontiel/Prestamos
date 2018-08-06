using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marcos.Prestamos.Models
{
    public class ComDirCatMunicipio
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Valor { get; set; }

        public int FKComDirCatEstado { get; set; }
        [ForeignKey("FKComDirCatEstado")]
        public ComDirCatEstado ComDirCatEstado { get; set; }
    }
}