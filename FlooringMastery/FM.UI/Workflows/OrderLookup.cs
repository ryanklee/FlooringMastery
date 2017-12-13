using FM.BLL.Controllers;
using FM.BLL.Factories;
using FM.Models.Responses;
using FM.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.Workflows
{
    public class OrderLookup
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            ConsoleIO.DisplayOrderDateRequest();
            string orderDate = Console.ReadLine();
            OrderLookupResponse response = manager.LookupOrder(orderDate);
            ConsoleIO.DisplayOrder(response);
        }
    }
}
