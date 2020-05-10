using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models
{
    public class Accessory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AccessoryCategoryID { get; set; }
        public string GroupName { get; set; }
        public float Price { get; set; }
        [ForeignKey("AccessoryCategoryID")]
        public AccessoryCategory AccessoryCategory { get; set; }
        public List<SaleAccessory> SaleAccessories { get; set; }
    }
}