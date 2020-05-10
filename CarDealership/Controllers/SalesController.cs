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
    public class SalesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Sales
        public IQueryable<Sale> GetSales()
        {
            return db.Sales;
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult GetSale(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSale(int id, int oldCarID, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.ID)
            {
                return BadRequest();
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                if (sale.CarID != oldCarID)
                {
                    Car oldCar = db.Cars.Find(oldCarID);
                    oldCar.Quantity++;
                    db.Entry(oldCar).State = EntityState.Modified;
                }
                Car newCar = db.Cars.Find(sale.CarID);
                newCar.Quantity--;
                db.Entry(newCar).State = EntityState.Modified;
            }
            catch (DBConcurrencyException)
            {
                if (db.Cars.Count(e => e.ID == oldCarID) == 0 || db.Cars.Count(e => e.ID == sale.CarID) == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        [ResponseType(typeof(Sale))]
        public IHttpActionResult PostSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Car newCar = db.Cars.Find(sale.CarID);
            newCar.Quantity--;
            db.Entry(newCar).State = EntityState.Modified;
            db.Sales.Add(sale);
            db.SaveChanges();

            ReturnSale rsale = new ReturnSale();
            rsale.ID = sale.ID;

            return CreatedAtRoute("DefaultApi", new { id = sale.ID }, rsale);
        }

        public class ReturnSale { public int ID; }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult DeleteSale(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            Sale oldSale = db.Sales.Find(id);
            Car car = db.Cars.Find(oldSale.CarID);
            car.Quantity++;
            db.Entry(car).State = EntityState.Modified;
            db.Sales.Remove(sale);
            db.SaveChanges();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sales.Count(e => e.ID == id) > 0;
        }
    }
}
