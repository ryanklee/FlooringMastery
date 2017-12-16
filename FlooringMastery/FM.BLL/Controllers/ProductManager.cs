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
    public class ProductManager
    {
        private IProductsRepository _productsRepository;

        public ProductManager(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetProducts()
        {
            return _productsRepository.LoadProducts();
        }

        public OrderAddResponse CheckProduct(string product, OrderAddResponse orderAddResponse)
        {
            List<Product> products = GetProducts();
            if (products.Exists(entry => entry.ProductType.ToUpper() == product.ToUpper()))
            {
                orderAddResponse.Success = true;
                orderAddResponse.Order.ProductType = product;
                return orderAddResponse;
            }
            else
            {
                orderAddResponse.Success = false;
                orderAddResponse.Message = "Product does not exist.";
                return orderAddResponse;
            }
        }

        public OrderAddResponse PopulateAddOrderProductFields(OrderAddResponse response)
        {
            List<Product> products = GetProducts();
            foreach (var entry in _productsRepository.LoadProducts())
            {
                if (entry.ProductType.ToUpper() == response.Order.ProductType.ToUpper())
                {
                    response.Order.CostPerSquareFoot = entry.CostPerSquareFoot;
                    response.Order.LaborCostPerSquareFoot = entry.LaborCostPerSquareFoot;
                }
            }
            return response;
        }
    }
}
