using FM.Models;
using FM.Models.Interfaces;
using FM.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Repositories.Test
{
    public class TaxTestRepository : ITaxRepository
    {
        private static List<Tax> _taxes = new List<Tax>()
        {
            new Tax { StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M },
            new Tax { StateAbbreviation = "PA", StateName = "Pennsylvania", TaxRate = 6.75M },
            new Tax { StateAbbreviation = "MI", StateName = "Michigan", TaxRate = 6.75M}
        };

        public List<Tax> LoadTaxes()
        {
            return _taxes;
        }
    }
}
