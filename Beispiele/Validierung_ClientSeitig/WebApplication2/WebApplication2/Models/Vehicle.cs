using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Vehicle
    {
        public virtual int VehicleId  { get; set; }

        public virtual string Beschreibung { get; set; }
        public virtual int Hubraum { get; set; }
        public virtual int Ps { get; set; }
        public virtual int ColorId { get; set; }
        [Description("Farbe")]
        public virtual Color Color { get; set; }
        
        public virtual int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}