using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ejemplo.Models
{
    public class Reservacion
    {
        public int ReservacionId {get;set;}
        [Required]
        public DateTime CheckIn {get;set;}
        [Required]
        public DateTime CheckOut {get;set;}
        
        [Required]
        public DateTime FechaReservacion {get;set;}
        
        [Required]
        public int CantAdultos { get; set; }
       
        [Required]
        public int CantNiños { get; set; }

        [Required]
        public float CostoTotal { get; set; }
        
        [Required]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        
        public int TipoPlanId { get; set; }
        public TipoPlan TipoPlan { get; set; }

        public List <Pago> Pagos { get; set; }     

        
    }
}