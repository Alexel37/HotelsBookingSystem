﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsBookingSystem.Models.CreditCardsModels
{
    public class CreditCardGetModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public double Cash { get; set; }
    }
}
