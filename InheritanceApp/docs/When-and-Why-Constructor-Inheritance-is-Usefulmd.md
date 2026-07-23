# When and Why Constructor Inheritance is Useful  

1. Ensuring `Base Class` intialization :  
  The `Base Class` (Person) has `Fields` Name and Age that must be initialized .  
  By calling `base(name,age)`, We esure that these `Fields` are set up before the `Employee Consructor` continues with its own initialization .

2. Avoid Code Duplication :  
  The initialzation logic for Name and Age is centralized in the `Person Class` .  
  If these `Fields` were initialized separately in every `Derived Class` .  
  ⛔ It would lead to duplication and potential Errors if the initialzation logic needed to be changed later on .  

3. Maintaining Invariance :  
  By establishing and maintaining 🔑`Class Invariants` in the `Construcor` we ensure that the Object remains in a valid and expected `State` .  
  Adhering to all necessary conditions throughout its existence .  
  📝 So the `Base Class` `Constroctur` can enforce cerain **Invariants** or **Validation** checks .  
  👀🚀 ) If the `Person Class` has some **Validations** for Age ensuring it's non-negative this logic  
  Would be Re-used Automatically by all `Derived Classes` .

4. Extensibility :  
  `Derived Classes` can **extend** the Initialization process by adding their own Parameters and Initialzing their own `Fields`, While still leveraging the `Base Class` `Constuctor` for 🔑`Shared Fields` .  

