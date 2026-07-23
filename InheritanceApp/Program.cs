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