using FM.Models;
using FM.Models.Batches;
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

        public OrderBatch LookupOrder(string orderDate)
        {
            OrderBatch orderBatch = _ordersRepository.LoadOrders(orderDate);

            return orderBatch;
        }
    }
}
