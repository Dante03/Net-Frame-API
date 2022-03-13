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
    public class StudentsController : ApiController
    {
        private dbContexLibrary db = new dbContexLibrary();

        // GET: api/Estudents
        public IQueryable<Estudiante> GetEstudiante()
        {
            return db.Estudiante;
        }

        // GET: api/Estudents/5
        [ResponseType(typeof(Estudiante))]
        public async Task<IHttpActionResult> GetEstudiante(int id)
        {
            Estudiante estudiante = await db.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        // PUT: api/Estudents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.Id_Lector)
            {
                return BadRequest();
            }

            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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

        // POST: api/Estudents
        [ResponseType(typeof(Estudiante))]
        public async Task<IHttpActionResult> PostEstudiante(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estudiante.Add(estudiante);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstudianteExists(estudiante.Id_Lector))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = estudiante.Id_Lector }, estudiante);
        }

        // DELETE: api/Estudents/5
        [ResponseType(typeof(Estudiante))]
        public async Task<IHttpActionResult> DeleteEstudiante(int id)
        {
            Estudiante estudiante = await db.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            db.Estudiante.Remove(estudiante);
            await db.SaveChangesAsync();

            return Ok(estudiante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudianteExists(int id)
        {
            return db.Estudiante.Count(e => e.Id_Lector == id) > 0;
        }
    }
}