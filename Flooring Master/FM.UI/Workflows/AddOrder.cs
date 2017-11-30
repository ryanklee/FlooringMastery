using FM.BLL;
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
            OrdersManager manager = OrdersManagerFactory.Create();
            ConsoleIO.DisplayAddOrderMenu();
        }
    }
}
