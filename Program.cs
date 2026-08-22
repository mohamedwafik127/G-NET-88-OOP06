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
    }
}
