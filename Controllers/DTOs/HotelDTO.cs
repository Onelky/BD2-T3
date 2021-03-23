using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ejemplo.Models;

namespace ejemplo.Controllers.DTOs
{
    public class HotelDTO
    {
        public int HotelId {get;set;}
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int ProvinciaId { get; set; }
    }
}