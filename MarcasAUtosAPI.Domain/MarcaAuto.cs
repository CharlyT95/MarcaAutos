using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarcasAUtosAPI.Domain
{
    [Table("MarcasAuto")]
    [PrimaryKey(nameof(Id))]
    public class MarcaAuto : BaseDomainModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("Id")]

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(25)]
        public string Abreviatura { get; set; }


        [MaxLength(250)]
        public string? Descripcion { get; set; }
    }
}
