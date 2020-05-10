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
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class SalesmenController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Salesmen
        public IQueryable<Salesman> GetSalesmen()
        {
            return db.Salesmen;
        }

        // GET: api/Salesmen/5
        [ResponseType(typeof(Salesman))]
        public IHttpActionResult GetSalesman(int id)
        {
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return NotFound();
            }

            return Ok(salesman);
        }

        // PUT: api/Salesmen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesman(int id, Salesman salesman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesman.ID)
            {
                return BadRequest();
            }

            db.Entry(salesman).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesmanExists(id))
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

        // POST: api/Salesmen
        [ResponseType(typeof(Salesman))]
        public IHttpActionResult PostSalesman(Salesman salesman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salesmen.Add(salesman);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = salesman.ID }, salesman);
        }

        // DELETE: api/Salesmen/5
        [ResponseType(typeof(Salesman))]
        public IHttpActionResult DeleteSalesman(int id)
        {
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return NotFound();
            }

            db.Salesmen.Remove(salesman);
            db.SaveChanges();

            return Ok(salesman);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesmanExists(int id)
        {
            return db.Salesmen.Count(e => e.ID == id) > 0;
        }
    }
}