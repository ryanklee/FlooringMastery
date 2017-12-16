﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models.Responses
{
    public class OrderAddResponse : Response
    {
        public Order Order { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<Product> Products { get; set; }
    }
}