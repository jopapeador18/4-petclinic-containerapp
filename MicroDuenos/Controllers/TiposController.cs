using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NetclinicWebApi.Helpers;
using NetclinicWebApi.Models;

namespace NetclinicWebApi.Controllers
{
    public class TiposController : ApiController
    {
        private static SqlHelper sqlHelper = new SqlHelper();
        private AzureSQLPetclinicEntities1 db = new AzureSQLPetclinicEntities1(sqlHelper.BuildEFConnection(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")));

        // GET: api/Tipos
        public IQueryable<Tipo> GetTipoes()
        {
            return db.Tipoes;
        }

        // GET: api/Tipos/5
        [ResponseType(typeof(Tipo))]
        public async Task<IHttpActionResult> GetTipo(int id)
        {
            Tipo tipo = await db.Tipoes.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            return Ok(tipo);
        }

        // PUT: api/Tipos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipo(int id, Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo.Tipo_Id)
            {
                return BadRequest();
            }

            db.Entry(tipo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        // POST: api/Tipos
        [ResponseType(typeof(Tipo))]
        public async Task<IHttpActionResult> PostTipo(Tipo tipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipoes.Add(tipo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipo.Tipo_Id }, tipo);
        }

        // DELETE: api/Tipos/5
        [ResponseType(typeof(Tipo))]
        public async Task<IHttpActionResult> DeleteTipo(int id)
        {
            Tipo tipo = await db.Tipoes.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            db.Tipoes.Remove(tipo);
            await db.SaveChangesAsync();

            return Ok(tipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoExists(int id)
        {
            return db.Tipoes.Count(e => e.Tipo_Id == id) > 0;
        }
    }
}