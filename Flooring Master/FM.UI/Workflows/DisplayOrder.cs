using FM.BLL;
using FM.Models;
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
            List<Order> orderBatch = manager.LookupOrder(orderDate);
            if (orderBatch == null)
            {
                ConsoleIO.DisplayInvalidOrderDateError(orderDate);
            }
            else
            {
                ConsoleIO.DisplayOrderDetails(orderBatch, orderDate);
            }
        }
    }
}
