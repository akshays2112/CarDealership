using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Salesman
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public float CommissionPercentage { get; set; }
        public DateTime Joined { get; set; }
        public DateTime Resigned { get; set; }
        public List<Sale> Sales { get; set; }
    }
}