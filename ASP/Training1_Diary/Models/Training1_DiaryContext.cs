using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Training1_Diary.Models
{
    public class Training1_DiaryContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Training1_DiaryContext() : base("name=Training1_DiaryContext")
        {
        }

        public System.Data.Entity.DbSet<Training1_Diary.Models.DiaryCategory> DiaryCategories { get; set; }

        public System.Data.Entity.DbSet<Training1_Diary.Models.DiaryEntry> DiaryEntries { get; set; }
    }
}
