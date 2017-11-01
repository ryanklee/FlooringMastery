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

        
        private static void TryAccountFile(string TestFilePath)
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

        private static string ReadEntry(string AccountNumber, string TestFilePath)
        {
            string path = TestFilePath;

            TryAccountFile(TestFilePath);

            string[] rows = File.ReadAllLines(path);

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

        private static Account ReadFileAccountData(string accountData)
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

        public Account LoadAccount(string AccountNumber)
        {

            string accountData = ReadEntry(AccountNumber, TestFilePath);

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
            // _account = account;

            throw new NotImplementedException();
        }

    }
}
