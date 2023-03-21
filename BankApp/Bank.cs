using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Bank : BankAccount
    {
        public const int Size = 32;
        public int index = 0;
        public BankAccount[] bankAccounts;

        public Bank()
        {
            index = 0;
            bankAccounts = new BankAccount[Size];
        }

        public void AddBankAccount(BankAccount account)

        {
            if (index < Size)
            {
                bankAccounts[index] = account;
                index++;
            }
            else
            {
                Console.WriteLine("No se puede crear una nueva cuenta. Espacio lleno.");
            }
        }
        public void DeleteBankAccount(BankAccount account)
        {

        }

        public void MostrarAccount()

        {
            Console.WriteLine(this);
        }
        public BankAccount SearchByACccountNumber(string account) //Se especifica que se recibirá info del user en forma string lo que 
                                                                  //el user busque se llamara nombre en este ejercicio
        {
            foreach (BankAccount accountts in bankAccounts) //(Contacto porque es el tipo de info que buscara)
            {
                if (accountts != null && accountts.AccountNumber == account)
                {
                    return accountts;
                }
            }
            return null;
        }
    }
}



  




