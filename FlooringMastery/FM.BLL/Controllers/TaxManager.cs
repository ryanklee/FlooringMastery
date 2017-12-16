using FM.Models.Interfaces;
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
        private ITaxRepository _taxRepository;

        public TaxManager(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public bool StateExists(string state)
        {
            return _taxRepository.LoadTaxes().Exists(entry => entry.StateName.ToUpper() == state.ToUpper());
        }

        public OrderAddResponse GetStateTaxRate(string state, OrderAddResponse response)
        {
            foreach (var entry in _taxRepository.LoadTaxes())
            {
                if (entry.StateName.ToUpper() == state.ToUpper())
                {
                    response.Order.TaxRate = entry.TaxRate;
                    return response;
                }
            }
            response.Success = false;
            response.Message = "No such state on file.";
            return response;
        }

        public OrderAddResponse CheckState(string state, OrderAddResponse orderAddResponse)
        {
            if (StateExists(state) == false)
            {
                orderAddResponse.Success = false;
                orderAddResponse.Message = ($"{state} does not exist on file.");
                return orderAddResponse;
            }
            else
            {
                orderAddResponse.Success = true;
                orderAddResponse.Order.State = state;
                orderAddResponse = GetStateTaxRate(state, orderAddResponse);
                return orderAddResponse;
            }
        }
    }
}
