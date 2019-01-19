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
using OfakimAPI;

namespace OfakimAPI.Controllers
{
    public class GenderController : ApiController
    {
        private OfakimDBEntities db = new OfakimDBEntities();

        // GET: api/Gender
        public IQueryable<tblGender> GettblGender()
        {
            return db.tblGender;
        }

        // GET: api/Gender/5
        [ResponseType(typeof(tblGender))]
        public IHttpActionResult GettblGender(decimal id)
        {
            tblGender tblGender = db.tblGender.Find(id);
            if (tblGender == null)
            {
                return NotFound();
            }

            return Ok(tblGender);
        }

        // PUT: api/Gender/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblGender(decimal id, tblGender tblGender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblGender.typeCode)
            {
                return BadRequest();
            }

            db.Entry(tblGender).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGenderExists(id))
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

        // POST: api/Gender
        [ResponseType(typeof(tblGender))]
        public IHttpActionResult PosttblGender(tblGender tblGender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblGender.Add(tblGender);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblGenderExists(tblGender.typeCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblGender.typeCode }, tblGender);
        }

        // DELETE: api/Gender/5
        [ResponseType(typeof(tblGender))]
        public IHttpActionResult DeletetblGender(decimal id)
        {
            tblGender tblGender = db.tblGender.Find(id);
            if (tblGender == null)
            {
                return NotFound();
            }

            db.tblGender.Remove(tblGender);
            db.SaveChanges();

            return Ok(tblGender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblGenderExists(decimal id)
        {
            return db.tblGender.Count(e => e.typeCode == id) > 0;
        }
    }
}