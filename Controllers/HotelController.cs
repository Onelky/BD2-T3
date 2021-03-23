using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ejemplo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using ejemplo.Controllers.DTOs;


namespace ejemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelContext _context;
       
        private readonly ILogger<HotelController> _logger;

        public HotelController(HotelContext context)
        {
            _context = context;
        }

        #region HOTEL

        [HttpGet("hoteles")]
        public async Task<ActionResult<List<Hotel>>> GetHoteles()
        {
            return await _context.Hoteles
                        .Include(x => x.Edificios)
                        .Include(y => y.Provincia)
                        .ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Hotel(int id)
        {
            var hotel =  _context.Hoteles.SingleOrDefault(x => x.HotelId == id);

            if (hotel == null)
            {
                return NotFound();
            }

            return _context.Hoteles
                .Include("Edificios")
                .Include("Provincia")
                .FirstOrDefault();
        }

        
        [HttpPost]
        public async Task<ActionResult<Hotel>> CrearHotel(Hotel hotel)
        {
            _context.Hoteles.Add(hotel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Hotel", new { id = hotel.HotelId }, hotel);
            
        }
        
        [HttpPut("{id}")]
        
        public async Task<ActionResult<Hotel>> Hotel(HotelDTO hotelAct, int id )
        {
            var hotel =  _context.Hoteles.SingleOrDefault(x => x.HotelId == id);
            

            if (hotel != null)
            {

                hotelAct.HotelId = hotel.HotelId;
                _context.Entry(hotel).CurrentValues.SetValues(hotelAct);
                _context.SaveChanges();
                return CreatedAtAction("Hotel", new { id = hotel.HotelId }, hotel);
            }

            return NotFound();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> BorrarHotel(int id )
        {
            var hotel =  _context.Hoteles.SingleOrDefault(x => x.HotelId == id);

            if (hotel != null)
            {
                _context.Hoteles.Remove(hotel);
                _context.SaveChanges();
                return CreatedAtAction("BorrarHotel", 
                                    new { message =  "Se ha eliminado el elemento"});
            }

            return NotFound();

        }
        #endregion
        
        
        
        
    }
}
