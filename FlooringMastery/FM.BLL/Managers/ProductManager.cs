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

        
    }
}
