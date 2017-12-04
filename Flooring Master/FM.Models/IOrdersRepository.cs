using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public interface IOrdersRepository
    {
        List<Order> LoadOrder(string orderDate);
        Order LoadOrder(string orderDate, string orderNumber);
        Tax LoadTax(string state);
        Product LoadProduct(string productType);
        void LoadAllOrders();
        void LoadAllTaxes();
        void LoadAllProducts();
        void AddOrder(Order order, string orderdate);
        void SaveOrder();
    }
}
