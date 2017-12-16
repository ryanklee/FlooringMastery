using FM.Models;
using FM.Models.Interfaces;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL.Controllers
{
    public class OrderManager
    {
        private IOrdersRepository _ordersRepository;

        public OrderManager(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public OrderLookupResponse LookupOrder(string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse
            {
                Order = _ordersRepository.LoadOrder(orderDate)
            };

            if (!response.Order.Any())
            {
                response.Success = false;
                response.Message = $"No order for { orderDate } exists.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public void AddOrder(Order order)
        {

            _ordersRepository.SaveOrder(order);

        }

        public OrderAddResponse CalculateNonInputOrderFields(OrderAddResponse orderAddResponse)
        {

            //        MaterialCost = (Area * CostPerSquareFoot)
            //        LaborCost = (Area * LaborCostPerSquareFoot)
            //        Tax = ((MaterialCost + LaborCost) * (TaxRate / 100))
            //        Tax rates are stored as whole numbers
            //        Total = (MaterialCost + LaborCost + Tax)

            orderAddResponse.Order.MaterialCost = orderAddResponse.Order.Area * 
                orderAddResponse.Order.CostPerSquareFoot;

            orderAddResponse.Order.LaborCost = orderAddResponse.Order.Area * 
                orderAddResponse.Order.LaborCostPerSquareFoot;

            orderAddResponse.Order.Tax = ((orderAddResponse.Order.MaterialCost + 
                orderAddResponse.Order.LaborCost) * 
                (orderAddResponse.Order.TaxRate / 100));

            orderAddResponse.Order.Total = orderAddResponse.Order.MaterialCost + 
                orderAddResponse.Order.LaborCost +
                orderAddResponse.Order.Tax;
            return orderAddResponse;
        }
    }
}
