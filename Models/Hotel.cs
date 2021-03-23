using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemplo.Models
{
    public class Hotel
    {
        public int HotelId {get;set;}
        
        [Required]
        [MaxLength(25, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [MinLength(1)]
        public string Nombre { get; set; }
        
        [Required]
        [MaxLength(60, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [MinLength(1)]
        [Column(TypeName="VARCHAR(50)")]
        public string Direccion { get; set; }
        
        [Required]
        [MaxLength(10, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [MinLength(1)]
        [Column(TypeName="VARCHAR(10)")]
        public string Telefono { get; set; }
        
        [Required]
        [MaxLength(60, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [MinLength(1)]
        [Column(TypeName="VARCHAR(50)")]
        public string Email { get; set; }
        
        [Required]
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public List<Edificio> Edificios { get; set; }
        public List <Reservacion> Reservaciones { get; set; }
    }
}