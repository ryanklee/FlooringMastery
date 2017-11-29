using FM.BLL;
using FM.Models;
using FM.Models.Batches;
using FM.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.Workflows
{
    public class DisplayOrder
    {
        public void Execute()
        {
            OrdersManager manager = OrdersManagerFactory.Create();

            ConsoleIO.DisplayOrderDateRequest();

            string orderDate = ConsoleIO.GetOrderDate();

            OrderBatch orderBatch = manager.LookupOrder(orderDate);

           

            ConsoleIO.DisplayOrderDetails(orderBatch.Orders[0], orderDate);
            
            Console.ReadLine();
        }
    }
}
