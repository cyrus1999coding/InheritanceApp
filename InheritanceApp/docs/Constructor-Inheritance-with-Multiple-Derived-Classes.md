# Constructor Inheritance with Multiple Derived Classes  

An Employee can have Multiple different positions and each of those positions could be categorized into a category like for example  
Manger or Developer or HR or whatever .  

So we're going to create a new Class :

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            joe.DisplayEmployeeInfo();

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
    👇
    public class Manager : Employee
    { 
    }
    👆
}
```
- So this is another layer to our `Inheritance` ( 🔑`Multi level Inheritance` )
- We definintly need `Constructor` using the `IDE` helpers we can build this ↓ .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            joe.DisplayEmployeeInfo();

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
    👇
    public class Manager : Employee
    {
        public Manager(string name, int age, string jobTitle, int employeeID) : base(name, age, jobTitle, employeeID)
        {
        }
    }
    👆
}
```

And now we can add more `Properties` to our `Manager` `Class` ↓

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            joe.DisplayEmployeeInfo();

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
    👇
    public class Manager : Employee
    {
        public int TeamSize { get; private set; } 👈

        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize 👈) : base(name, age, jobTitle, employeeID)
        {
            TeamSize = teamSize; 👈
        }
    }
    👆
}
```
- `public int TeemSize { get; private set; }` :  
  This is a `Property` that is specific to the `Manger`
- And at this point we also add more details to the `Manger` → `TeamSize = teamSize;`

Now on top of that we're going to use another Method that will be `Manger.DisplayManagerInfo` ↓  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            joe.DisplayEmployeeInfo();

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
        👇
        public void DisplayManagerInfo()
        {

            DisplayEmployeeInfo();
            Console.WriteLine($"Team size: {TeamSize}"); 
        }
        👆
    }
}
```

So now when we're creating an `Object` of our `Manager` we're going to see how all if comes together ↓  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee joe = new Employee("Joe", 36, "Sales Rep", 1234);
            //joe.DisplayEmployeeInfo();
            👇
            Manager carl = new Manager("Carl", 45, "Manger", 123123, 7);
            carl.DisplayManagerInfo();
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
        👇
        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
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
        👇
        public void DisplayEmployeeInfo()
        {
            
            DisplayPersonInfo(); 👈
            Console.WriteLine($"Job title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
        👆
    }

    public class Manager : Employee
    {
        public int TeamSize { get; private set; }

        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize) : base(name, age, jobTitle, employeeID)
        {
            TeamSize = teamSize;
        }
        👇
        public void DisplayManagerInfo()
        {

            DisplayEmployeeInfo(); 👈
            Console.WriteLine($"Team size: {TeamSize}");
        }
        👆
    }
}
```

```console
Person Constructor called
Employee (Derived Class) Construtor called !
Name: Carl, Age: 45
Job title: Manger, EmployeeID: 123123
Team size: 7
```

- So we see that these are 3 Layers that we're now calling and we're using pretty much most of the things that we've learned about `Inheritance` so far .
- 🔑🔑 Coll thing is that we see that what we just did works on Multiple Levels and with **Multiple** `Derived Classes` .

Now we might understand why its so importnat that once a `Base Class` is built we shouldn't just  
`Edit` it if there are bunch of `Derived Classes` .  
Because then we also have to Edit the `Deriving Classes` potentially let's see this ↓  

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
            carl.DisplayManagerInfo();

            Console.ReadKey();
        }
    }


    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; } 👈

        public Person(string name, int age, string address 👈)
        {
            Name = name;
            Age = age;
            Address = address; 👈
            Console.WriteLine("Person Constructor called");
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }
        public Employee(string name, int age, string jobTitle, int employeeID) : ❌base(name, age)
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

        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize) : ❌base(name, age, jobTitle, employeeID)
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
- ❌ So we see this will cause all kinda of Errors  
  📝 : Even now we have full control over full code imagine if we were only working with `Employee` `Class`  
  And we we'rent aware that the `Person Class` has been Updated and now our code suddenly doesn't work anymore .

## Things to remember :  

`Constructor Chaning` :  
Ensures Proper Setup .  
When creating an Object from a `Derived Class`, It's `Constructor` should call the `Base Class` `Constructor` .  
This ensures the `Base Class` is propertly initialized before the `Dervied Class` adds its own setup .

`Order of Execution` :  
`Base Class` First .  
The `Base Class` `Constructor` runs before the `Derived Class` `Constructor` .  
This gurantees that all necessary initializations in the `Derived Class` are done before specific setup in the `Derived Class` starts .
 
`Custom Initialization` :  
 Adding Unique Setup .  
 `Derived Classes` can include their own initialization code and Parameters in addition to what the `Base Class` provides .  
 This allows them to **extend**  the functionailty while still using the common setup code from the `Base Class` .

`Flexibility and Reuse` :  
Promotes Clean Code .  
Using `Constructor Inheritance` increases Flexibility and code Reuse .  
It helps build complex `Class Hierarchies` while keeping the code clean and maintainable .