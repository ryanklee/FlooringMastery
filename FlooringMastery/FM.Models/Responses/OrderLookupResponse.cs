﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models.Responses
{
    public class OrderLookupResponse : Response
    {
        public IEnumerable<Order> Order { get; set; }
    }
}
