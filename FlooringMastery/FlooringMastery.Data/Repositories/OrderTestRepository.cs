using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.OrderTestRepository
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = 234,
            OrderDate = 05052020,
            CustomerName = "Test",
            State = "MN",
            TaxRate = 10.25M,
            ProductType = "Unobtanium",
            Area = 250.00M,
            CostPerSquareFoot = 10.15M,
            LaborCostPerSquareFoot = 50.50M,
            MaterialCost = _order.Area * _order.CostPerSquareFoot,
            LaborCost = _order.Area * _order.LaborCostPerSquareFoot,
            Tax = (_order.MaterialCost + _order.MaterialCost) * (_order.TaxRate/100),
            Total = _order.MaterialCost + _order.LaborCost + _order.Tax
        };


        public Order LoadOrder(int OrderDate)
        {
            if(OrderDate != _order.OrderDate)
            {
                return null;
            }

            return _order;
        }

        public void SaveOrder(Order order)
        {
            _order = order;
        }
    }
}
