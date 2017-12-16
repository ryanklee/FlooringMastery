using FM.Models;
using FM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Repositories.Test
{
    public class OrderTestRepository : IOrdersRepository
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

        public IEnumerable<Order> LoadOrder(string orderDate)
        {
            return _orderBatch.Where(order => order.OrderDate == orderDate);
        }

        public IEnumerable<Order> LoadOrder(string orderDate, int orderNumber)
        {
            return _orderBatch.Where(order => order.OrderDate == orderDate && order.OrderNumber == orderNumber);
        }

        public void SaveOrder(Order order)
        {
            //check if order has default decimal value, i.e it's a new order
            if (order.OrderNumber == 0)
            {
                //check if orderdate is already on file
                if (_orderBatch.Exists(orderEntry => orderEntry.OrderDate == order.OrderDate))
                {
                    //yes? then order number == max existing order number + 1
                    order.OrderNumber = _orderBatch.Where(orderEntry => orderEntry.OrderDate == order.OrderDate).Max(orderEntry => orderEntry.OrderNumber) + 1;
                }
                //no? then make order number == 1
                else order.OrderNumber++;
            }
            _orderBatch.Add(order);
        }
    }
}





