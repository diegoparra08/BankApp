using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class UserControlInterface //This class interacts with the user and the app
    {
        private Bank _bank;

        public UserControlInterface(Bank bank)
        {
            _bank = bank;
        }

        public void AddAccount()
        {
            ClearConsole();
            Console.WriteLine("Agregar Cuenta...");
            int newAccountNumber = 0;
            Random newNumber = new Random();
            newAccountNumber = newNumber.Next(1000, 9000);
            string finalNewAccountNumber = String.Format($"{newAccountNumber}");
            BankAccount newaccount = new BankAccount();
            Console.Write($"Ingrese Nombre: ");
            newaccount.FullUserName = Console.ReadLine();
            newaccount.AccountNumber = finalNewAccountNumber;
            newaccount.Balance = 0; //Tal vez sea necesario reemplazar esto más tarde si se tiene problemas con el saldo.
            _bank.AddBankAccount(newaccount);
            Console.WriteLine("Se ha abierto la cuenta {0} con Exito", finalNewAccountNumber);
            PressKeyToContinue();


        }

        public void PrintAccountInfo()
        {
            Console.WriteLine("Buscar Cuenta...");
            Console.Write("Ingrese el número de cuenta: ");
            string accountToSearch = Console.ReadLine();
            _bank.SearchByACccountNumber(accountToSearch);

            BankAccount bank = _bank.SearchByACccountNumber(accountToSearch); //Se crea uba instacia de Contacto que se
            // iguala a _agenda (la instacia de Clase agenda en ControlAgenda) y se usa el método buscar por nombre de
            //la clase agenda
            if (accountToSearch != null) //se verifica que el dato ingresado por el user no sea nulo
            {
                Console.WriteLine("Datos: \n" + accountToSearch);
            }
            else
            {
                Console.WriteLine("No se encontro ningun resultado");

            }
        }
  
            /*   public string DeleteAccount()
               {
                   Console.WriteLine("Eliminar Cuenta...");
                   Console.Write("Por favor Introduzca su numero de cuenta: ");
                   string accounttoDelete = Console.ReadLine();
                   _bank.SearchAccount(accounttoDelete);
                   if (accounttoDelete != null) { return accounttoDelete; }
                   Console.WriteLine(accounttoDelete);

                   return null;

               } */

            private void ClearConsole()
            {
                Console.Clear();
            }

            private void PressKeyToContinue()
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

    }
