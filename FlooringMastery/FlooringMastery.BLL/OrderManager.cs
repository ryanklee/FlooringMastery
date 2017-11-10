using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupOrder(int orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse
            {
                Order = _orderRepository.LoadOrder(orderDate)
            };

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "Not a valid date!";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
