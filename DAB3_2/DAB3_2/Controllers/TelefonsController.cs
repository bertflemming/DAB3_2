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
using DAB3_2;
using DAB3_2.Models;

namespace DAB3_2.Controllers
{
    public class TelefonsController : ApiController
    {
        private F184DABH2Gr3Context db = new F184DABH2Gr3Context();

        // GET: api/Telefons
        public IQueryable<TelefonsDTO> GetTelefons()
        {
            var uow = new UnitOfWork<Telefons>(db);
            List<TelefonsDTO> telefoner = new List<TelefonsDTO>();
            foreach (var telefon in uow.Repository.ReadAll())
            {
                telefoner.Add(new TelefonsDTO(telefon));
            }
            return telefoner.AsQueryable();
        }

        // GET: api/Telefons/5
        [ResponseType(typeof(Telefons))]
        public IHttpActionResult GetTelefons(int id)
        {
            var uow = new UnitOfWork<Telefons>(db);
            Telefons telefons = uow.Repository.Read(id);
            if (telefons == null)
            {
                return NotFound();
            }

            return Ok(new TelefonsDTO(telefons));
        }

        // PUT: api/Telefons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefons(int id, Telefons telefons)
        {
            var uow = new UnitOfWork<Telefons>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefons.telefonId)
            {
                return BadRequest();
            }

            uow.Repository.Update(telefons);

            try
            {
                uow.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonsExists(id))
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

        // POST: api/Telefons
        [ResponseType(typeof(Telefons))]
        public IHttpActionResult PostTelefons(Telefons telefons)
        {
            var uow = new UnitOfWork<Telefons>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.Repository.Create(telefons);
            uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = telefons.telefonId }, telefons);
        }

        // DELETE: api/Telefons/5
        [ResponseType(typeof(Telefons))]
        public IHttpActionResult DeleteTelefons(int id)
        {
            var uow = new UnitOfWork<Telefons>(db);
            Telefons telefons = uow.Repository.Read(id);
            if (telefons == null)
            {
                return NotFound();
            }

            uow.Repository.Delete(telefons, id);
            uow.Complete();

            return Ok(telefons);
        }

        protected override void Dispose(bool disposing)
        {
            var uow = new UnitOfWork<Telefons>(db);
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonsExists(int id)
        {
            var uow = new UnitOfWork<Telefons>(db);
            return uow.Repository.ReadAll().Count(e => e.telefonId == id) > 0;
        }
    }
}