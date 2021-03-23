using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemplo.Models
{
    public class Pais
    {
        public int PaisId {get;set;}

        public List<Persona> Personas { get; set; }
        
        public List<Region> Regiones { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [Column(TypeName="VARCHAR(50)")]
        public string Nombre {set;get;}
    }
}