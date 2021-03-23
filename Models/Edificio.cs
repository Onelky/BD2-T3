using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ejemplo.Models
{
    public class Edificio
    {
        public int EdificioId { get; set; }
       
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [MinLength(1)]
        [Column(TypeName="VARCHAR(25)")]
        public string Nombre { get; set; }

    }
}