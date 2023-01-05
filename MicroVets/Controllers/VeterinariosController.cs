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
using MicroVets.Helpers;
using MicroVets.Models;

namespace MicroVets.Controllers
{
    public class VeterinariosController : ApiController
    {
        private static SqlHelper sqlHelper = new SqlHelper();
        private AzureSQLPetclinicEntities1 db = new AzureSQLPetclinicEntities1(sqlHelper.BuildEFConnection(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")));

        // GET: api/Veterinarios
        public IQueryable<Veterinario> GetVeterinarios()
        {
            return db.Veterinarios;
        }

        // GET: api/Veterinarios/5
        [ResponseType(typeof(Veterinario))]
        public IHttpActionResult GetVeterinario(int id)
        {
            Veterinario veterinario = db.Veterinarios.Find(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return Ok(veterinario);
        }

        // PUT: api/Veterinarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVeterinario(int id, Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veterinario.Veterinario_Id)
            {
                return BadRequest();
            }

            db.Entry(veterinario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(id))
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

        // POST: api/Veterinarios
        [ResponseType(typeof(Veterinario))]
        public IHttpActionResult PostVeterinario(Veterinario veterinario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veterinarios.Add(veterinario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = veterinario.Veterinario_Id }, veterinario);
        }

        // DELETE: api/Veterinarios/5
        [ResponseType(typeof(Veterinario))]
        public IHttpActionResult DeleteVeterinario(int id)
        {
            Veterinario veterinario = db.Veterinarios.Find(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            db.Veterinarios.Remove(veterinario);
            db.SaveChanges();

            return Ok(veterinario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeterinarioExists(int id)
        {
            return db.Veterinarios.Count(e => e.Veterinario_Id == id) > 0;
        }
    }
}