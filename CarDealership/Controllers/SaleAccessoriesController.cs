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
    public class SaleAccessoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SaleAccessories
        public IQueryable<SaleAccessory> GetSaleAccessories()
        {
            return db.SaleAccessories;
        }

        // GET: api/SaleAccessories/5
        [ResponseType(typeof(SaleAccessory))]
        public IHttpActionResult GetSaleAccessory(int id)
        {
            SaleAccessory saleAccessory = db.SaleAccessories.Find(id);
            if (saleAccessory == null)
            {
                return NotFound();
            }

            return Ok(saleAccessory);
        }

        // PUT: api/SaleAccessories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSaleAccessory(int id, SaleAccessory saleAccessory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saleAccessory.ID)
            {
                return BadRequest();
            }

            db.Entry(saleAccessory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleAccessoryExists(id))
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

        // POST: api/SaleAccessories
        [ResponseType(typeof(SaleAccessory))]
        public IHttpActionResult PostSaleAccessory(SaleAccessory saleAccessory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SaleAccessories.Add(saleAccessory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = saleAccessory.ID }, saleAccessory);
        }

        // DELETE: api/SaleAccessories/5
        [ResponseType(typeof(SaleAccessory))]
        public IHttpActionResult DeleteSaleAccessory(int id)
        {
            SaleAccessory saleAccessory = db.SaleAccessories.Find(id);
            if (saleAccessory == null)
            {
                return NotFound();
            }

            db.SaleAccessories.Remove(saleAccessory);
            db.SaveChanges();

            return Ok(saleAccessory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleAccessoryExists(int id)
        {
            return db.SaleAccessories.Count(e => e.ID == id) > 0;
        }
    }
}