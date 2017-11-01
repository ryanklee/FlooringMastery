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
        List<Account> fileAccountData = ReadFileAccountData();
        
        private static void TryAccountFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader("Accounts.txt"))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static string FindEntry(string AccountNumber)
        {
            string path = @"Accounts.txt";

            TryAccountFile();

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

        private static List<Account> ReadFileAccountData()
        {
            string path = @"Accounts.txt";

            TryAccountFile();

            string[] rows = File.ReadAllLines(path);

            List<Account> fileAccountData = new List<Account>();

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                fileAccountData[i].AccountNumber = columns[0];
                fileAccountData[i].Name = columns[1];
                fileAccountData[i].Balance = Decimal.Parse(columns[2]);

                switch (columns[3])
                {
                    case "F":
                        fileAccountData[i].Type = AccountType.Free;
                        break;
                    case "B":
                        fileAccountData[i].Type = AccountType.Basic;
                        break;
                    case "P":
                        fileAccountData[i].Type = AccountType.Premium;
                        break;
                }
            }

            return fileAccountData;
        }

        //private static Account _account = new Account
        //{
        //    AccountNumber = "33333",
        //    Name = "Basic Account",
        //    Balance = 100M,
        //    Type = AccountType.Basic
        //};

        public Account LoadAccount(string AccountNumber)
        {

                if (FindEntry(AccountNumber) != null)
                    return _account;
                else
                    return null;
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }

    }
}
