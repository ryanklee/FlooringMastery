using FM.BLL.Managers;
using FM.Data.Repositories.Production;
using FM.Data.Repositories.Test;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL.Factories
{
    public class ProductManagerFactory
    {
        public static ProductManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductManager(new ProductTestRepository());
                case "Production":
                    return new ProductManager(new ProductProductionRepository());
                default:
                    throw new Exception("Invalid mode value. Check app config.");
            }
        }
    }
}
