using FM.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.UI.Workflows
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                ConsoleIO.DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        OrderLookup displayOrder = new OrderLookup();
                        displayOrder.Execute();
                        break;
                    case "2":
                        AddOrder addOrder = new AddOrder();
                        addOrder.Execute();
                        break;
                    case "3":
                        EditOrder editOrder = new EditOrder();
                        editOrder.Execute();
                        break;
                    case "4":
                        RemoveOrder removeOrder = new RemoveOrder();
                        removeOrder.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        continue;
                }
            }
        }
    }
}
