using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_6
{
    internal class Program
    {
        public class BankAccount
        {
            private int accountNumber, balance;
            private string ownerName;
            public BankAccount(int accountNumber = 0, int balance = 0, string ownerName = "")
            {
                this.accountNumber = accountNumber;
                this.balance = balance;
                this.ownerName = ownerName;
            }
            // Methods
            public void Deposits(int amount)
            {
                this.balance += amount;
            }
            public void WithDraw(int amount)
            {
                this.balance -= amount;
            }
            public void Transfer(BankAccount targetAccount, int amount)
            {
                this.balance -= amount;
                targetAccount.balance += amount;
            }
            public int GetBalance()
            {
                return this.balance;
            }
            public void DisplayInfo()
            {
                Console.WriteLine("Account Number: " + this.accountNumber);
                Console.WriteLine("Owner Name: " + this.ownerName);
                Console.WriteLine("Balance: " + this.balance);
            }
        }
        static void Main(string[] args)
        {
            BankAccount Ahmed = new BankAccount(12345, 5000, "Ahmed");
            BankAccount Sara = new BankAccount(67890, 3000, "Sara");
            Ahmed.Deposits(1000);
            Ahmed.WithDraw(500);
            Ahmed.Transfer(Sara, 2000);
            Ahmed.DisplayInfo();
            Sara.DisplayInfo();
        }
    }
}
