using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training1_Diary.Models
{
    public class DiaryEntry
    {
        public virtual int DiaryEntryId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Date { get; set; }
        public virtual string Entry1 { get; set; }
        public virtual string Entry2 { get; set; }
        public virtual string Entry3 { get; set; }
        public virtual string Category { get; set; }
    }
}