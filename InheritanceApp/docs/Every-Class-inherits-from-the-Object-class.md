# Every Class inherits from the Object class  

🔑🔑 We want to see why every single `Class` in C# is Inheriting from the 🔑`Object` `Class` .  

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

            carl. 👈

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
- `carl.` :  
  - `.Age`
  - `.EmpolyeeID`
  - `.DisplayManagerInfo`
  - `.DisplayPersonInfo`
  - `.DisplayEmployeeInfo`
  - `.DisplayManagerInfo`
  - `.JobTitle`
  - `.Name`
  - `.TeamSize`
  - `.Equals` 👈 bool object.Equals(object? obj) :  
    Comparing 2 `Objects` to each other .  
  - `.GetHashCode` 👈
  - `.GetType` 👈 
  - `.ToString` 👈 string? object.ToSrting() :  
    Returns a string that represents the current object.
- We See some `Methods` that we never created ourselves like, All of these are  
  `Methods` that are inside of the 🔑`Object` `Class`

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

            Console.WriteLine(carl.ToString()); 👈

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
InheritanceApp.Manager 👈
```

- `InheritanceApp.Manager `:  
  So that's all info that we get from this `ToString` `Method`
  if we jump to definition `CTRL + LEFT CLICK` or `F12` ↓  
  ```cs
    // Licensed to the .NET Foundation under one or more agreements.
    // The .NET Foundation licenses this file to you under the MIT license.

    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;

    namespace System
    {
    // The Object is the root class for all object in the CLR System. Object
    // is the super class for all other CLR objects and provide a set of methods and low level
    // services to subclasses.  These services include object synchronization and support for clone
    // operations.
    //
    [Serializable]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public partial class Object 👈
    {
        // Creates a new instance of an Object.
        👇
        [NonVersionable}
        public Object()
        {
        }
        👆
        👇
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public virtual string? ToString()
        {
            // The default for an object is to return the fully qualified name of the class.
            return GetType().ToString();
        }
        👆
        👇
        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public virtual bool Equals(object? obj)
        {
            return this == obj;
        }
        👆
        👇
        public static bool Equals(object? objA, object? objB)
        {
            if (objA == objB)
            {
                return true;
            }
            if (objA == null || objB == null)
            {
                return false;
            }
            return objA.Equals(objB);
        }
        👆
        👇
        [NonVersionable]
        public static bool ReferenceEquals(object? objA, object? objB)
        {
            return objA == objB;
        }
        👆
        👇
        /// <summary>Serves as the default hash function.</summary>
        /// <returns>A hash code for the current object.</returns>
        public virtual int GetHashCode()
        {
            // GetHashCode is intended to serve as a hash function for this object.
            // Based on the contents of the object, the hash function will return a suitable
            // value with a relatively random distribution over the various inputs.
            //
            // The default implementation returns the sync block index for this instance.
            // Calling it on the same object multiple times will return the same value, so
            // it will technically meet the needs of a hash function, but it's less than ideal.
            // Objects (& especially value classes) should override this method.

            return RuntimeHelpers.GetHashCode(this);
        }
        👆
        ...

    }
    .
    .
    .

  ```
  - This Object Class is under the `System` `namespace`
  - has some 🔑`Modifications` → `[Serializable]`, `[ClassInterface(ClassInterfaceType.AutoDispatch)]`, ... ( Advance Stuff )
  - `public partial class Object` :  
    🔑 what matters is that we can see this `Object` is a `Class` .  
    We're gonna see what 🔑`partial classes` are later on .
  - We can see it has a Construcroe ↓  
    ```cs
        [NonVersionable]
        public Object()
        {
        }
    ```
    - `[NonVersionable]` :  
      Aagain in has 🔑🔑`Notaion` like up the file like the `[Serializable]`, `[ClassInterface(ClassInterfaceType.AutoDispatch)]`, ...  
      Let's not worry about those .
  - `public virtual string? ToString()` :  
    Then we see this `ToString` `Method` which is the one that we just used .  
    goint to `GetType()` is a bit too far for this video  at this point of the course  
    But we're fine that it gets the Type and then transfer and gives us the string .
  -` public virtual bool Equals(object? obj)` :  
    Allows us to compare two `Objects` ↓  
    ```cs
    public virtual bool Equals(object? obj)
    {
        return this == obj;
    }
    ```
    🔑`this` `Object` is calling the `Method` itself, is equal to the Object that we're passing to the `Equals(object? obj)` .
  - `public static bool 🔑ReferenceEquals(object? objA, object? objB)` 
  - `public virtual int 🔑GetHashCode()` :  
    Allows to create a 🔑`randomized has code` which then makes this `Object` 🔑`Unique`,  
    So every single `Object` gets its own `hash code` and with the `hash code` we can compare them to each other .  
    And we can find out whether they are the same `Object` or not .

So we can see differnet `Methods` that do different things we can read throught the summary and get better understanding .

📝 : So we saw this is whats going on and 🔑🔑 every single `Class` in C# is `Inheriting` from the `Object` `Class` .  
Which allows us to use `Methods` such as `.ToString` onto a `Class` `Instance`/`Object` which we have created ourselves like the `Manager` without having implemented this `Method` .