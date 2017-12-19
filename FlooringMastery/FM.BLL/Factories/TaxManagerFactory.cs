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
    public class TaxManagerFactory
    {
        public static TaxManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TaxManager(new TaxTestRepository());
                case "Production":
                    return new TaxManager(new TaxProductionRepository());
                default:
                    throw new Exception("Invalid mode value. Check app config.");
            }
        }
    }
}
