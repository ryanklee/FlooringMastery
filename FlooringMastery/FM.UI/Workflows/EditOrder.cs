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
            OrderSingleResponse response = RetrieveOrder();
            ProductManager productManager = ProductManagerFactory.Create();
            OrderManager orderManager = OrderManagerFactory.Create();

            response.Order.CustomerName = EditCustomerName(response.Order.CustomerName);
            response.Order.State = EditState(response.Order.State);
            response.Order.ProductType = EditProduct(response.Order.ProductType);
            response.Order.Area = EditArea(response.Order.Area);

            response.Order = orderManager.PopulateOrderProductFields(response.Order);
            response.Order = orderManager.CalculateNonInputOrderFields(response.Order);

            ConsoleIO.DisplayAddOrderSummary(response.Order);
            if (ConsoleIO.ConfirmOrder())
            {
                orderManager.AddOrder(response.Order);
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
        private string EditCustomerName(string oldCustomerName)
        {
            Validation validate = new Validation();

            while (true)
            {
                string newCustomerName = ConsoleIO.EditCustomerName(oldCustomerName);

                if (newCustomerName == "")
                {
                    return oldCustomerName;
                }

                ValidationResponse validationResponse = validate.CustomerName(newCustomerName);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return newCustomerName;
                }
            }
        }
        private string EditState(string oldState)
        {
            Validation validate = new Validation();

            while (true)
            {
                string newState = ConsoleIO.EditState(oldState);

                if (newState == "")
                {
                    return oldState;
                }

                ValidationResponse validationResponse = validate.StateExists(newState);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return newState;
                }
            }
        }
        private string EditProduct(string oldProduct)
        {
            Validation validate = new Validation();

            while (true)
            {
                string newProduct = ConsoleIO.EditProductType(oldProduct);

                if (newProduct == "")
                {
                    return oldProduct;
                }

                ValidationResponse validationResponse = validate.ProductExists(newProduct);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return newProduct;
                }
            }
        }
        private decimal EditArea(decimal oldArea)
        {
            Validation validate = new Validation();

            while (true)
            {
                string newArea = ConsoleIO.EditArea(oldArea);

                if (newArea == "")
                {
                    return oldArea;
                }

                ValidationResponse validationResponse = validate.Area(newArea);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    oldArea = Decimal.Parse(newArea);
                }
            }
        }
    }
}
