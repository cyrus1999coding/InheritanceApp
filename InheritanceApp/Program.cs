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
