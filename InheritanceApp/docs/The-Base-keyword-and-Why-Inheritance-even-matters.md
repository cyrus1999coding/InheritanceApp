# The Base Keyword and Why Inheritance even matters

`Base` **Keyword** is soulution to a problem .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.MakeSound();
            
            
            Cat myCat = new Cat();
            myCat.MakeSound();
            
        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating ...");
        }
        👇
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound");
        }
        👆
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

- The problem that we have right now is when we want to Access the `MakeSound()` `Method` of the  
  Animal `Class` .  
  Most of them time this wont be something as simple ↓  
  ```cs
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a generic sound");
    }
  ```
  It could be something where there is a lot of **Initialization** happening .  
  So this `MakeSound` `Method` could initialize a bunch of `Properties` and setup the Values .  
  And then we want to make sure whatever `Deriving Class` we have and whatever `Deriving Class` does with that `Method`  
  Is not going to cause any troubles becasue some `Properties` aren't set or somehing is missing .  
  So in that case we can use the 🔑`base` **Keyword** .

So ↓  

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.MakeSound();
            
            
            Cat myCat = new Cat();
            myCat.MakeSound();
            
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
            base.MakeSound(); 👈
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

```console
Animal makes a generic sound 👈
Barking ... 👈
Cat is miauing
```

- `base.MakeSound();` :  
  It will call the `void Animal.MakeSound()` `Method` when the `Dog.MakeSound` `Method` is called .  
  on top of whatever our own implementation is .

- So now :  
 ```cs
    class Dog : Animal
    {
        public override👈 void MakeSound()
        {
            base.MakeSound(); 👈
            Console.WriteLine("Barking ...");
        }
    }
 ```
 - We're not just `overiding`/Editing the old `MakeSound` `Method` .
 - But we're also Accessing it's execution or we're calling it . 
 - 🔑🔑 So now we're saying we want to do the `base Class` thing AND we want to do our specific implementation for that Dog itself .

We need to consider sometimes we don't Access the `Base Class`, We can't change the `Base Class`  
👀 : Somebody else in our team is responsible for the `Base Class` and is working on it  
But we don't have Access to the `Base Class`'s code we can't change it or we can't see what it does .  
👀 : Or when we use third part libraries/frameworks .