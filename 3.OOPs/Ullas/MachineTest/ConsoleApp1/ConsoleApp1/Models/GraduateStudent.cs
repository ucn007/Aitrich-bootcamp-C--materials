using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;

public class GraduateStudent: Student
{
    float ProjectMark{get; set;}

    public GraduateStudent (int id, string name, float mark, float projectMark): base(id, name,mark)
    {
        
        ProjectMark = projectMark;

    }

    public override void Display( )
    {
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine($"\nStudent Id: {Id}, \nName: {Name},\n Mark: {Mark},\n Project mark: {ProjectMark}");
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    }
}