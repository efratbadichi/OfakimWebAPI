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
    public class UsersController : ApiController
    {
        private OfakimDBEntities db = new OfakimDBEntities();

        // GET: api/Users
        public IQueryable<tblUsers> GettblUsers()
        {
            return db.tblUsers;
        }

        // GET: api/Users/5
        [ResponseType(typeof(tblUsers))]
        public IHttpActionResult GettblUsers(decimal id)
        {
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return NotFound();
            }

            return Ok(tblUsers);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblUsers(decimal id, tblUsers tblUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUsers.Id)
            {
                return BadRequest();
            }

            db.Entry(tblUsers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblUsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(tblUsers))]
        public IHttpActionResult PosttblUsers(tblUsers tblUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblUsers.Add(tblUsers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblUsers.Id }, tblUsers);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(tblUsers))]
        public IHttpActionResult DeletetblUsers(decimal id)
        {
            tblUsers tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return NotFound();
            }

            db.tblUsers.Remove(tblUsers);
            db.SaveChanges();

            return Ok(tblUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblUsersExists(decimal id)
        {
            return db.tblUsers.Count(e => e.Id == id) > 0;
        }
    }
}