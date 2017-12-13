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
    public class AddOrder
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            ConsoleIO.DisplayOrderDateRequest();
            string orderDate = Console.ReadLine();
            OrderAddResponse response = manager.AddOrder(orderDate);
            ConsoleIO.DisplayAddOrder(response);
        } 
    }
}
