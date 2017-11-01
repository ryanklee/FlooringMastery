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
    public class FileAccountRepository : IAccountRepository
    {
        public string TestFilePath { get; set; }

        public FileAccountRepository()
        {
            TestFilePath = @"C:\Users\rylkl\Code\ryan-kleeberger-individual-work\SGBank\SGBank.Data\Accounts.txt";
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

            string[] rows = File.ReadAllLines(TestFilePath);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                if (columns[0] == account.AccountNumber)
                {
                    columns[1] = account.Name;
                    columns[2] = account.Balance.ToString();

                    switch (account.Type)
                    {
                        case AccountType.Free:
                            columns[3] = "F";
                            break;
                        case AccountType.Basic:
                            columns[3] = "B";
                            break;
                        case AccountType.Premium:
                            columns[3] = "P";
                            break;
                    }
                }
            }
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
