# Inheritance Base Class vs Derived Class

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```
We're going to see that in the same 🔑`namespace` in the same 🔑`file` so we can understand the concept easier .  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    👇
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }
    }
    👆
    👇
    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking ...");
        }
    }
    👆
}

```
- here we have 🔑`Base Class`, Also called 🔑`Parent Class`, 🔑`Super Class` which is basically the `Class` whose members are 🔑`Inherited`  We saw Members eariler 🔑`Properties` as `Members`, 🔑`Methods` as Members,  
  Other components as Members as well .

- `class Dog : Animal` :  
  `Dog` is 🔑`Inheriting` from `Animal` which means it has all of the Capabilities that an Animal has  
  Plus it has its own Capabilities .  
  By Capabilities we mean ↓  
  - `Properties`
  - `Methods`
  - Basically the `Members` 

🧠 We've seen that with `Exeptions` which had Multiple possible Layers of 🔑`Inheritance` and the `Exeptions`  
Is the `Absoulute Base Class` so it's `Absoulute Fundamentals` of an `Exception` .  
But then the SystemExcepton has some specific traits that are specific to itself and not avaialble inside of the `Base Exeption` .

Also We can have another layer where we have different breads of Dogs and each of them again have new traits . 

🔑`Child Class`/🔑`Derived Class`/🔑`Sub Class` :  
in our example Dog its that .  
The `Class` that `Inherits` form the `Members` of the `Base Class` 

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Bark(); 👈
            myDog.Eat(); 👈


        }
    }

    class Animal
    {
        public  void Eat()
        {
            Console.WriteLine("Eating ...");
        }
    }

    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking ...");
        }
    }
}
```

```console 
Barking ...
Eating ...
```

- `myDog` :  
  This Instance of `Dog Class` has couple `Methods` in it which we don't create all of them  
  we see more about those in a bit ↓  
  ```text
  (Method) Eat
  (Method) Bark
  (Method) Equals
  (Method) GetType
  (Method) ToString
  (Method)GetHashCode
  ```
- `myDog.Eat();` :  
  Eventhough we didn't implemented the `.Eat()` `Method` inside of our `Dog Class`   
  It can Access it's `Parent` `.Eat()` `Method` .

