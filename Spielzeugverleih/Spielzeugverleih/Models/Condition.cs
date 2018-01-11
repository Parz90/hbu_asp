using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public class Condition
    {
        public virtual int ConditionId { get; set; }
        public virtual string Description { get; set; }
    }
}