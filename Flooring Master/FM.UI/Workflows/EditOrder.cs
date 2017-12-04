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
    public class EditOrder
    {
        public void Execute()
        {
            OrdersManager manager = OrdersManagerFactory.Create();
            Validation validation = new Validation();

            ConsoleIO.DisplayEditOrderMenu();
            string orderDate = ConsoleIO.GetLineInput("Order Date: ");
            string orderNumber = ConsoleIO.GetLineInput("Order Number: ");

            Order order = manager.RetrieveOrder(orderDate, orderNumber);

            if (order == null)
            {
                ConsoleIO.DisplayInvalidOrderDateError(orderDate);
            }
            else
            {
                Console.WriteLine("Looking good");
                Console.ReadLine();
            }

        }
    }
}
