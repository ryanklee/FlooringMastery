using FM.Models;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL
{
    public class OrdersManager
    {
        private IOrdersRepository _ordersRepository;

        public OrdersManager(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public OrderbatchLookupResponse LookupOrderbatch(string orderDate)
        {
            OrderbatchLookupResponse response = new OrderbatchLookupResponse
            {
                Orderbatch = _ordersRepository.LoadOrderbatch(orderDate)
            };

            if (response.Orderbatch == null)
            {
                response.Success = false;
                response.Message = $"{ orderDate } is invalid!";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
