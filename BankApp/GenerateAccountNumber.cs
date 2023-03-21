using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class GenerateAccountNumber
    {
        int newAccountNumber = 0;
       public string finalNewAccountNumber = "";
        public string NewAccountNumber
        {
            get { return finalNewAccountNumber; }

            set { finalNewAccountNumber = value; }
        }


        public void GenerateNumber()
        {
            
            Random newNumber = new Random();
            newAccountNumber = newNumber.Next(1000, 9000);
            string finalNewAccountNumber = String.Format($"{newAccountNumber}");
        }
    }
}
