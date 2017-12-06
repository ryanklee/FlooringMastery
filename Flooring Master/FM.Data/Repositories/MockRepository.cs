using FM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Repositories
{
    public class MockRepository : IOrdersRepository
    {
        private static Order _order = new Order
        {
            OrderDate = "06012013",
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M
        };

        private static List<Order> _orderBatch = new List<Order> { _order };

        public List<Order> LoadOrderbatch(string orderDate)
        {
            foreach (var order in _orderBatch)
            {
                if (order.OrderDate == orderDate) return _orderBatch;
            }
            return _orderBatch;
        }

        public Order LoadOrder(string orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder()
        {
            throw new NotImplementedException();
        }
    }
}





