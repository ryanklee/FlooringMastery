using FM.Models;
using FM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Repositories.Production
{
    public class OrderProductionRepository : IOrdersRepository
    {

        public List<Order> LoadOrders(string orderDate)
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = $@"..\..\..\FM.Data\Repositories\Production\Data\Orders_{orderDate}.txt";
            if (File.Exists(filePath))
            {
                List<Order> orderBatch = LoadFileData(filePath);
                orderBatch.ForEach(order => order.OrderDate = orderDate);
                return orderBatch;
            }
            else
            {
                return null;
            }
        }

        public void SaveOrder(Order order)
        {
            string filePath = $@"..\..\..\FM.Data\Repositories\Production\Data\Orders_{order.OrderDate}.txt";

            if (order.OrderNumber == 0) // if default int value, then new order
            {
                bool fileExists = File.Exists(filePath);
                if (fileExists) // existing file? 
                {
                    //if yes, increment to next highest ordernumber, then append to existing file
                    List<Order> orderBatch = LoadFileData(filePath);
                    order.OrderNumber = orderBatch.Max(orderEntry => orderEntry.OrderNumber) + 1;
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        writer.WriteLine($"{order.OrderNumber}," +
                            $"{order.CustomerName}," +
                            $"{order.State},{order.TaxRate}," +
                            $"{order.ProductType},{order.Area}," +
                            $"{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot}," +
                            $"{order.MaterialCost},{order.LaborCost},{order.Tax}," +
                            $"{order.Total}");
                    }
                }
                else // if new file
                {
                    order.OrderNumber = 1;
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                        writer.WriteLine($"{order.OrderNumber}," +
                            $"{order.CustomerName}," +
                            $"{order.State},{order.TaxRate}," +
                            $"{order.ProductType},{order.Area}," +
                            $"{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot}," +
                            $"{order.MaterialCost},{order.LaborCost},{order.Tax}," +
                            $"{order.Total}");
                    }
                }
            }
            else // if existing order
            {
                List<string> file = File.ReadAllLines(filePath).ToList();

                foreach (var line in file)
                {
                    List<string> fields = line.Split(',').ToList();
                    if (fields.ElementAt(0) == order.OrderNumber.ToString())
                    {
                        file.Remove(line);

                        file.Add($"{order.OrderNumber}," +
                        $"{order.CustomerName}," +
                        $"{order.State},{order.TaxRate}," +
                        $"{order.ProductType},{order.Area}," +
                        $"{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot}," +
                        $"{order.MaterialCost},{order.LaborCost},{order.Tax}," +
                        $"{order.Total}");
                        break;
                    }


                }

                File.WriteAllLines(filePath, file);
            }
        }

        public void DeleteOrder(Order order)
        {
            string filePath = $@"..\..\..\FM.Data\Repositories\Production\Data\Orders_{order.OrderDate}.txt";
            TryFile(filePath);
            List<string> file = File.ReadAllLines(filePath).ToList();

            foreach (var line in file)
            {
                List<string> fields = line.Split(',').ToList();
                if (fields.ElementAt(0) == order.OrderNumber.ToString())
                {
                    file.Remove(line);
                    break;
                }
            }

            File.WriteAllLines(filePath, file);
        }

        private List<Order> LoadFileData(string filePath)
        {
            TryFile(filePath);
            List<Order> orders = new List<Order>();
            List<string> rows = File.ReadAllLines(filePath).ToList();
            rows.RemoveAt(0); // get rid of header

            foreach (var row in rows)
            {
                string[] columns = row.Split(',');
                Order order = new Order()
                {
                    OrderNumber = Int32.Parse(columns[0]),
                    CustomerName = columns[1],
                    State = columns[2],
                    TaxRate = Decimal.Parse(columns[3]),
                    ProductType = columns[4],
                    Area = Decimal.Parse(columns[5]),
                    CostPerSquareFoot = Decimal.Parse(columns[6]),
                    LaborCostPerSquareFoot = Decimal.Parse(columns[7]),
                    MaterialCost = Decimal.Parse(columns[8]),
                    LaborCost = Decimal.Parse(columns[9]),
                    Tax = Decimal.Parse(columns[10]),
                    Total = Decimal.Parse(columns[11]),
                };
                orders.Add(order);
            }
            return orders;
        }

        private bool TryFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
