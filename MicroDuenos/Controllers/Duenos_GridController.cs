using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
    public class Duenos_GridController : ApiController
    {
        private static SqlHelper sqlHelper = new SqlHelper();
        private AzureSQLPetclinicEntities1 db = new AzureSQLPetclinicEntities1(sqlHelper.BuildEFConnection(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")));
        //sqlHelper.BuildEntityConnectionStringFromAppSettings(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING").Substring(1, Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING").Length-2))

        // GET: api/Duenos_Grid
        public IQueryable<Duenos_Grid> GetDuenos_Grid()
        {
            return db.Duenos_Grid;
        }

        // GET: api/Duenos_Grid/5
        [ResponseType(typeof(Duenos_Grid))]
        public async Task<IHttpActionResult> GetDuenos_Grid(int id)
        {
            Duenos_Grid duenos_Grid = await db.Duenos_Grid.FindAsync(id);
            if (duenos_Grid == null)
            {
                return NotFound();
            }

            return Ok(duenos_Grid);
        }

        // PUT: api/Duenos_Grid/5
        [ResponseType(typeof(Dueno))]
        public async Task<IHttpActionResult> PutDuenos_Grid(int id, Dueno dueno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dueno.Dueno_Id)
            {
                return BadRequest();
            }

            db.Entry(dueno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!Duenos_GridExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dueno);
        }

        // POST: api/Duenos_Grid
        [ResponseType(typeof(Dueno))]
        public async Task<IHttpActionResult> PostDuenos_Grid(Dueno duenos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Duenoes.Add(duenos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = duenos.Dueno_Id }, duenos);
        }

        // DELETE: api/Duenos_Grid/5
        [ResponseType(typeof(Dueno))]
        public async Task<IHttpActionResult> DeleteDuenos_Grid(int id)
        {
            Dueno dueno = await db.Duenoes.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }

            List<Mascota> mascotasEliminar = db.Mascotas.Where(m => m.Dueno_Id == dueno.Dueno_Id).ToList();
            //Paso 1, Eliminar Visitas registradas.

            //Paso 2, Eliminar Mascotas.
            db.Mascotas.RemoveRange(mascotasEliminar);

            //Paso 3, Eliminar dueno.
            db.Duenoes.Remove(dueno);
            
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }

            return Ok(dueno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Duenos_GridExists(int id)
        {
            return db.Duenos_Grid.Count(e => e.Dueno_Id == id) > 0;
        }
    }
}