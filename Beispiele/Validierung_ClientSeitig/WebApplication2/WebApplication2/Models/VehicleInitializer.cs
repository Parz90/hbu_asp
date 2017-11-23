using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class VehicleInitializer : CreateDatabaseIfNotExists<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            IList<Color> defaultColors = new List<Color>();

            defaultColors.Add(new Color() { Name = "Schwarz" });
            defaultColors.Add(new Color() { Name = "Weiss" });
            defaultColors.Add(new Color() { Name = "Blau" });

            context.Colors.AddRange(defaultColors);

            IList<Vendor> defaultVendors = new List<Vendor>();

            defaultVendors.Add(new Vendor () { Name = "Audi" });
            defaultVendors.Add(new Vendor() { Name = "BMW" });
            defaultVendors.Add(new Vendor() { Name = "Mecedes" });

            context.Vendors.AddRange(defaultVendors);

            base.Seed(context);
        }
    }
}