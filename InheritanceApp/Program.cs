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
