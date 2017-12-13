using FM.Models;
using FM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Repositories.Test
{
    public class ProductTestRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public List<Product> LoadProducts()
        {
            if (_products.Any() == false)
            {
                _products.Add(new Product
                {
                    ProductType = "Carpet",
                    CostPerSquareFoot = 2.25M,
                    LaborCostPerSquareFoot = 2.10M
                });

                _products.Add(new Product
                {
                    ProductType = "Laminate",
                    CostPerSquareFoot = 1.75M,
                    LaborCostPerSquareFoot = 2.10M
                });

                _products.Add(new Product
                {
                    ProductType = "Tile",
                    CostPerSquareFoot = 3.50M,
                    LaborCostPerSquareFoot = 4.15M
                });

                _products.Add(new Product
                {
                    ProductType = "Wood",
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M
                });
            }
            return _products;
        }

    }
}
