using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiSelectBsp1.Models
{
    public class Velo
    {
        /*public Velo()
        {
            this.Student = new List<Student>();
        }*/
        public virtual int VeloId { get; set; }
        public virtual string Description { get; set; }

        //public virtual ICollection<Student> Student { get; set; }
    }
}