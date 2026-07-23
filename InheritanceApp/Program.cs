namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BaseClass baseClass = new BaseClass();
            baseClass.ShowFields();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.AccessFields();
            derivedClass.ShowFields();

            Console.ReadKey();
        }
    }

    class BaseClass
    {
        public int publicField;

        protected int _protectedField;
        private int _privateField;

        public void ShowFields()
        {
            Console.WriteLine($"Public: {publicField}, Protected: {_protectedField}," +
                $" Private: {_privateField}");
        }
    }

    class DerivedClass : BaseClass
    {
        public void AccessFields()
        { 
            publicField = 1;
            _protectedField = 2;
            //_privateField = 3;
        }
    }
}
