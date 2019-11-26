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
    public class VentaEncabezadoesController : ApiController
    {
        private INVENTARIOEntities db = new INVENTARIOEntities();

        // GET: api/VentaEncabezadoes
        public IQueryable<VentaEncabezado> GetVentaEncabezado()
        {
            return db.VentaEncabezado;
        }

        // GET: api/VentaEncabezadoes/5
        [ResponseType(typeof(VentaEncabezado))]
        public IHttpActionResult GetVentaEncabezado(int id)
        {
            VentaEncabezado ventaEncabezado = db.VentaEncabezado.Find(id);
            if (ventaEncabezado == null)
            {
                return NotFound();
            }

            return Ok(ventaEncabezado);
        }

        // PUT: api/VentaEncabezadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVentaEncabezado(int id, VentaEncabezado ventaEncabezado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventaEncabezado.IdVentaEncabezado)
            {
                return BadRequest();
            }

            db.Entry(ventaEncabezado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaEncabezadoExists(id))
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

        // POST: api/VentaEncabezadoes
        [ResponseType(typeof(VentaEncabezado))]
        public IHttpActionResult PostVentaEncabezado(VentaEncabezado ventaEncabezado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VentaEncabezado.Add(ventaEncabezado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ventaEncabezado.IdVentaEncabezado }, ventaEncabezado);
        }

        // DELETE: api/VentaEncabezadoes/5
        [ResponseType(typeof(VentaEncabezado))]
        public IHttpActionResult DeleteVentaEncabezado(int id)
        {
            VentaEncabezado ventaEncabezado = db.VentaEncabezado.Find(id);
            if (ventaEncabezado == null)
            {
                return NotFound();
            }

            db.VentaEncabezado.Remove(ventaEncabezado);
            db.SaveChanges();

            return Ok(ventaEncabezado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentaEncabezadoExists(int id)
        {
            return db.VentaEncabezado.Count(e => e.IdVentaEncabezado == id) > 0;
        }
    }
}