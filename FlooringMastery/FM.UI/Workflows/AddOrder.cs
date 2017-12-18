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
            OrderManager orderManager = OrderManagerFactory.Create();
            TaxManager taxManager = TaxManagerFactory.Create();
            ProductManager productManager = ProductManagerFactory.Create();

            List<Product> products = productManager.GetProducts();
            Validation validate = new Validation();

            OrderAddResponse orderAddResponse = new OrderAddResponse
            {
                Order = new Order()
            };

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
                    orderAddResponse.Order.OrderDate = orderDate;
                    ConsoleIO.PromptContinue();
                    break;
                }
            }

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
                    orderAddResponse.Order.CustomerName = custName;
                    ConsoleIO.PromptContinue();
                    break;
                }
            }

            while (true)
            {
                string state = ConsoleIO.RequestState();
                orderAddResponse = taxManager.CheckState(state, orderAddResponse);
                if (orderAddResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(orderAddResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    break;
                }
            }

            while (true)
            {
                ConsoleIO.DisplayProducts(products);
                string product = ConsoleIO.RequestProduct();
                orderAddResponse = productManager.CheckProduct(product, orderAddResponse);
                if (orderAddResponse.Success == false)
                {
                    ConsoleIO.DisplayMessage(orderAddResponse.Message);
                    ConsoleIO.PromptContinue();
                }
                else
                {
                    ConsoleIO.PromptContinue();
                    break;
                }
            }

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
                    orderAddResponse.Order.Area = Decimal.Parse(area);
                    ConsoleIO.PromptContinue();
                    break;
                }
            }
            orderAddResponse = productManager.PopulateAddOrderProductFields(orderAddResponse);
            orderAddResponse = orderManager.CalculateNonInputOrderFields(orderAddResponse);
            ConsoleIO.DisplayAddOrderSummary(orderAddResponse.Order);
            if (ConsoleIO.ConfirmOrder())
            {
                orderManager.AddOrder(orderAddResponse.Order);
            }
        }
    }
}
