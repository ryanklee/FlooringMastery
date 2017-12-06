using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public interface IOrdersRepository
    {
        List<Order> LoadOrderbatch(string orderDate);
        Order LoadOrder(string orderDate, int orderNumber);
        void SaveOrder();
    }
}
