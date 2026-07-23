# Method Overriding with override and virtual  

We're going to look at 🔑`Method Overriding` and in order to use 🔑`Overriding` we need to use the  
`override` **Keyword** and the `virtual` **Keyword** .  

Why would we even do that ❔  
💡 :  
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
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }
    }

    class Dog : Animal
    {
        public void Bark() 👈
        {
            Console.WriteLine("Barking ...");
        }
    }

    
    class Cat : Animal
    {
        public void Miau() 👈
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    


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

If we look at our example :  
- We have `Bark()` `Method` → `Dog`.`Bark`  
- And we have `Miau()` `Method` → `Cat`.`Miau`

But every animal makes a sound .  
So let's create a `Method` for that ↓  

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
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }
        👇
        public void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound");
        }
        👆
    }

    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking ...");
        }
    }

    
    class Cat : Animal
    {
        public void Miau()
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    


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
Now we want to implement the `MakeSound` `Method` be Unique for the `Dog` as well as Unique for the `Cat` .  

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
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }
        👇
        public void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound");
        }
        👆
    }

    class Dog : Animal
    {
        public void MakeSound() 👈⛔
        {
            Console.WriteLine("Barking ...");
        }
    }

    
    class Cat : Animal
    {
        public void MakeSound() 👈⛔
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    


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
- ⚠ : 'Dog.MakeSound()' hides inherited member 'Animal.MakeSound()'. Use the new keyword if hiding was intended.
- ⚠ : 'Cat.MakeSound()' hides inherited member 'Animal.MakeSound()'. Use the new keyword if hiding was intended.
- ⛔ Just renaming the `Bark` and `Miua` to the `MakeSound` is not correct .  
  We're still missing 2 Keywords that we've taling about → `virtual`, `override`

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            //myDog.Bark();
            //myDog.Eat();

        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }

        public virtual void MakeSound() 👈
        {
            Console.WriteLine("Animal makes a generic sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound() 👈
        {
            Console.WriteLine("Barking ...");
        }
    }

    
    class Cat : Animal
    {
        public override void MakeSound() 👈 
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    


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
- `public virtual void MakeSound()` :  
  🔑`virtual` **Keyword**  now allows us to 🔑`override` the `MakeSound()` `Method` in `Deriving Classes` .
- `public override void MakeSound()` :  
  🔑`override` **Keyword** we can 🔑`override` the `MakeSound()` `Method` .
- Now the warnings are gone .  
- 🔑 Now we're going to have a Unique `MakeSound()` `Method` for each of the animal types .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            👇
            Dog myDog = new Dog();
            myDog.MakeSound();
            👆
            👇
            Cat myCat = new Cat();
            myCat.MakeSound();
            👆
        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Barking ...");
        }
    }

    
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    


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

```cs
Barking ...
Cat is miauing
```

That's what `override` and `virual` allows us to do  

Why this is usefull ❔  
💡 :  
Sometimes we want to use the same `Method` name with the `Derived Class` because we want to do something similar or its own implementation so to speek for each given `Class` .

How do we now Access this `Base` `Method` → `Animal.MakeSound()` :  
```cs
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound");
        }
```
for a Dog and a Car ❔  
💡 : We're going to see that in the next lecture .  

🔑 What we just did with this `virtual` and `override` **Keywords** is part of 🔑`Polymorphism`  
Which is the 3ed part of `OOP` .  
Which we're going to cover that later as well as the 🔑`abstract` **Keyword** but let's see the `base` **Keyword** in next lecture first .