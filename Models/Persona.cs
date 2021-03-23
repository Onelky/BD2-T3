using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ejemplo.Models
{
   public class Persona
   {
       public int PersonaId {get;set;}
       
       [Required]
       public List<Rol> Roles { get; set; }
       public List<Reservacion> Reservaciones { get; set; } 
       
       [Required]
       public int PaisId { get; set; }
       public Pais Pais { get; set; }
       
       [Required]
       [MaxLength(25, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
       [MinLength(1)]
       [Column(TypeName="VARCHAR(25)")]
       public string Nombre {set;get;}
       
       [Required]
       [MaxLength(25, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
       [MinLength(1)]
       [Column(TypeName="VARCHAR(25)")]
       public string Apellidos {set;get;}
       
       [Required]
       [MaxLength(50, ErrorMessage = "{0} no puede tener mas de {1} caracteres")]
       [Column(TypeName="VARCHAR(25)")]
       public string Correo {set;get;}
       
       [Required]
       [StringLength(11)]
       [Column(TypeName="CHAR(11)")]

       public string Cedula {set;get;}
       
       [Required]
       [StringLength(10)]
       [Column(TypeName="CHAR(10)")]

       public string Telefono {set;get;}

   }
}
