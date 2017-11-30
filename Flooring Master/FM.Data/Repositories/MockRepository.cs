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

        private static AllOrders _allOrders = new AllOrders()
        {
            AllOrderBatches = new Dictionary<string, List<Order>>()
        };

        public void LoadAllOrders()
        {
            AllOrders allOrders = new AllOrders();

            allOrders.AllOrderBatches = new Dictionary<string, List<Order>>();

            List<Order> orderBatch = new List<Order>();
            string orderDate = "06012013";
            string orderEntry = "1,Wise,OH,6.25,Wood,100.00,5.15,4.75,515.00,475.00,61.88,1051.88";
            string[] orderFields = orderEntry.Split(',');

            Order order = new Order()
            {
                OrderNumber = Int32.Parse(orderFields[0]),
                CustomerName = orderFields[1],
                State = orderFields[2],
                TaxRate = Decimal.Parse(orderFields[3]),
                ProductType = orderFields[4],
                Area = Decimal.Parse(orderFields[5]),
                CostPerSquareFoot = Decimal.Parse(orderFields[6]),
                LaborCostPerSquareFoot = Decimal.Parse(orderFields[7]),
                MaterialCost = Decimal.Parse(orderFields[8]),
                LaborCost = Decimal.Parse(orderFields[9]),
                Tax = Decimal.Parse(orderFields[10]),
                Total = Decimal.Parse(orderFields[11])
            };

            orderBatch.Add(order);

            allOrders.AllOrderBatches.Add(orderDate, orderBatch);

            _allOrders = allOrders;

        }

        public List<Order> LoadOrder(string orderDate)
        {
            if (_allOrders.AllOrderBatches.ContainsKey(orderDate) == false) return null;
            else return _allOrders.AllOrderBatches[orderDate];

        }

        public Order AddOrder()
        {
            throw new NotImplementedException();
        }

        public Order EditOrder()
        {
            throw new NotImplementedException();
        }

        public Order SaveOrder()
        {
            throw new NotImplementedException();
        }
    }
}





