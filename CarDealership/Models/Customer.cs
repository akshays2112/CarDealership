using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime AddedOn { get; set; }
        public List<Sale> Sales { get; set; }
    }
}