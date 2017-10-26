using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiSelectBsp1.Models
{
    public class Student
    {
        /*public Student()
        {
            this.Velo = new List<Velo>();
        }*/
        public virtual int StudentID { get; set; }
        public virtual string Name { get; set; }
        //public virtual ICollection<Velo> Velo {get; set; }

    }
}