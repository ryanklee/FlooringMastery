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
            
            List<Order> orderBatch = _ordersRepository.LoadOrder(orderDate);

            return orderBatch;
        }

        public Tax LookupTax(string state)
        {
            _ordersRepository.LoadAllTaxes();
            Tax tax = _ordersRepository.LoadTax(state);

            return tax;
        }

        public Product LookupProduct(string productType)
        {
            _ordersRepository.LoadAllProducts();
            Product product = _ordersRepository.LoadProduct(productType);

            return product;
        }

        public Dictionary<string, string> CalculateFields(Dictionary<string, string> orderInputs)
        {
            decimal costPerSquareFoot = LookupProduct(orderInputs["Product Type"]).CostPerSquareFoot;
            decimal laborCostPerSquareFoot = LookupProduct(orderInputs["Product Type"]).LaborCostPerSquareFoot;
            decimal materialCost = Decimal.Parse(orderInputs["Area"]) * costPerSquareFoot;
            decimal laborCost = Decimal.Parse(orderInputs["Area"]) * laborCostPerSquareFoot;
            decimal taxRate = LookupTax(orderInputs["State"]).TaxRate;
            decimal tax = ((materialCost + laborCost) * (taxRate / 100));
            decimal total = materialCost + laborCost + tax;

            orderInputs.Add("Tax Rate", taxRate.ToString());
            orderInputs.Add("CostPerSquareFoot", costPerSquareFoot.ToString());
            orderInputs.Add("LaborCostPerSquareFoot", laborCostPerSquareFoot.ToString());
            orderInputs.Add("MaterialCost", materialCost.ToString());
            orderInputs.Add("LaborCost", laborCost.ToString());
            orderInputs.Add("Tax", tax.ToString());
            orderInputs.Add("Total", total.ToString());

            return orderInputs;
        }

        public void AddOrder(Dictionary<string, string> orderInputs)
        {
            Order order = ConvertOrderInputsToOrder(orderInputs);
            _ordersRepository.AddOrder(order, orderInputs["Order Date"]);
        }

        private Order ConvertOrderInputsToOrder(Dictionary<string, string> orderInputs)
        {
            Order order = new Order
            {
                CustomerName = orderInputs["Customer Name"],
                State = orderInputs["State"],
                TaxRate = Decimal.Parse(orderInputs["Tax Rate"]),
                ProductType = orderInputs["Product Type"],
                Area = Decimal.Parse(orderInputs["Area"]),
                CostPerSquareFoot = Decimal.Parse(orderInputs["CostPerSquareFoot"]),
                LaborCostPerSquareFoot = Decimal.Parse(orderInputs["LaborCostPerSquareFoot"]),
                MaterialCost = Decimal.Parse(orderInputs["MaterialCost"]),
                LaborCost = Decimal.Parse(orderInputs["LaborCost"]),
                Tax = Decimal.Parse(orderInputs["Tax"]),
                Total = Decimal.Parse(orderInputs["Total"])
            };
            return order;
        }

        public Order RetrieveOrder(string orderDate, string orderNumber)
        {
            Order orderBatch = _ordersRepository.LoadOrder(orderDate, orderNumber);

            return orderBatch;

        }
    }
}
