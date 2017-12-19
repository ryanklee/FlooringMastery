using FM.Models;
using FM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Repositories.Production
{
    public class ProductProductionRepository : IProductsRepository
    {
        public List<Product> LoadProducts()
        {
            string filePath = $@"..\..\..\FM.Data\Repositories\Production\Data\Products.txt";

            if (!File.Exists(filePath))
            {
                return null;
            }

            else
            {
                List<Product> products = LoadFileData(filePath);
                return products;
            }
        }

        private List<Product> LoadFileData(string filePath)
        {
            TryFile(filePath);
            List<Product> products = new List<Product>();

            string[] rows = File.ReadAllLines(filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Product product = new Product()
                {
                    ProductType = columns[0],
                    CostPerSquareFoot = Decimal.Parse(columns[1]),
                    LaborCostPerSquareFoot = Decimal.Parse(columns[2])
                };

                products.Add(product);
            }
            return products;
        }

        private void TryFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
