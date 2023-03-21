using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class BankAccount
    {
        public string FullUserName { get; set; }
        public string AccountNumber { get; set; }

        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value < 0 ? 0 : value; }
        }

        public BankAccount() { }
        public BankAccount(string fullUserName, string accountNumber, decimal initialBalance)
        {
            FullUserName = fullUserName;
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        #region Equals and hashcode

        public int CompareTo(BankAccount otro)
        //Se debe usar de esta forma para poder usar la comparacion por nombre. Cuando es strings no se pone 
        //ningun operador de comparacion (< > == )
        {

            return AccountNumber.CompareTo(otro.AccountNumber);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)

            {
                return false;
            }
            BankAccount user = obj as BankAccount;
            if (user == null)
            {
                return false;
            }

            return string.Equals(AccountNumber, user.AccountNumber) && string.Equals(FullUserName, user.FullUserName);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashFullUserName = (FullUserName != null ? FullUserName.GetHashCode() : 0);
                int hashAccountNumber = (AccountNumber != null ? AccountNumber.GetHashCode() : 0);

                return (hashFullUserName * 397) ^ (hashAccountNumber);
            }
        }
        #endregion

        public override string ToString()
        {
          return string.Format($"Nombre: {FullUserName} | N° Cuenta: {AccountNumber} | Saldo: {_balance:C1}");
        }

        public void Deposit(decimal Amount)
        {
            Balance += Amount;
        }
        public void Withdraw(decimal Amount)
        {
            if (Balance >= Amount)
            {
                Balance -= Amount;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para completar esta operación");
            }
        }

    }
}
