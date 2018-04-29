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
using System.Web.UI.WebControls.WebParts;
using DAB3_2;
using DAB3_2.Models;

namespace DAB3_2.Controllers
{
    public class PeopleController : ApiController
    {
        private F184DABH2Gr3Context db = new F184DABH2Gr3Context();

        // GET: api/People
        public IQueryable<PeopleDTO> GetPeople()
        {
            var uow = new UnitOfWork<People>(db);
            List<PeopleDTO> people = new List<PeopleDTO>();
            foreach (var person in uow.Repository.ReadAll())
            {
                people.Add(new PeopleDTO(person));
            }
            return people.AsQueryable();
        }

        // GET: api/People/5
        [ResponseType(typeof(People))]
        public IHttpActionResult GetPeople(int id)
        {
            var uow = new UnitOfWork<People>(db);
            People people = uow.Repository.Read(id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(new PeopleDTO(people));
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeople(int id, People people)
        {
            var uow = new UnitOfWork<People>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != people.personId)
            {
                return BadRequest();
            }

            uow.Repository.Update(people);

            try
            {
                uow.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
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

        // POST: api/People
        [ResponseType(typeof(People))]
        public IHttpActionResult PostPeople(People people)
        {
            var uow = new UnitOfWork<People>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.Repository.Create(people);
            uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = people.personId }, people);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(People))]
        public IHttpActionResult DeletePeople(int id)
        {
            var uow = new UnitOfWork<People>(db);
            People people = uow.Repository.Read(id);
            if (people == null)
            {
                return NotFound();
            }

            uow.Repository.Delete(people, id);
            uow.Complete();

            return Ok(people);
        }

        protected override void Dispose(bool disposing)
        {
            var uow = new UnitOfWork<People>(db);
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleExists(int id)
        {
            var uow = new UnitOfWork<People>(db);
            return uow.Repository.ReadAll().Count(e => e.personId == id) > 0;
        }
    }
}