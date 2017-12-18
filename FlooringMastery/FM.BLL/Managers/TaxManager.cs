using FM.Models;
using FM.Models.Interfaces;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.BLL.Managers
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

        public Order SetStateTaxRate(Order order)
        {
            foreach (var entry in _taxRepository.LoadTaxes())
            {
                if (entry.StateName.ToUpper() == order.State.ToUpper())
                {
                    order.TaxRate = entry.TaxRate;
                }
            }
            return order;
        }
    }
}
