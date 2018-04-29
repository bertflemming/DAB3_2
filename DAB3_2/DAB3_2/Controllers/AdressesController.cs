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
    public class AdressesController : ApiController
    {
        private F184DABH2Gr3Context db = new F184DABH2Gr3Context();

        // GET: api/Adresses
        public IQueryable<AdressesDTO> GetAdresses()
        {
            var uow = new UnitOfWork<Adresses>(db);
            List<AdressesDTO> adresses = new List<AdressesDTO>();
            foreach (var adress in uow.Repository.ReadAll())
            {
                adresses.Add(new AdressesDTO(adress));
            }
            return adresses.AsQueryable();
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(Adresses))]
        public IHttpActionResult GetAdresses(int id)
        {
            var uow = new UnitOfWork<Adresses>(db);
            Adresses adresses = uow.Repository.Read(id);
            if (adresses == null)
            {
                return NotFound();
            }

            return Ok(new AdressesDTO(adresses));
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdresses(int id, Adresses adresses)
        {
            var uow = new UnitOfWork<Adresses>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresses.adresseId)
            {
                return BadRequest();
            }

            uow.Repository.Update(adresses);

            try
            {
                uow.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressesExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adresses))]
        public IHttpActionResult PostAdresses(Adresses adresses)
        {
            var uow = new UnitOfWork<Adresses>(db);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.Repository.Create(adresses);
            uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = adresses.adresseId }, adresses);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adresses))]
        public IHttpActionResult DeleteAdresses(int id)
        {
            var uow = new UnitOfWork<Adresses>(db);
            Adresses adresses = uow.Repository.Read(id);
            if (adresses == null)
            {
                return NotFound();
            }

            uow.Repository.Delete(adresses, id);
            uow.Complete();

            return Ok(adresses);
        }

        protected override void Dispose(bool disposing)
        {
            var uow = new UnitOfWork<Adresses>(db);
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdressesExists(int id)
        {
            var uow = new UnitOfWork<Adresses>(db);
            return uow.Repository.ReadAll().Count(e => e.adresseId == id) > 0;
        }
    }
}