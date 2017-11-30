using FM.Models;
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

        public List<Order> LookupOrder(string orderDate)
        {
            _ordersRepository.LoadAllOrders();
            List<Order> orderBatch = _ordersRepository.LoadOrder(orderDate);

            return orderBatch;
        }
    }
}
