﻿using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class PaymentDto
    {
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}
