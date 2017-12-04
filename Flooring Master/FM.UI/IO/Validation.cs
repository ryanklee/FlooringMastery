using FM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.IO
{
    public class Validation
    {
        public string ValidateAddOrderInputs(string inputName, string input, Dictionary<string, string> orderInputs)
        {
            OrdersManager manager = OrdersManagerFactory.Create();

            switch (inputName)
            {
                case "Order Date":
                    return input;
                case "Customer Name":
                    return input;
                case "State":
                    while (true)
                    {
                        if (manager.LookupTax(input) != null) break;
                        else
                        {
                            ConsoleIO.DisplayAddOrderMenu(orderInputs);
                            input = ConsoleIO.GetLineInput(inputName);
                        }
                    }
                    return input;
                case "Product Type":
                    while (true)
                    {
                        if (manager.LookupProduct(input) != null) break;
                        else
                        {
                            ConsoleIO.DisplayAddOrderMenu(orderInputs);
                            input = ConsoleIO.GetLineInput(inputName);
                        }
                    }
                    return input;
                case "Area":
                    return input;
                default:
                    return input;
            }
        }
    }
}
