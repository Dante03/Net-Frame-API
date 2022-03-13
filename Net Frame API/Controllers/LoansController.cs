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
    public class LoansController : ApiController
    {
        private dbContexLibrary db = new dbContexLibrary();

        // GET: api/Loans
        public IQueryable<Prestamo> GetPrestamo()
        {
            var loan = db.Prestamo.AsNoTracking()
                .Include(e => e.Estudiante)
                .Include(e => e.Libro);
            return loan;
        }

        // GET: api/Loans/5
        [ResponseType(typeof(Prestamo))]
        public async Task<IHttpActionResult> GetPrestamo(int id)
        {
            Prestamo prestamo = await db.Prestamo.AsNoTracking()
                .Include(e => e.Estudiante)
                .Include(e => e.Libro)
                .FirstOrDefaultAsync(e => e.Id_Prestamo == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }

        // PUT: api/Loans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.Id_Prestamo)
            {
                return BadRequest();
            }
            db.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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

        // POST: api/Loans
        [ResponseType(typeof(Prestamo))]
        public async Task<IHttpActionResult> PostPrestamo(Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestamo.Add(prestamo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = prestamo.Id_Prestamo }, prestamo);
        }

        // DELETE: api/Loans/5
        [ResponseType(typeof(Prestamo))]
        public async Task<IHttpActionResult> DeletePrestamo(int id)
        {
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            db.Prestamo.Remove(prestamo);
            await db.SaveChangesAsync();

            return Ok(prestamo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestamoExists(int id)
        {
            return db.Prestamo.Count(e => e.Id_Prestamo == id) > 0;
        }
    }
}