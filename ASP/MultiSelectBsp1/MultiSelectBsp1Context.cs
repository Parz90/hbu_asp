using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class MultiSelectBsp1Context : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public MultiSelectBsp1Context() : base("name=MultiSelectBsp1Context")
    {
    }

    public System.Data.Entity.DbSet<MultiSelectBsp1.Models.Student> Students { get; set; }

    public System.Data.Entity.DbSet<MultiSelectBsp1.Models.Velo> Veloes { get; set; }
}
