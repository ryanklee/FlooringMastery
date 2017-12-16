using FM.BLL.Managers;
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
            string orderDate = ConsoleIO.RequestOrderDate();
            OrderLookupResponse response = manager.LookupOrder(orderDate);
            if (response.Success == true) ConsoleIO.DisplayOrder(response);
            else ConsoleIO.DisplayMessage(response.Message);
            ConsoleIO.PromptContinue();
        }
    }
}
