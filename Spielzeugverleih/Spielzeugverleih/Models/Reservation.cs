using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public class Reservation
    {
        public virtual int ReservationId { get; set; }
        [DisplayName("Toy")]
        public virtual int ToyId { get; set; }
        [DisplayName("User")]
        [ForeignKey("ApplicationUser")]
        public virtual string ApplicationUserId { get; set; }
        public virtual string Description { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime From { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime To { get; set; }
        public virtual string State { get; set; }
        public virtual Toy Toy { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}