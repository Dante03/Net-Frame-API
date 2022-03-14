using Net_Frame_API.Models;
using Net_Frame_API.Models.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Net_Frame_API.Controllers
{
    public class AutorsController : ApiController
    {
        private dbContexLibrary db = new dbContexLibrary();

        // GET: api/Autors
        public IQueryable<Autor> GetAutor()
        {
            return db.Autor.OrderBy(e => e.Nombre);
        }

        // GET: api/Autors/5
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> GetAutor(int id)
        {
            Autor autor = await db.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        // PUT: api/Autors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutor(int id, Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.Id_Autor)
            {
                return BadRequest();
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autors
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> PostAutor(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Autor');");
            db.Autor.Add(autor);
            await db.SaveChangesAsync();
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutorExists(autor.Id_Autor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autor.Id_Autor }, autor);
        }

        // DELETE: api/Autors/5
        [ResponseType(typeof(Autor))]
        public async Task<IHttpActionResult> DeleteAutor(int id)
        {
            Autor autor = await db.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            db.Autor.Remove(autor);
            await db.SaveChangesAsync();

            return Ok(autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutorExists(int id)
        {
            return db.Autor.Count(e => e.Id_Autor == id) > 0;
        }
    }
}