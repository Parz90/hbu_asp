using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public virtual int ApplicationUserId { get; set; }
        [DisplayName("Beschreibung")]
        public virtual string Description { get; set; }
        [DisplayName("Von")]
        public virtual DateTime From { get; set; }
        [DisplayName("Bis")]
        public virtual DateTime To { get; set; }
        [DisplayName("Abholung")]
        public virtual DateTime Pickup { get; set; }
        [DisplayName("Rückgabe")]
        public virtual DateTime Return { get; set; }
        public virtual Toy Toy { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}