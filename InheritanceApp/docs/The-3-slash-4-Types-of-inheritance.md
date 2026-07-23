# The 3 slash 4 Types of Inheritance  

We're gonna look at different type of `Inheritances` .

There are 4 Types that c# Directly supports three, The forth one is something that is possible or  
Maybe possible using a little trick or a workaround; Which we'll look into that later .  

1. Single Inheritance: Class inherits from one Base Class  

```cs
class DerivedClass : BaseClass {}
```

👀 )  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Bark();
            myDog.Eat();

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

- When a `Class` `Inherits` from another `Class`, But there are no other `Classes` that `Inherits` from that other `Class` .

2. Multilevel Inheritance: Class derived from another derived Class

```cs
class FurtherDerivedClass : DerivedClass {}
```

🔑 Another level of `Single Inheritance`

👀 )  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Bark();
            myDog.Eat();

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

    // A breed of dog
    class Collie : Dog
    {
        public void GoingNuts() 
        {
            Console.WriteLine("Coolie going Nuts");
        }
    }
}
```

- In this case `Collie`, `Inherits` from `Dog` which means that a `Collie` now 🔑 have all the traits of `Animal` as well as `Dog` .
- So what we have here is 🔑`Multi level Inheritance` where we don't have only 1 level but a second level as well maybe even a third level .  
- 🧠 What we saw with the `Exptions` is that there are so many other layers so these was example of `Multi Level Interitance` .

3. Hierarchical Inheritance: Multiple Class inherit One Base class

```cs
class DerivedClass2 : BaseClass {}
```
👀 )

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Bark();
            myDog.Eat();

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

    👇
    class Cat : Animal
    {
        public void Miau()
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    👆


    // A breed of dog
    //class Collie : Dog
    //{
    //    public void GoingNuts() 
    //    {
    //        Console.WriteLine("Coolie going Nuts");
    //    }
    //}
}

```

- This is called  🔑`Hierarchical Inheritance` which we have 1 Base Class and we have `Multiple Derived Classed` and there coulde be many many more in addition to `Dog` & `Cat` .
- 🔑🔑 We can also combine `Multilevel Inheritance` with `Hierarchical Inheritance`

4. Multiple Inheritance: Not Directly suppoerted in C# ( But indirectly yes )

```cs
class DerivedClass2 : BaseClass, BaseClass2 {}
```

⛔ This is not possible in C#, In some of the Programming language where it is possible !
where we have a class that can `Inherit` from `Multiple other Classes`

✅ Instead 🔑`Interface` are used to achieve this behavior .

In C# :

```cs
class A 
{
public:  
    void show() { cout << "A"; }
}

class B 
{
public:  
    void show() { cout << "B"; }
}

class C : publicA, publicB 
{

};
```

Imitafed in C# :

```cs
public interface IA 
{
    void show();
}

public interface IB 
{
    void Display();
}

public class : IA, IB 
{
    plublic void show() 
    {
        Consolw.WriteLine("A")
    }
    plublic void Display() 
    {
        Consolw.WriteLine("B")
    }
}
```

🔑 `Interfaces` are for later .

So 3 out 4 different Types of Inheritance is easily Accessible or Usable in C#  
without any workarounds .  
And the forth one where a Class Inherit from Multiple Classes is only possible through Interfaces .