using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsBookingSystem.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Code { get; set; }
        public double Cash { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}