using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public interface IOrdersRepository
    {
        void LoadAllOrders();
        List<Order> LoadOrder(string orderDate);
        Order AddOrder();
        Order EditOrder();
        Order SaveOrder();
    }
}
