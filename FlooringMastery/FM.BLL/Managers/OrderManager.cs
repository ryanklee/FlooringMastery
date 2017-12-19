using FM.BLL.Factories;
using FM.Models;
using FM.Models.Interfaces;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL.Managers
{
    public class OrderManager
    {
        private IOrdersRepository _ordersRepository;

        public OrderManager(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public List<Order> LoadOrderBatch(string orderDate)
        {
            return _ordersRepository.LoadOrders(orderDate);
        }

        public Order LoadSingleOrder(string orderDate, int orderNumber)
        {

            List<Order> orderBatch = LoadOrderBatch(orderDate);
            bool orderExists = orderBatch.Exists(order => order.OrderDate == orderDate &&
                                     order.OrderNumber == orderNumber);
            if (orderExists)
            {
                Order singleOrder = LoadOrderBatch(orderDate).Where(order => order.OrderDate == orderDate &&
                                         order.OrderNumber == orderNumber).First();
                return singleOrder;
            }

            return null;
        }

        public OrderBatchResponse LookupOrder(string orderDate)
        {
            OrderBatchResponse response = new OrderBatchResponse
            {
                Order = LoadOrderBatch(orderDate)
            };

            if (response.Order == null || !response.Order.Any())
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

        public OrderSingleResponse LookupOrder(string orderDate, int orderNumber)
        {
            OrderSingleResponse response = new OrderSingleResponse
            {
                Order = LoadSingleOrder(orderDate, orderNumber)
            };

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"No order for { orderDate } { orderNumber } exists.";
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

        public void DeleteOrder(Order order)
        {
            _ordersRepository.DeleteOrder(order);
        }

        public Order PopulateOrderProductFields(Order order)
        {
            ProductManager productManager = ProductManagerFactory.Create();
            TaxManager taxManager = TaxManagerFactory.Create();
            List<Product> products = productManager.GetProducts();
            order = taxManager.SetStateTaxRate(order);

            foreach (var entry in productManager.GetProducts())
            {
                if (entry.ProductType.ToUpper() == order.ProductType.ToUpper())
                {
                    order.CostPerSquareFoot = entry.CostPerSquareFoot;
                    order.LaborCostPerSquareFoot = entry.LaborCostPerSquareFoot;
                }
            }
            return order;
        }

        public Order CalculateNonInputOrderFields(Order order)
        {
            order.MaterialCost = order.Area * order.CostPerSquareFoot;

            order.LaborCost = order.Area * order.LaborCostPerSquareFoot;

            order.Tax = ((order.MaterialCost + order.LaborCost) *
                (order.TaxRate / 100));

            order.Total = order.MaterialCost + order.LaborCost + order.Tax;

            return order;
        }


    }
}
