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
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository());
                case "Production":
                    return new OrderManager(new OrderProductionRepository());
                default:
                    throw new Exception("Invalid mode value. Check app config.");
            }
        }
    }
}
