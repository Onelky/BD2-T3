using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemplo.Models
{
    public class Rol
    {
        public int RolId {get;set;}

        [Required]
        [MaxLength(20, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
        [Column(TypeName="VARCHAR(20)")]

        public string Nombre {set;get;}

        public ICollection <Persona> Personas { get; set; }     
    }
}