using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models
{
    public class SaleAccessory
    {
        public int ID { get; set; }
        public int SaleID { get; set; }
        public int AccessoryID { get; set; }
        public float Price { get; set; }
        [ForeignKey("SaleID")]
        public Sale Sale { get; set; }
        [ForeignKey("AccessoryID")]
        public Accessory Accessory { get; set; }       
    }
}