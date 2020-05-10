using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class AccessoryCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Accessory> Accessories { get; set; }
    }
}