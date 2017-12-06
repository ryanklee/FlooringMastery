using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models.Responses
{
    public class OrderbatchLookupResponse : Response
    {
        public List<Order> Orderbatch { get; set; }
    }
}
