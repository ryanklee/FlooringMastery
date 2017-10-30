using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if (response.Account.Type != AccountType.Basic && 
                response.Account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: Only basic and premium accounts can deposit with no limit. Contact IT";
                return response;
            }

            if (amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be positive!";
                return response;
            }

            response.Success = true;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;
            return response;
        }
    }
}
