# Access Modifiers and the Protected Keyword

🧠 We saw 🔑`public`, 🔑`private` and how they worked .  
Now let's see how they work with 🔑`Deriving Classes` or with 🔑`Inheritance` in general .

```cs
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

```
- We see 3 different `Access Modifiers` → `public`, `protected` and `private` `Fields` in this example .  
- `public int publicField` :  
  Accessible from anywhere in the `program` .  
- `protected int _protectedField;` :  
  Accessible in the `Class` it is declaed in and in `Sub-Classes`
- private int _privateField; :  
  Accessible only withing the same `Class`  .
- 🔑`internal int internalField;` :  
  Mote on this in future lessons .  
  Accessible anywhere withing the same `project`
- When it come to 🔑`Inheritance` only this 3 → `public`, `protected` and `private` are matter .

Now let's create a `DerivedClass` ↓  

```cs
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
        
        }
    }
```

Let's try to Access the `Fields` from the `Parent` .

```cs
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
            publicField = 1; ✅
            _protectedField = 2; ✅
            _privateField = 3; ❌
        }
    }
```
- ❌ : 'BaseClass._privateField' is inaccessible duo to its protection level .
- 🔑 so `private` is there → `private int _privateField;`  
  Is there to only having Access withing the same `Class` .  
  So whenever a `Member` is `private` it's 🔑 Only Accessible withing the same `Class` no matter  
  If it is a `Field`, `Property` or `Method` if it has `private` in front of it it's not going to be Accessible from ourside of that particular `Class` .
- If we want a `Field` to be Accessible we need to make sure that's not `private` .  
- 🔑🔑 Iw we want a `Field` to publically Accessible to other `Classes` exept for `Derived Classes`  
  Then we would have to use 🔑`protected` `Access Modifier` .  
  So it's something in between the `public` and `private` `Access Modifier` .  
  Again `protected` counts for all `Members` for `Properties`, `Methods` and `Fields` .

So now let's go furture ↓ 

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BaseClass baseClass = new BaseClass();
            baseClass.ShowFields();

            DerivedClass derivedClass = new DerivedClass();
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
```

```console
Public: 0, Protected: 0, Private: 0
Public: 0, Protected: 0, Private: 0
```

Now Let's call this `Method` → `AccessFields`  
To set the Variables accordingly .

```cs
namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BaseClass baseClass = new BaseClass();
            baseClass.ShowFields();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.AccessFields(); 👈
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
```

```console
Public: 0, Protected: 0, Private: 0
Public: 1, Protected: 2, Private: 0 👈
```
- 🔑 So we couldn't overwrite this `_privateField` Value however we can still see it's Value .  
  ⛔ We're not Accessing it Directly .  
  ✅ We're Accessing it from `ShowFields` `Method` :  
  ```cs
  // BaseClass.ShowFields

        public void ShowFields()
        {
            Console.WriteLine($"Public: {publicField}, Protected: {_protectedField}," +
                $" Private: {_privateField}");
        }
  ```
  - So this `ShowFields` `Method` is exposing this `privateField Value`  
    ⛔ Again not the Variable itself → `_protectedField` .  
    ✅ Just its Value of the `private` `Field` .  
    🔑 And this is why we can see the `private` `Field` Value even on out `Derived Class` ↓  
    `derivedClass.ShowFields();` As this is the `Parent` `.ShowFields()` `Method` which itself exposed  
    the Value of the `private` Variable .