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
        [DisplayName("Spielzeug")]
        public virtual int ToyId { get; set; }
        [DisplayName("Benutzer")]
        [ForeignKey("ApplicationUser")]
        public virtual string ApplicationUserId { get; set; }
        [DisplayName("Beschreibung")]
        public virtual string Description { get; set; }
        [DisplayName("Von")]
        [DataType(DataType.Date)]
        public virtual DateTime From { get; set; }
        [DisplayName("Bis")]
        [DataType(DataType.Date)]
        public virtual DateTime To { get; set; }
        [DisplayName("Abholung")]
        [DataType(DataType.Date)]
        public virtual DateTime Pickup { get; set; }
        [DisplayName("Rückgabe")]
        [DataType(DataType.Date)]
        public virtual DateTime Return { get; set; }
        public virtual Toy Toy { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}