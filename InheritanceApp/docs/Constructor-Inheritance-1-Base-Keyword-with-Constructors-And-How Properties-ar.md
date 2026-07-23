# Constructor Inheritance 1 - Base Keyword with Constructors and How Properties ar  

We're going to look at how 🔑`Properties` are `Inherited` . We're going to start see 🔑`Constructor Inheritance` .

```cs
    class Person
    {
        public Person()
        {
            Console.WriteLine("Person Constructor called");
        }

        public void DisplayPersonInfo()
        {
        }
    }
```

```cs
    class Person
    {
        public string Name { get; private set; } 👈
        public int Age { get; set; } 👈

        ⚠public Person()
        {
            Console.WriteLine("Person Constructor called");
        }

        public void DisplayPersonInfo()
        {
        }
    }
```
- `public string Name { get; 🔑private set; }` :  
  So nobody else can `set` the Name exept our Person `Class` .
- `public int Age { get; set; }` :  
  So nobody else can `set` the Age exept our Person `Class` .
- Now we see the `Person` `Constructor` ↓  
  ⚠ : Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.  

🛠 So let's set those :  

```cs
    class Person
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
        }
    }

```
- This is nothing new we seen this multiple times .

Now how does tat work for `Inherited Classes` ❔  
💡 :  
We're go create another `Class` .  

```cs
    class Person
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
        }
    }

    ❌class Employee : Person
    {

    }
```
- ❌ : There is no argument given that corresponds to the required parameter 'name' of 'Person.Person(string, int)' .  
  📝 : This means that we need to Assign a name and an int for our `Person` .  
  ✅🔑🛠 :  
  We could go ahead and create `Peroperties` → `Name` :  
  ```cs
    class Employee : Person
    {
        public string Name { get; private set; } ...
    }
  ```
  🔑🔑🚀 : We don't have to because the Parent already has these `Properties`, it's going to `Inherit` them  
  Over to us !  
  So we don't need to worry about those, We can just use them so how we use them ❔ 💡↓  

```cs
    class Person
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
        }
    }

    class Employee : Person
    {
        ❌public Employee()
        {
            
        }
    }
```
- ❌ : There is no argument given that corresponds to the required parameter 'name' of 'Person.Person(string, int)'  
  📝 : We see the `Constructor` is not happy, So how could we now pass those details ❔  
  💡 : The thing is whenever we create an `Employee` we still need to pass in the `name`, `age` ↓  
  ```
    class Employee : Person
    {
        ❌public Employee(string name, int age)
        {
            
        }
    }
  ```
  - 🔑🔑 However we need to pass them on to our `Base Class` ( `Person` ) .  
    ```cs
    class Employee : Person
    {
        public Employee(string name, int age) : base(name, age) 
        {
            
        }
    }
    ```
    - `public Employee(string name, int age) : base(name, age)` :  
      What is the base ❔  
      💡 :  
      🔑 It's the `Constructor` of the `Parent` .  
      This `base(name, age)` follows the same definition of the `Constructor` of our `Person` as we saw  ↓  
      ```cs
        class Person
        {
            public string Name { get; private set; }
            public int Age { get; set; }

            👉public Person(string name, int age)👈
            {
                Name = name;
                Age = age;
                Console.WriteLine("Person Constructor called");
            }

            public void DisplayPersonInfo()
            {
            }
        }
      ```
      `Person` has the the `name` and `age` .  
      🔑🔑 So the `Base Class` will now get the `name` and `age` that we're passing on the `Employee` .  
      And then it will do all of its magic . 

```cs
    class Person
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
        }
    }

    class Employee : Person
    {
        public Employee(string name, int age) : base(name, age) 
        {
            👈
        }
    }
```
- 🚀 Cool thing is that we don't have to Add anything in there .  
  We're do that later on, We're going to add more `Properties` to the `Employee` we're going to see that .  
  But for now we just wanted to see how this `base` **Keyword** can also be used with the `Constructor` .


```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            👇
            Employee joe = new Employee("Joe", 36);
            joe.DisplayPersonInfo();

            Console.ReadKey();
            👆
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
        public Employee(string name, int age) : base(name, age) 
        {
            Console.WriteLine("Employee (Derived Class) Construtor called !"); 👈
        }
    }
}

```

```cs
Person Constructor called
Employee (Derived Class) Construtor called !
Name: Joe, Age: 36
```

So how that all does all of that come together ❔  
💡 :  
The thing is a `Person` has these 2 `Properties` →  `Name`, `Age` .  
And every `Class` that `Inherits` from `Person` will also have these `Properties` and what we're doing in the  
`Person` `Constrcutor` is Assigning values to those `Properties` and also calling WriteLine Statement ↓  
```cs
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Person Constructor called");
        }
```
We do this so we can see the flow .   
```console
Person Constructor called
Employee (Derived Class) Construtor called !
Name: Joe, Age: 36
```
🔑🔑 The flow is Whenever we creating an `Employee`:  
1. first the `Person` `Constructor` is called, Where some initialization is happening so some Properties are set .
2. Then `Employee` `Constructor` will be called .  
3. Then `Person.DisplayPersonInfo` onto our `Employee joe` is getting called ↓  
  ```cs
    static void Main(string[] args)
    {
        Employee joe = new Employee("Joe", 36);
        joe.DisplayPersonInfo();

        Console.ReadKey();
    }
  ```
  Whose also is a `Person` which is why we can use this `Person.DisplayPersonInfo` `Method` on it ↓  
  ```cs
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
  ```

So we see eventough our `Employee Class` is pretty empty we now can create Employee and we could 🔑`extend` the `Employee Class` to our liking .  
Adding `Properties` like `Employee ID`, `Salary`, `Position` because not every `Person` has an `Employee Id` .

🔑 We can `extend` the `Derived Class` `Constructor` which we're going to do in the next video ↓  
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
        👉public Employee(string name, int age) : base(name, age)👈
        {
            Console.WriteLine("Employee (Derived Class) Construtor called !");
        }
    }
}
```
- `public Employee(string name, int age) : base(name, age)` :  
  Cool thing is that this name → `(string 👉name, int age)`  
  Is being passed to this name → `base(👉name, age)`   
  🔑 So passed on to the `Base Class` that's whats happen internally same for age .
  We can use these inputs on the `Employee` `Consturctor` by the way, We can say :  
  ```cs
    public class Employee : Person
    {
        public Employee(string name, int age) : base(name, age)
        {
            name = "Frank" 👈
            Console.WriteLine("Employee (Derived Class) Construtor called !");
        }
    }
  ```
  🔑🔑 We can `override` that, however here is not so usefull because now all people now would be called ""Frank""  
  So let's dive deeper in in the next lecture .