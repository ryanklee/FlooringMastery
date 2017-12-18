using FM.BLL;
using FM.BLL.Managers;
using FM.BLL.Factories;
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
    public class AddOrder
    {
        public void Execute()
        {
            OrderSingleResponse response = new OrderSingleResponse
            {
                Order = new Order()
            };

            OrderManager orderManager = OrderManagerFactory.Create();

            response.Order.OrderDate = RequestOrderDate(response.Order);
            response.Order.CustomerName = RequestCustomerName(response.Order);
            response.Order.State = RequestState(response.Order);
            response.Order.ProductType = RequestProduct(response.Order);
            response.Order.Area = RequestArea(response.Order);
            
            response.Order = orderManager.PopulateOrderProductFields(response.Order);
            response.Order = orderManager.CalculateNonInputOrderFields(response.Order);

            ConsoleIO.DisplayAddOrderSummary(response.Order);
            if (ConsoleIO.ConfirmOrder())
            {
                orderManager.AddOrder(response.Order);
            }
        }

        private string RequestOrderDate(Order order)
        {
            Validation validate = new Validation();

            while (true)
            {
                string orderDate = ConsoleIO.RequestOrderDate();
                ValidationResponse validationResponse = validate.OrderDateIsInFuture(orderDate);
                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return orderDate;
                }
            }
        }
        private string RequestCustomerName(Order order)
        {
            Validation validate = new Validation();
            while (true)
            {
                string custName = ConsoleIO.RequestCustomerName();
                ValidationResponse validationResponse = validate.CustomerName(custName);
                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return custName;
                }
            }
        }
        private string RequestState(Order order)
        {
            Validation validate = new Validation();
            while (true)
            {
                string state = ConsoleIO.RequestState();
                ValidationResponse validationResponse = validate.StateExists(state);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return state;
                }
            }
        }
        private string RequestProduct(Order order)
        {
            Validation validate = new Validation();
            ProductManager productManager = ProductManagerFactory.Create();
            List<Product> products = productManager.GetProducts();

            while (true)
            {
                ConsoleIO.DisplayProducts(products);
                string product = ConsoleIO.RequestProduct();
                ValidationResponse validationResponse = validate.ProductExists(product);

                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return product;
                }
            }
        }
        private decimal RequestArea(Order order)
        {
            Validation validate = new Validation();

            while (true)
            {
                string area = ConsoleIO.RequestArea();
                ValidationResponse validationResponse = validate.Area(area);
                if (validationResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(validationResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    return Decimal.Parse(area);
                }
            }
        }
    }
}
