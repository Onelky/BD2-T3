using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemplo.Models
{
    public class Provincia
    {
        public int ProvinciaId {get;set;}
        
        [Required]
        [MaxLength(50, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [Column(TypeName="VARCHAR(50)")]
        public string Nombre {set;get;}
        
        [Required]
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public Hotel Hotel { get; set; }
    }
}