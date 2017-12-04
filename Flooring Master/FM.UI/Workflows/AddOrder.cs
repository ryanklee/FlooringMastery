using FM.BLL;
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
            OrdersManager manager = OrdersManagerFactory.Create();
            Validation validation = new Validation();

            while (true)
            {
                Dictionary<string, string> orderInputs = new Dictionary<string, string>
                {
                    { "Order Date", null },
                    { "Customer Name", null },
                    { "State", null },
                    { "Product Type", null },
                    { "Area", null }
                };

                foreach (var inputKey in orderInputs.Keys.ToList())
                {
                    ConsoleIO.DisplayAddOrderMenu(orderInputs);
                    string input = ConsoleIO.GetLineInput(inputKey);
                    input = validation.ValidateAddOrderInputs(inputKey, input, orderInputs);
                    orderInputs[inputKey] = input;
                }

                orderInputs = manager.CalculateFields(orderInputs);

                ConsoleIO.DisplayAddOrderFinalizeMenu(orderInputs);
                if (ConsoleIO.GetFinalOK() == true)
                {
                    manager.AddOrder(orderInputs);
                    break;
                }
                else continue;
            }
        }
    }
}
