using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ejemplo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ejemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectionController : Controller
    {
        private readonly HotelContext _context;
        
        private readonly IMapper _mapper;  

        public DirectionController(HotelContext context)
        {
            _context = context;
        }

        [HttpGet("paises")]
        public async Task<ActionResult<List<Pais>>> GetPaises()
        {
            return _context.Paises
                            .Include("Regiones")
                            .Include("Personas")
                            .ToList();
        }
        
        [HttpGet("pais/{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var pais =  _context.Paises.SingleOrDefault(x => x.PaisId == id);

            if (pais == null)
            {
                return NotFound();
            }

            return _context.Paises
                .Where(x => x.PaisId == pais.PaisId)
                .Include(b => b.Regiones)
                .Include(a => a.Personas)
                .FirstOrDefault();
        }

        
        [HttpPost("pais")]
        public async Task<ActionResult<Pais>> CrearPais(Pais pais)
        {
            
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CrearPais", new { id = pais.PaisId }, pais);
                
        }
        
        [HttpPut("pais/{id}")]
        public async Task<ActionResult<Pais>> ActualizarPais(PaisDTO paisAct, int id )
        {
            var pais =  _context.Paises.SingleOrDefault(x => x.PaisId == id);

            if (pais != null)
            {
                _context.Entry(pais).CurrentValues.SetValues(paisAct);
                _context.SaveChanges();
                return CreatedAtAction("ActualizarPais", new { id = pais.PaisId }, pais);
            }

            return NotFound();

        }
        
        
        [HttpDelete("pais/{id}")]
        public async Task<ActionResult<Pais>> BorrarPais(int id )
        {
            var pais =  _context.Paises.SingleOrDefault(x => x.PaisId == id);

            if (pais != null)
            {
                _context.Paises.Remove(pais);
                _context.SaveChanges();
                return CreatedAtAction("BorrarPais", new { message =  "Se ha eliminado el elemento"});
            }

            return NotFound();

        }
        
     
        
        
        #region Regiones

        [HttpGet("regiones")]
        public async Task<ActionResult<List<Region>>> GetRegiones()
        {
            return await _context.Regiones
                        .Include(a => a.Provincias)
                        .ToListAsync();
        }
        
        [HttpGet("region/{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var region =  _context.Regiones.SingleOrDefault(x => x.RegionId == id);

            if (region == null)
            {
                return NotFound();
            }

            return _context.Regiones
                .Where(x => x.RegionId == region.RegionId)
                .Include(b => b.Provincias)
                .FirstOrDefault();
        }

        
        [HttpPost("region")]
        public async Task<ActionResult<Region>> CrearRegion(Region region)
        {
            _context.Regiones.Add(region);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CrearRegion", new { id = region.RegionId }, region);
            
        }
        
        [HttpPut("region/{id}")]
        public async Task<ActionResult<Region>> ActualizarRegion(Region regionAct, int id )
        {
            var region =  _context.Regiones.SingleOrDefault(x => x.RegionId == id);

            if (region != null)
            {
                regionAct.RegionId = region.RegionId;
                _context.Entry(region).CurrentValues.SetValues(regionAct);
                _context.SaveChanges();
                return CreatedAtAction("ActualizarRegion", new { id = region.RegionId }, region);
            }

            return NotFound();
        }
        
        
        [HttpDelete("region/{id}")]
        public async Task<ActionResult<Region>> BorrarRegion(int id )
        {
            var region =  _context.Regiones.SingleOrDefault(x => x.RegionId == id);

            if (region != null)
            {
                _context.Regiones.Remove(region);
                _context.SaveChanges();
                return CreatedAtAction("BorrarRegion", new { message =  "Se ha eliminado el elemento"});
            }

            return NotFound();

        }
        #endregion
        
        
        
        #region PROVINCIAS

        [HttpGet("provincias")]
        public async Task<ActionResult<List<Provincia>>> GetProvincias()
        {
            return await _context.Provincias
                        .Include(x => x.Hotel)
                        .Include(y => y.Region)
                        .ToListAsync();
        }
        
        [HttpGet("provincia/{id}")]
        public async Task<ActionResult<Provincia>> Provincia(int id)
        {
            var provincia =  _context.Provincias.SingleOrDefault(x => x.ProvinciaId == id);

            if (provincia == null)
            {
                return NotFound();
            }

            return _context.Provincias
                .Include("Region")
                .Include("Hotel")
                .FirstOrDefault();
        }

        
        [HttpPost("provincia")]
        public async Task<ActionResult<Region>> CrearProvincia(Provincia provincia)
        {
            _context.Provincias.Add(provincia);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CrearProvincia", new { id = provincia.ProvinciaId }, provincia);
            
        }
        
        [HttpPut("provincia/{id}")]
        public async Task<ActionResult<Provincia>> Provincia(Provincia provinciaAct, int id )
        {
            var provincia =  _context.Provincias.SingleOrDefault(x => x.ProvinciaId == id);

            if (provincia != null)
            {
                provinciaAct.ProvinciaId = provincia.ProvinciaId;
                _context.Entry(provincia).CurrentValues.SetValues(provinciaAct);
                _context.SaveChanges();
                return CreatedAtAction("Provincia", new { id = provincia.ProvinciaId }, provincia);
            }

            return NotFound();
        }
        
        
        [HttpDelete("provincia/{id}")]
        public async Task<ActionResult<Provincia>> BorrarProvincia(int id )
        {
            var provincia =  _context.Provincias.SingleOrDefault(x => x.ProvinciaId == id);

            if (provincia != null)
            {
                _context.Provincias.Remove(provincia);
                _context.SaveChanges();
                return CreatedAtAction("BorrarProvincia", new { message =  "Se ha eliminado el elemento"});
            }

            return NotFound();

        }
        #endregion
        
        

        
    }
}
