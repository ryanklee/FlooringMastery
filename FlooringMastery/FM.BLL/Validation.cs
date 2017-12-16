using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FM.BLL
{
    public class Validation
    {
        public ValidationResponse OrderDateIsInFuture(string orderDate)
        {
            ValidationResponse response = new ValidationResponse();
            DateTime parsedOrderDate;

            if (DateTime.TryParseExact(orderDate, "ddMMyyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out parsedOrderDate))
            {
                int result = DateTime.Compare(parsedOrderDate.Date, DateTime.Now.Date);

                if (result == 1)
                {
                    response.Success = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Date of order must be in the future";
                    return response;

                }
            }

            response.Success = false;
            response.Message = "Date format invalid";
            return response;
        }

        public ValidationResponse CustomerName(string custName)
        {
            ValidationResponse response = new ValidationResponse();
            var regex = new Regex("^[a-zA-Z0-9 /.,]*$");

            if (custName == "")
            {
                response.Success = false;
                response.Message = "Customer Name must not be blank.";
                return response;
            }
            else if (!regex.IsMatch(custName))
            {
                response.Success = false;
                response.Message = "Customer Name must contain only letters, numbers, spaces, commas, and periods.";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public ValidationResponse Area(string area)
        {
            ValidationResponse response = new ValidationResponse();

            if (Decimal.TryParse(area, out decimal parsedArea))
            {
                if (parsedArea > 0)
                {
                response.Success = true;
                return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Area must be positive number";
                }
            }

            response.Success = false;
            response.Message = $"{area} not a valid number.";
            return response;
        }
    }
}
