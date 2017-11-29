using FM.Models.Batches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public interface IOrdersRepository
    {
        OrderBatch LoadOrders(string orderDate);
    }
}
