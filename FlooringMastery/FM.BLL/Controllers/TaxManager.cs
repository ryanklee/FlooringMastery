using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL.Controllers
{
    public class TaxManager
    {
        public OrderAddResponse StateOnFile(string state, OrderAddResponse orderAddResponse)
        {
            state = state.Substring(0, 1).ToUpper() + state.Substring(1).ToLower();
            foreach (var entry in orderAddResponse.Taxes)
            {
                if (entry.StateName == state)
                {
                    orderAddResponse.Success = true;
                    return orderAddResponse;
                }
            }
            orderAddResponse.Success = false;
            orderAddResponse.Message = "State not on file.";
            return orderAddResponse;
        }
    }
}
