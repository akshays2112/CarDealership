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
    public class AccessoryCategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AccessoryCategories
        public IQueryable<AccessoryCategory> GetAccessoryCategories()
        {
            return db.AccessoryCategories;
        }

        // GET: api/AccessoryCategories/5
        [ResponseType(typeof(AccessoryCategory))]
        public IHttpActionResult GetAccessoryCategory(int id)
        {
            AccessoryCategory accessoryCategory = db.AccessoryCategories.Find(id);
            if (accessoryCategory == null)
            {
                return NotFound();
            }

            return Ok(accessoryCategory);
        }

        // PUT: api/AccessoryCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccessoryCategory(int id, AccessoryCategory accessoryCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accessoryCategory.ID)
            {
                return BadRequest();
            }

            db.Entry(accessoryCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessoryCategoryExists(id))
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

        // POST: api/AccessoryCategories
        [ResponseType(typeof(AccessoryCategory))]
        public IHttpActionResult PostAccessoryCategory(AccessoryCategory accessoryCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccessoryCategories.Add(accessoryCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accessoryCategory.ID }, accessoryCategory);
        }

        // DELETE: api/AccessoryCategories/5
        [ResponseType(typeof(AccessoryCategory))]
        public IHttpActionResult DeleteAccessoryCategory(int id)
        {
            AccessoryCategory accessoryCategory = db.AccessoryCategories.Find(id);
            if (accessoryCategory == null)
            {
                return NotFound();
            }

            db.AccessoryCategories.Remove(accessoryCategory);
            db.SaveChanges();

            return Ok(accessoryCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccessoryCategoryExists(int id)
        {
            return db.AccessoryCategories.Count(e => e.ID == id) > 0;
        }
    }
}