﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> LoadOrder(string orderDate);
        IEnumerable<Order> LoadOrder(string orderDate, int orderNumber);
        void SaveOrder(Order order);
    }
}
