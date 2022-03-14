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
    public class CountersController : ApiController
    {
        private dbContexLibrary db = new dbContexLibrary();

        // GET: api/Counters
        public IQueryable<Mostrador> GetMostradors()
        {
            var counter = db.Counter.AsNoTracking()
                .Include(e => e.Libro)
                .Include(e => e.Autor)
                .OrderBy(e => e.Libro.Titulo);

            //var counter = db.Counter;
            return counter;
        }

        // GET: api/Counters/5
        [ResponseType(typeof(Mostrador))]
        public async Task<IHttpActionResult> GetMostrador(int id)
        {
            Mostrador counter = await db.Counter.AsNoTracking()
                .Include(e => e.Autor)
                .Include(e => e.Libro)
                .FirstOrDefaultAsync(e => e.Id_LibAut == id);

            if (counter == null)
            {
                return NotFound();
            }

            return Ok(counter);
        }

        // PUT: api/Counters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMostrador(int id, Mostrador mostrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mostrador.Id_LibAut)
            {
                return BadRequest();
            }

            db.Entry(mostrador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MostradorExists(id))
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

        // POST: api/Counters
        [ResponseType(typeof(Mostrador))]
        public async Task<IHttpActionResult> PostMostrador(Mostrador mostrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('LibAut');");
            db.Counter.Add(mostrador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mostrador.Id_LibAut }, mostrador);
        }

        // DELETE: api/Counters/5
        [ResponseType(typeof(Mostrador))]
        public async Task<IHttpActionResult> DeleteMostrador(int id)
        {
            Mostrador mostrador = await db.Counter.FindAsync(id);
            if (mostrador == null)
            {
                return NotFound();
            }

            db.Counter.Remove(mostrador);
            await db.SaveChangesAsync();

            return Ok(mostrador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MostradorExists(int id)
        {
            return db.Counter.Count(e => e.Id_LibAut == id) > 0;
        }
    }
}