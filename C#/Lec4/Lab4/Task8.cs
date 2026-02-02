using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task8
    {
        public interface IPrintable
        {
            void PrintDetails();
        }
        public interface ITransactable
        {
            void Deposit(double amount);
            void Withdraw(double amount);
        }
        public abstract class Account : IPrintable, ITransactable
        {
            protected int accountNumber;
            protected double balance;
            protected string ownerName;
            public int AccountNumber
            {
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Account Number must be positive.");
                    this.accountNumber = value;
                }
                get { return this.accountNumber; }
            }
            public double Balance
            {
                get { return this.balance; }
            }
            public string OwnerName
            {
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Owner Name cannot be empty.");
                    this.ownerName = value;
                }
                get { return this.ownerName; }
            }
            // Override method to print account details
            public void PrintDetails()
            {
                Console.WriteLine("Account Number: {0}", this.accountNumber);
                Console.WriteLine("Owner Name: {0}", this.ownerName);
                Console.WriteLine("Balance: {0}", this.balance);
            }
            // Override methods
            public virtual void Deposit(double amount)
            {
                this.balance += amount;
            }
            public virtual void Withdraw(double amount)
            {
                this.balance -= amount;
            }
            // Abstract method to calculate interest
            public abstract double CalculateInterest();
        }
        public class SavingsAccount : Account
        {
            protected int interestRate;
            protected int minimumBalance;

            public override double CalculateInterest()
            {
                return balance * interestRate;
            }
            public override void Withdraw(double amount)
            {
                if(balance - amount >= minimumBalance)
                    this.balance -= amount;
            }

        }
        public class CheckingAccount : Account
        {
            protected int overdraftLimit;
            protected int freeTransactions;
            public CheckingAccount(int overdraftLimit, int freeTransactions)
            {
                this.OverDraftLimit = overdraftLimit;
                this.freeTransactions = freeTransactions;
            }
            public int OverDraftLimit
            {
                set
                {
                    this.overdraftLimit = value;
                }
                get
                {
                    return this.overdraftLimit;
                }
            }
            public int FreeTransactions
            {
                set
                {
                    this.freeTransactions = value;
                }
                get
                {
                    return this.freeTransactions;
                }
            }
            public override double CalculateInterest()
            {
                return 0;
            }
            public override void Withdraw(double amount)
            {
                if (balance - amount <= overdraftLimit)
                    this.balance -= amount;
            }
        }
        public static void task8()
        {
            //Account account = new Account();

        }
    }
}
