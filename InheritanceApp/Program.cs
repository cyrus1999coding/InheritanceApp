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
