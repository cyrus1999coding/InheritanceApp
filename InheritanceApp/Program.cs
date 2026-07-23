using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingAccount mySavings = new SavingAccount("123123123", 500.00m);
            mySavings.Deposit(200.00m);
            mySavings.Withdraw(100.00m);
            mySavings.Withdraw(700.00m); // Should show insufficient funds message

            /*
            //Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            //joe.DisplayEmployeeInfo();

            Manager carl = new Manager("Carl", 45, "Manager", 123123, 7);
            //carl.DisplayManagerInfo();
            carl.BecomeOlder(5);

            carl.DisplayPersonInfo();

            Console.WriteLine(carl.ToString());

            Console.ReadKey();
            */
        }
    }

    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdraw {amount:C}. New balance is {Balance:C}.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }

    public sealed class SavingAccount : Account
    {
        public SavingAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance)
        {

        }

        public override void Withdraw(decimal amount)
        {
            // Saving account specific withdrawal logic, e.g., no overdrafts allowed
            if (amount <= Balance)
            {
                base.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds. Cannot withdraw from a saving account.");
            }
        }
    }

    /*
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;

            Console.WriteLine("Person Constructor called");
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        /// <summary>Makes our object older</summary>
        /// <param name="years">This is the parameter that holds the amount of years that object should age</param>
        /// <returns>Returns the new age after aging/becoming older</returns>
        public int BecomeOlder(int years)
        {
            Age = Age + years;

            return Age;
        }
    }

    public sealed class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }

        public Employee(string name, int age, string jobTitle, int employeeID)
            : base(name, age)
        {
            JobTitle = jobTitle;
            EmployeeID = employeeID;

            Console.WriteLine("Employee (Derived Class) Constructor called!");
        }

        public void DisplayEmployeeInfo()
        {
            DisplayPersonInfo();
            Console.WriteLine($"Job title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
    }

    public class Manager : Employee
    {
        public int TeamSize { get; private set; }

        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize)
            : base(name, age, jobTitle, employeeID)
        {
            TeamSize = teamSize;
        }

        public void DisplayManagerInfo()
        {
            DisplayEmployeeInfo();
            Console.WriteLine($"Team size: {TeamSize}");
        }
    }
    */
}