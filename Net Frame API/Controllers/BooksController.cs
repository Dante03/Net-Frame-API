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
    public class BooksController : ApiController
    {
        private dbContexLibrary db = new dbContexLibrary();

        // GET: api/Books
        public IQueryable<Libro> GetLibro()
        {
            return db.Libro;
        }

        // GET: api/Books/5
        [ResponseType(typeof(Libro))]
        public async Task<IHttpActionResult> GetLibro(int id)
        {
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLibro(int id, Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libro.Id_Libro)
            {
                return BadRequest();
            }

            db.Entry(libro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Libro))]
        public async Task<IHttpActionResult> PostLibro(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Libro');");
            db.Libro.Add(libro);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibroExists(libro.Id_Libro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = libro.Id_Libro }, libro);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Libro))]
        public async Task<IHttpActionResult> DeleteLibro(int id)
        {
            Libro libro = await db.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            db.Libro.Remove(libro);
            await db.SaveChangesAsync();

            return Ok(libro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibroExists(int id)
        {
            return db.Libro.Count(e => e.Id_Libro == id) > 0;
        }
    }
}