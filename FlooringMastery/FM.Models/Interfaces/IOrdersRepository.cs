using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> LoadOrders(string orderDate);
        void SaveOrder(Order order);
        void DeleteOrder(Order order);
    }
}
