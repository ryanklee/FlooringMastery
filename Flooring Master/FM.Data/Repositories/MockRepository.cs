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
        private static bool _allOrdersLoaded;
        private static bool _allProductsLoaded;
        private static bool _allTaxesLoaded;

        public MockRepository()
        {
            if (_allOrdersLoaded == false) LoadAllOrders();
            if (_allProductsLoaded == false) LoadAllProducts();
            if (_allTaxesLoaded == false) LoadAllTaxes();
        }

        private static AllOrders _allOrders = new AllOrders()
        {
            AllOrderBatches = new Dictionary<string, List<Order>>()
        };

        private static AllProducts _allProducts = new AllProducts()
        {
            AllProductEntries = new List<Product>()
        };

        private static AllTaxes _allTaxes = new AllTaxes()
        {
            AllTaxEntries = new List<Tax>()
        };

        public void LoadAllOrders()
        {
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
            _allOrders.AllOrderBatches.Add(orderDate, orderBatch);
            _allOrdersLoaded = true;
        }

        public void LoadAllProducts()
        {
            List<Product> productEntry = new List<Product>();
            List<string> sampleData = new List<string>();

            sampleData.Add("Carpet,2.25,2.10");
            sampleData.Add("Laminate,1.75,2.10");
            sampleData.Add("Tile,3.50,4.15");
            sampleData.Add("Wood,5.15,4.75");

            foreach (var entry in sampleData)
            {
                string[] productFields = entry.Split(',');
                Product product = new Product()
                {
                    ProductType = productFields[0],
                    CostPerSquareFoot = Decimal.Parse(productFields[1]),
                    LaborCostPerSquareFoot = Decimal.Parse(productFields[2])
                };
                _allProducts.AllProductEntries.Add(product);
            }
            _allProductsLoaded = true;
        }

        public void LoadAllTaxes()
        {
            List<Tax> TaxEntry = new List<Tax>();
            List<string> sampleData = new List<string>();

            sampleData.Add("OH,Ohio,6.25");
            sampleData.Add("PA,Pennsylvania,6.75");
            sampleData.Add("MI,Michigan,5.75");
            sampleData.Add("IN,Indiana,6.00");

            foreach (var entry in sampleData)
            {
                string[] taxFields = entry.Split(',');
                Tax tax = new Tax()
                {
                    StateAbbreviation = taxFields[0],
                    StateName = taxFields[1],
                    TaxRate = Decimal.Parse(taxFields[2])
                };
                _allTaxes.AllTaxEntries.Add(tax);
            }
            _allTaxesLoaded = true;
        }

        public List<Order> LoadOrder(string orderDate)
        {
            if (_allOrders.AllOrderBatches.ContainsKey(orderDate) == false) return null;
            else return _allOrders.AllOrderBatches[orderDate];

        }

        public Order LoadOrder(string orderDate, string orderNumber)
        {
            if (_allOrders.AllOrderBatches.ContainsKey(orderDate) == false ||
                _allOrders.AllOrderBatches[orderDate].ElementAt(Int32.Parse(orderNumber) - 1) == null)
                return null;
            else return _allOrders.AllOrderBatches[orderDate].ElementAt(Int32.Parse(orderNumber) - 1);
        }

        public Tax LoadTax(string state)
        {
            foreach (var taxEntry in _allTaxes.AllTaxEntries)
            {
                if (taxEntry.StateAbbreviation == state) return taxEntry;
            }
            return null;
        }

        public Product LoadProduct(string productType)
        {
            foreach (var productEntry in _allProducts.AllProductEntries)
            {
                if (productEntry.ProductType == productType) return productEntry;
            }
            return null;
        }

        public void AddOrder(Order order, string orderDate)
        {
            bool orderDateExits = _allOrders.AllOrderBatches.ContainsKey(orderDate);

            if (orderDateExits)
            {
                order.OrderNumber = _allOrders.AllOrderBatches[orderDate].Count() + 1;
                _allOrders.AllOrderBatches[orderDate].Add(order);
            }
            else
            {
                List<Order> orderBatch = new List<Order>();
                order.OrderNumber = 1;
                orderBatch.Add(order);
                _allOrders.AllOrderBatches.Add(orderDate, orderBatch);
            }
        }

        public void SaveOrder()
        {
            throw new NotImplementedException();
        }
    }
}





