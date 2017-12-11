using FM.Models;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL
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

        public OrderAddResponse AddOrder(string orderDate)
        {
            Validation validate = new Validation();
            OrderAddResponse response = new OrderAddResponse
            {
                Order = new Order()
            };

            Response validationResponse = validate.OrderDateIsInFuture(orderDate);

            if (validationResponse.Success == false)
            {
                response.Success = false;
                response.Message = validationResponse.Message;
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }

        }
    }
}
