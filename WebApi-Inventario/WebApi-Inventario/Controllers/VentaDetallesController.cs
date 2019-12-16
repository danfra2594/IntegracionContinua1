using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_Inventario.Models;

namespace WebApi_Inventario.Controllers
{
    public class VentaDetallesController : ApiController
    {
        private INVENTARIOEntities db = new INVENTARIOEntities();

        // GET: api/VentaDetalles
        public IQueryable<VentaDetalle> GetVentaDetalle()
        {
            return db.VentaDetalle;
        }

        // GET: api/VentaDetalles/5
        [ResponseType(typeof(VentaDetalle))]
        public IHttpActionResult GetVentaDetalle(int id)
        {
            VentaDetalle ventaDetalle = db.VentaDetalle.Find(id);
            if (ventaDetalle == null)
            {
                return NotFound();
            }

            return Ok(ventaDetalle);
        }

        // PUT: api/VentaDetalles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVentaDetalle(int id, VentaDetalle ventaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventaDetalle.IdVentaDetalle)
            {
                return BadRequest();
            }

            db.Entry(ventaDetalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaDetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VentaDetalles
        [ResponseType(typeof(VentaDetalle))]
        public IHttpActionResult PostVentaDetalle(VentaDetalle ventaDetalle)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            ventaDetalle.Fecha = DateTime.Now; //Registro fecha servidor
            db.VentaDetalle.Add(ventaDetalle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ventaDetalle.IdVentaDetalle }, ventaDetalle);
        }

        // DELETE: api/VentaDetalles/5
        [ResponseType(typeof(VentaDetalle))]
        public IHttpActionResult DeleteVentaDetalle(int id)
        {
            VentaDetalle ventaDetalle = db.VentaDetalle.Find(id);
            if (ventaDetalle == null)
            {
                return NotFound();
            }

            db.VentaDetalle.Remove(ventaDetalle);
            db.SaveChanges();

            return Ok(ventaDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentaDetalleExists(int id)
        {
            return db.VentaDetalle.Count(e => e.IdVentaDetalle == id) > 0;
        }
    }
}