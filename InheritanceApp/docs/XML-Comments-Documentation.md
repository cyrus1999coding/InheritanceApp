# XML Comments Documentation

In the last lecture we looked at `Object` `Class`  and there we saw these very Special Comments ↓  

```cs
        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public virtual bool Equals(object? obj)
        {
            return this == obj;
        }
```
- `///` :  
  Is special comment and it's used in this case a vary coll little thingn that we're going to use it for ourseleves .  


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
        👇

        /// <summary>Makes our object older</summary>
        /// <param name="years">This is the parameter that holds the amount of years that object should age</param>
        /// <returns>Returns the new age after aging/becoming older</returns>
        public int BecomeOlder(int years)
        {
            Age = Age + years;

            return Age;
        }
        👆
    }

    public class Employee : Person
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

    public class Manager : Employee
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

Where all of these stuff will be displayes ❔  
💡 :  
Once we hower over the `Method` .

Now let's use this `Person.BecomeOlder` `Method` ↓  

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
            carl.BecomeOlder(5); 👈

            carl.DisplayPersonInfo(); 👈

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
        👇
        /// <summary>Makes our object older</summary>
        /// <param name="years">This is the parameter that holds the amount of years that object should age</param>
        /// <returns>Returns the new age after aging/becoming older</returns>
        public int BecomeOlder(int years)
        {
            Age = Age + years;

            return Age;
        }
        👆
    }

    public class Employee : Person
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

    public class Manager : Employee
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

```console
Person Constructor called
Employee (Derived Class) Construtor called !
Name: Carl, Age: 50
InheritanceApp.Manager
```

- So what we have here is 🔑`XML Comment`/🔑`XML Documention` and they are only for us as Developers to make our lif easier  
  When working on code .
- `/// <param name="years">This is the parameter that holds the amount of years that object should age</param>` :  
  When hover over the `Parameter` we see the statement that we put there .