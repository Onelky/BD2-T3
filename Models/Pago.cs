using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemplo.Models
{
    public class Pago
    {
        public int PagoId {get;set;}
        
        [Column(TypeName="money")]
        [Required]
        public float Cantidad { get; set; }
        
        [Column(TypeName="decimal(8,2)")]
        [Required]
        public float Descuento { get; set; }

        
        [Required]
        public int ReservacionId { get; set; }
        public Reservacion Reservacion { get; set; }
        
        
    }
}