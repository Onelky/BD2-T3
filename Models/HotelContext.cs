using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ejemplo.Models;



namespace ejemplo.Models
{
   public class HotelContext: DbContext
   {
       public HotelContext(DbContextOptions<HotelContext> options): base(options){

       }

       public DbSet<Persona> Personas {set;get;}
       public DbSet<Rol> Roles {set;get;}
       public DbSet<Pais> Paises  {set;get;}
       public DbSet<Region> Regiones  {set;get;}
       public DbSet<Provincia> Provincias  {set;get;}
       public DbSet<Edificio> Edificios   {set;get;}
       public DbSet<Hotel> Hoteles  {set;get;}
       public DbSet<Pago> Pagos   {set;get;}
       public DbSet<Reservacion> Reservaciones {set;get;}
       public DbSet<TipoPlan> TipoPlanes {set;get;}

   }
   
}