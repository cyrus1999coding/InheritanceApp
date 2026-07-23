# Constructor Inheritance  

Recap of `Constrcutors` :  

`Constrcutors` are **special** `Method`s in a `Class` that are called when an `Instance` of the Class is created .  
In the context of `Inheritance`, `Constructors` of the `Base Class`  
are called before the `Constructors` of the `Derived CLass` .  
This ensures that the `Base Class` is properly initializd before any additional initialization in the `Derived CLass` takes place .  

So why does the Constructor Inheritance matter ❔  
💡 :  
1. Proper initialization :  
  Ensure that all `Fields` & `Properties` of the `Base Class` are correctly set up before any Operatins of  
  the `Derived Class` can take place .  
  This means that when creating an Object of a `Derived Class`, The `Constructor` of the `Base Class` runs  
  first to Initialize it's members .
  Otherwise this could add bunch of challenges and Errors along the way when we trying to Access something that isn't Initialized yet . 
2. Consistent State :  
  Maintains a consistent and Valid `State` across the `Object` Hirerarchi .  
  This ensures that both `Base Class` & `Derived Class` remain in a Valid `State` throughout the `Object`'s Lifetime .  
  By running the `Base Class` `Constructor` first, We ensure that any `Dependency` or require initial `States` are established .
3. Reuse of Initialization Code :  
  Acoids duplication of Initialization code by Re-using the `Base Class` `Constructor` .  
  This means that common setup tasks needed by both the `Base` and `Derives` `Classes` are handled once in the  
  `Base Class` `Constructor`,  
  Maing the code cleaner and reducing Errors .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36);
            joe.DisplayPersonInfo();

            Console.ReadKey();
        }
    }

    
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; set; }

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
    }

    public class Employee : Person
    {
        public Employee(string name, int age) : base(name, age) 
        {
            Console.WriteLine("Employee (Derived Class) Construtor called !");
        }
    }
}
```

Now instead of hacing just the Name, Age `Peoperties` we also have `JobTitle` and `EmployeeId` : 

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36);
            joe.DisplayPersonInfo();

            Console.ReadKey();
        }
    }

    
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; set; }

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
    }

    public class Employee : Person
    {   
        👇
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }
        👆
        public Employee(string name, int age,string jobTitle, int employeeID) : base(name, age) 👈
        {
            JobTitle = jobTitle; 👈
            EmployeeID= employeeID; 👈

            Console.WriteLine("Employee (Derived Class) Construtor called !");
        }
    }
}
```
- Now in our `Derived Class` we need to do a few things :  
  1. First we need to Assign the `name` and the `age` .  
  2. Then we also need to Assign the `jobTitle` and the `employeeID` .  
- What we're passing on to the `Base Class` is the `name` and the `age` and by doing this → `: base(name, age)`  
  🔑 We're calling the `Base Class` `Constructor` .  
  🧠 )  
  ```cs
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine("Person Constructor called");
    }
  ```
  It needed a `name` and an `age` which we get it from →` public Employee(string name👈, int age👈,string jobTitle, int employeeID) : base(name, age)`  
  🔑 So Whenever we creating an `Employee` we need to pass in the `name` and the `age`, and we're passing those furture to the `Base Constructor`,  
  Which then sets those up and does all of the magic that is required there .  
  And in the next step we're setting the `jobTitle` and the `employeeID` .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36);
            joe.DisplayPersonInfo();

            Console.ReadKey();
        }
    }


    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Person Constructor called");
        }

        public void DisplayPersonInfo() 👈
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
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
        👇
        public void DisplayEmployeeInfo()
        {

            DisplayPersonInfo();
            Console.WriteLine($"Job title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
        👆
    }
}
```
- 🔑 We can jsut call `DisplayPersonInfo` `Method` → `Person.DisplayPersonInfo`  
  Without having to create an Object of our `Person Class` .  
  We can jsut call it's `Methods` Directly as if they were in the same `Class` .

So now let's create an `Employee` ↓  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            👇
            Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            joe.DisplayEmployeeInfo();
            👆

            Console.ReadKey();
        }
    }


    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Person Constructor called");
        }

        public void DisplayPersonInfo() 👈
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
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

            DisplayPersonInfo(); 👈
            Console.WriteLine($"Job title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
    }
}
```

```console
Person Constructor called
Employee (Derived Class) Construtor called !
Name: Joe, Age: 36 
Job title: Sales Rep, EmployeeID: 1234
```

- `joe.DisplayEmployeeInfo();` :  
  Internally will also call `Person.DisplayPersonInfo` `Method`
- `Name: Joe, Age: 36` :  
  This is comming from the `Person Class` ↓  
  ```cs
    public void DisplayPersonInfo() 👈
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
  ```
- Job title: Sales Rep, EmployeeID: 1234 :  
  This is comming from the `Employee Class` ↓  
  ```cs
    public void DisplayEmployeeInfo()
    {

        DisplayPersonInfo(); 👈
        Console.WriteLine($"Job title: {JobTitle}, EmployeeID: {EmployeeID}");
    }
  ```

So here we see how all of this is coming together .