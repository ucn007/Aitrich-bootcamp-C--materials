namespace MyNamespace.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Mark { get; set; }

    public Student(int id, string name, float mark)
    {
        Id = id;
        Name = name;
        Mark = mark;
    }
}