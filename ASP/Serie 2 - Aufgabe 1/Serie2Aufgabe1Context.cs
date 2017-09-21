using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class Serie2Aufgabe1Context : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public Serie2Aufgabe1Context() : base("name=Serie2Aufgabe1Context")
    {
    }

    public System.Data.Entity.DbSet<Serie_2___Aufgabe_1.Models.Fahrzeug> Fahrzeugs { get; set; }
}
