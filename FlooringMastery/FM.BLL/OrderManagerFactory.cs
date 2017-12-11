using FM.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new MockRepository());
                case "Production":
                    throw new NotImplementedException();
                default:
                    throw new Exception("Invalid mode value. Check app config.");
            }
        }
    }
}
