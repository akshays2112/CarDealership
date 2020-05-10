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
    public class AccessoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Accessories
        public IQueryable<Accessory> GetAccessories()
        {
            return db.Accessories;
        }

        // GET: api/Accessories/5
        [ResponseType(typeof(Accessory))]
        public IHttpActionResult GetAccessory(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return NotFound();
            }

            return Ok(accessory);
        }

        // PUT: api/Accessories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccessory(int id, Accessory accessory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accessory.ID)
            {
                return BadRequest();
            }

            db.Entry(accessory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessoryExists(id))
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

        // POST: api/Accessories
        [ResponseType(typeof(Accessory))]
        public IHttpActionResult PostAccessory(Accessory accessory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accessories.Add(accessory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accessory.ID }, accessory);
        }

        // DELETE: api/Accessories/5
        [ResponseType(typeof(Accessory))]
        public IHttpActionResult DeleteAccessory(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return NotFound();
            }

            db.Accessories.Remove(accessory);
            db.SaveChanges();

            return Ok(accessory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccessoryExists(int id)
        {
            return db.Accessories.Count(e => e.ID == id) > 0;
        }
    }
}