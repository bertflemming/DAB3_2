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
    public class AlternativAdressesController : ApiController
    {
        private F184DABH2Gr3Context db = new F184DABH2Gr3Context();

        // GET: api/AlternativAdresses
        public IQueryable<AlternativAdressesDTO> GetAlternativAdresses()
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            List<AlternativAdressesDTO> altAdresses = new List<AlternativAdressesDTO>();
            foreach (var altAdress in uow.Repository.ReadAll())
            {
                altAdresses.Add(new AlternativAdressesDTO(altAdress));
            }
            return altAdresses.AsQueryable();
        }

        // GET: api/AlternativAdresses/5
        [ResponseType(typeof(AlternativAdresses))]
        public IHttpActionResult GetAlternativAdresses(int id)
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            AlternativAdresses alternativAdresses = uow.Repository.Read(id);
            if (alternativAdresses == null)
            {
                return NotFound();
            }

            return Ok(new AlternativAdressesDTO(alternativAdresses));
        }

        // PUT: api/AlternativAdresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlternativAdresses(int id, AlternativAdresses alternativAdresses)
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alternativAdresses.altAdresseId)
            {
                return BadRequest();
            }

            uow.Repository.Update(alternativAdresses);

            try
            {
                uow.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternativAdressesExists(id))
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

        // POST: api/AlternativAdresses
        [ResponseType(typeof(AlternativAdresses))]
        public IHttpActionResult PostAlternativAdresses(AlternativAdresses alternativAdresses)
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.Repository.Create(alternativAdresses);
            uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = alternativAdresses.altAdresseId }, alternativAdresses);
        }

        // DELETE: api/AlternativAdresses/5
        [ResponseType(typeof(AlternativAdresses))]
        public IHttpActionResult DeleteAlternativAdresses(int id)
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            AlternativAdresses alternativAdresses = uow.Repository.Read(id);
            if (alternativAdresses == null)
            {
                return NotFound();
            }

            uow.Repository.Delete(alternativAdresses, id);
            uow.Complete();

            return Ok(alternativAdresses);
        }

        protected override void Dispose(bool disposing)
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlternativAdressesExists(int id)
        {
            var uow = new UnitOfWork<AlternativAdresses>(db);
            return uow.Repository.ReadAll().Count(e => e.altAdresseId == id) > 0;
        }
    }
}