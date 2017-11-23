using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class VehicleContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VehicleContext() : base("name=VehicleContext")
        {
            Database.SetInitializer(new VehicleInitializer());
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Vehicle> Vehicles { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.User2> User2 { get; set; }
    }
}
