namespace ConsoleApp1.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public float Mark
    {
        get;
        set;

    } 
    
    public Student( int id,string name, float mark)
    {
        Id = id;
        Name = name;
        Mark = mark;
    }

    public virtual void Display( )
    {
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine($"\nStudent Id: {Id}, \nName: {Name},\n Mark: {Mark}");
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    }
    
}