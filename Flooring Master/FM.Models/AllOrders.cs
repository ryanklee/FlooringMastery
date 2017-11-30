using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public class AllOrders
    {
        public Dictionary<string, List<Order>> AllOrderBatches { get; set; }
    }
}
