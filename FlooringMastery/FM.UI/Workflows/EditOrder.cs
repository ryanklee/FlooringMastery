using FM.BLL;
using FM.BLL.Factories;
using FM.BLL.Managers;
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
    public class EditOrder
    {
        public void Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            TaxManager taxManager = TaxManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();

            List<Product> products = productManager.GetProducts();
            Validation validate = new Validation();

            while (true)
            {
                string orderDate = ConsoleIO.RequestOrderDate();
                OrderEditResponse response = orderManager.LookupOrder(orderDate);

                string orderNumber = ConsoleIO.RequestOrderNumber();
                ValidationResponse validationResponse = validate.OrderNumber(orderNumber);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                }

                if (response.Success == false)
                {
                    ConsoleIO.DisplayMessage(response.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    break;
                }
            }
        }
    }
}
