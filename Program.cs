using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;

public class program
{
    public static void Main(string[] args)
    {
        #region Question_1

        //Q1  Object Copying
        //a) What happens when you assign one object variable to another object variable?
        //b) Does assigning one object to another create a new object? Explain.
        //c) What is the difference between copying an object and copying its reference ?

        // Answer:

        // a) When you assign one object variable to another object variable, you are copying the reference to the object, not the actual object itself.
        // b) No, assigning one object to another does not create a new object. It simply creates a new reference to the same object in memory.
        // c) Copying an object creates a new instance with the same values, while copying its reference creates a new variable that points to the same object in memory.

        #endregion

        #region Question_2

        //Q2 Shallow Copy vs Deep Copy
        //a) What is a Shallow Copy?
        //b) What is a Deep Copy?
        //c) What happens to reference-type members when a Shallow Copy is created?
        //d) What happens to reference-type members when a Deep Copy is created?
        //e) Give one situation where Deep Copy would be safer than Shallow Copy.

        // Answer:

        // a) A Shallow Copy creates a new object, but it copies the references of the reference-type members.
        // b) A Deep Copy creates a new object and also creates new instances of the reference-type members, effectively duplicating the entire object graph.
        // c) When a Shallow Copy is created, reference-type members are copied by reference, meaning both the original and the copy point to the same object in memory.
        // d) When a Deep Copy is created, reference-type members are also copied by creating new instances of those objects, resulting in a completely independent copy of the original object.
        // e) A situation where Deep Copy would be safer than Shallow Copy is when you have an object that contains reference-type members, and you want to ensure that changing the copied object do not affect the original object.

        #endregion

        #region Question_3

        //Q3 Static Members
        //a) What is a static field, and how is it different from an instance field ?
        //b) What is a static method? Can a static method directly access instance members?
        //c) What is a static constructor, and when is it executed ?
        //d) What is a static class? Can you create an object from a static class?

        // Answer:

        //a) Static field:
        //A variable shared by all objects of a class. An instance field belongs to each individual object.
        //b) Static method:
        //A method that belongs to the class, not an object.It cannot directly access instance members.
        //c) Static constructor:
        //A constructor used to initialize static members.It runs once automatically, before the class is first used.
        //d) Static class:
        //A class that contains only static members and you cannot create an object from it.

        #endregion

        #region Question_4

        //Q4 Extension Methods
        //a) What is an Extension Method?
        //b) What keyword must be used in the first parameter of an extension method?
        //c) Where must an extension method be declared?
        //d) Can an extension method access private members of the class it extends?

        // Answer:

        //a) Extension Method:
        //A method that lets you add functionality to an existing class without modifying its source code.
        //b) "this" keyword.
        //c) It must be declared inside a static class.
        //d) No,An extension method cannot directly access the private members of the class it extends.

        #endregion

        #region Question_5

        //Q5 Partial Classes and Partial Methods
        //a) What is a Partial Class?
        //b) Why would a developer split one class into multiple files?
        //c) What is a Partial Method?
        //d) What happens if a declared partial method has no implementation?

        // Answer:
        //a) Partial Class:
        //A class that can be split into multiple files.The compiler combines them into one class.
        //b) Why split a class?
        //To organize code, make it easier to manage, or allow multiple developers to work on different parts.
        //c) Partial Method:
        //A method that is declared in one part of a partial class and can be implemented in another part.
        //d) If a partial method has no implementation, it is removed by the compiler.

        #endregion
    }
}
