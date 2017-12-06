using FM.BLL;
using FM.Models;
using FM.Models.Responses;
using FM.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.Workflows
{
    public class OrderbatchLookup
    {
        public void Execute()
        {
            OrdersManager manager = OrdersManagerFactory.Create();
            ConsoleIO.DisplayOrderDateRequest();
            string orderDate = Console.ReadLine();
            OrderbatchLookupResponse response = manager.LookupOrderbatch(orderDate);
            ConsoleIO.DisplayOrderbatch(response);
        }
    }
}
