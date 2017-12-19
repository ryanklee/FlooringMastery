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
    public class TaxProductionRepository : ITaxRepository
    {
        public List<Tax> LoadTaxes()
        {
            string filePath = $@"..\..\..\FM.Data\Repositories\Production\Data\Taxes.txt";

            if (!File.Exists(filePath))
            {
                return null;
            }

            else
            {
                List<Tax> taxes = LoadFileData(filePath);
                return taxes;
            }
        }

        private List<Tax> LoadFileData(string filePath)
        {
            TryFile(filePath);
            List<Tax> taxes = new List<Tax>();

            string[] rows = File.ReadAllLines(filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                Tax tax = new Tax()
                {
                    StateAbbreviation = columns[0],
                    StateName = columns[1],
                    TaxRate = Decimal.Parse(columns[2])
                };

                taxes.Add(tax);
            }
            return taxes;
        }

        private void TryFile(string filePath)
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
                Console.WriteLine(ex);
            }
        }
    }
}
