using FM.BLL;
using FM.BLL.Factories;
using FM.BLL.Managers;
using FM.Models.Responses;
using FM.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.Workflows
{
    public class RemoveOrder
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderSingleResponse response = RetrieveOrder();

            ConsoleIO.DisplayAddOrderSummary(response.Order);
            if (ConsoleIO.ConfirmOrder())
            {
                manager.DeleteOrder(response.Order);
            }
        }

        private OrderSingleResponse RetrieveOrder()
        {
            OrderSingleResponse response = new OrderSingleResponse();
            OrderManager orderManager = OrderManagerFactory.Create();
            Validation validate = new Validation();

            while (true)
            {
                string orderDate = ConsoleIO.RequestOrderDate();
                string orderNumber = ConsoleIO.RequestOrderNumber();

                ValidationResponse validationResponse = validate.OrderNumber(orderNumber);
                response = orderManager.LookupOrder(orderDate, Int32.Parse(orderNumber));

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
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
            return response;
        }
    }
}
