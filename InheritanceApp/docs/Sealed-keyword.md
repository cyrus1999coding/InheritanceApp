# Sealed keyword

🔑`sealed` **Keyword** :  
Makes sure that a Class can not be `Inherited` from .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            //joe.DisplayEmployeeInfo();

            Manager carl = new Manager("Carl", 45, "Manger", 123123, 7);
            //carl.DisplayManagerInfo();
            carl.BecomeOlder(5);

            carl.DisplayPersonInfo();

            Console.WriteLine(carl.ToString());

            Console.ReadKey();
        }
    }


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

    public sealed👈 class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }
        public Employee(string name, int age, string jobTitle, int employeeID) : base(name, age)
        {
            JobTitle = jobTitle;
            EmployeeID = employeeID;

            Console.WriteLine("Employee (Derived Class) Construtor called !");
        }

        public void DisplayEmployeeInfo()
        {

            DisplayPersonInfo();
            Console.WriteLine($"Job title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
    }

    public class Manager : Employee❌
    {
        public int TeamSize { get; private set; }

        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize) : base(name, age, jobTitle, employeeID)
        {
            TeamSize = teamSize;
        }

        public void DisplayManagerInfo()
        {

            DisplayEmployeeInfo();
            Console.WriteLine($"Team size: {TeamSize}");
        }
    }
}
```
- ❌ : 'Manager': cannot derive from sealed type 'Employee'
- `public sealed👈 class Employee : Person` :  
  This way we sealed the `Employee` `Class` from `Inheritance`

Why we use it ❔  
💡 :  
Let's look at an example ↓  

👀 )

```cs
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
}
```

```console
Deposited $200.00. New balance is $700.00.
Withdraw $100.00. New balance is $600.00.
Insufficient funds. Cannot withdraw from a saving account.
```

## Reasons to use the `sealed` **Keyword** :  

1. Design Integrity :  
  `Sealing` a `Class` ensures that its design is final and cannot be altered through `Inheritance` .  
  This is crusial when you want to enforce specific behavior and prevent Modifications that could compromise the design .  
  👀 )  
  In the Banking Application, The `SavingAccount` `Class` has specific withdrawl rules that should not be `overridden` by any further `Derived Class` .  
  ```cs
  public class SavingAccount : Account
  {
      public override void Withdraw(decimal amount)
      {
          if (amount <= Balance)
          {
              base.Withdraw(amount);
          }
          else
          {
              Console.WriteLine("Insufficient funds.");
          }
      }
  }
  ```
  Now someone could create another class:

  ```cs
    public class SuperSavingAccount : SavingAccount
    {
        public SuperSavingAccount(string accountNumber, decimal balance)
        : base(accountNumber, balance)
        {
        }

        public override void Withdraw(decimal amount)
        {
            // Ignore all saving account rules!
            Console.WriteLine("Withdrawal approved.");

            // Imagine this also allows negative balances.
        }
    }
  ```

  Or even worse:

  ```cs
    public override void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
  ```

  This completely ignores the validation that the SavingAccount class was designed to enforce.

2. Security :  
  Preventing further Inheritance can enhance security by avoiding unintended behavior or misuse .  
  By sealing a `Class`, you ensure that critical functionality remains consistent and secure .  
  👀 )  
  By sealing the `SavingAccount` `Class`, You ensure that no Un-Authorized or accidental changes can be made  
  to how withdrawl are processed,  
  Maintaining the security of the account Operations .

3. Performance :  
  `Sealed Classes` can sometimes lead to performance optimizations .  
  🚀 The `Runtime` doesn't need to check for `Method` `Overrides` in `Derived Classes`, Leading to faster execution .  
  👀 )  
  In High-Performance applications, `Sealing Classes` not meant to be extended can reduce the `overhead` of `virtual` `Method` calls .  
  Providing slight Performance gains .

4. Preventing Missue :  
  Sealing a `Class` prevents it from being used as a `Base Class`, Which can be important if the `Class`  
  Wasn't desingned with `Exensibility` in mind .  
  Avoiding potential misuse or Errors from improper extensions .  
  👀 )  
  If `SavingAccount` is not meant to be `Extended` with additional account Types or behaviors,  
  Sealing it ensures Developers do not mistakenly try to extend it .