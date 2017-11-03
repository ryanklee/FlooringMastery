using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountTestRepository : IAccountRepository
    {
        public string TestFilePath { get; set; }

        public FileAccountTestRepository()
        {
            DirectoryInfo info = new DirectoryInfo(".");

            TestFilePath = @"..\..\..\SGBank.Data\\Accounts.txt";
        }

        private void TryAccountFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(TestFilePath))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private string ReadEntry(string AccountNumber)
        {

            TryAccountFile();

            string[] rows = File.ReadAllLines(TestFilePath);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                if (columns[0] == AccountNumber)
                {
                    return rows[i];
                }

            }
            return null;
        }

        private Account ReadFileAccountData(string accountData)
        {
            string[] accountFields = accountData.Split(',');

            Account account = new Account()
            {
                AccountNumber = accountFields[0],
                Name = accountFields[1],
                Balance = Decimal.Parse(accountFields[2])
            };

            switch (accountFields[3])
            {
                case "F":
                    account.Type = AccountType.Free;
                    break;
                case "B":
                    account.Type = AccountType.Basic;
                    break;
                case "P":
                    account.Type = AccountType.Premium;
                    break;
            }

            return account;
        }

        private void WriteAccountData(Account account)
        {
            TryAccountFile();

            List<string> accountEntries = new List<string>(File.ReadAllLines(TestFilePath));
            List<string> newEntries = new List<string>();
            
                foreach (string entry in accountEntries)
                {
                    string[] accountFields = entry.Split(',');

                    if (accountFields[0] != account.AccountNumber)
                    {
                        newEntries.Add(entry);
                    }
                    else
                    {
                        string updatedEntry = $"{accountFields[0]},{accountFields[1]},{account.Balance.ToString()},{accountFields[3]}";
                        newEntries.Add(updatedEntry);
                    }
                }

            File.WriteAllLines(TestFilePath, newEntries);
        }

        public Account LoadAccount(string AccountNumber)
        {

            string accountData = ReadEntry(AccountNumber);

            if (accountData != null)
            {
                Account account = ReadFileAccountData(accountData);
                return account;
            }
            else
                return null;
        }

        public void SaveAccount(Account account)
        {
            WriteAccountData(account);
        }

    }
}
