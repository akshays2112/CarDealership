using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public int SalesmanID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public float Price { get; set; }
        public DateTime SaleDate { get; set; }
        [ForeignKey("SalesmanID")]
        public Salesman Salesman { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        [ForeignKey("CarID")]
        public Car Car { get; set; }
        public List<SaleAccessory> SaleAccessories { get; set; }
    }
}