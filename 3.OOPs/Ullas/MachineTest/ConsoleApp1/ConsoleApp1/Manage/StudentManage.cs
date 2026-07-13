using ConsoleApp1.Models;

namespace ConsoleApp1.Manage;

public class StudentManage
{
    Student[] students =  new Student[100];
    private int studentCount = 0;

    public void AddStudent()
    {
        Console.WriteLine("=============== Add Student ===============");
        Console.WriteLine("Enter Student ID:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Student Mark:");
        float mark = float.Parse(Console.ReadLine());
        students[studentCount] = new Student(id, name, mark);
        studentCount++;
        Console.WriteLine("Student Added Successfully");
        
    }
    
    public void AddGradeStudent()
    {
        Console.WriteLine("=============== Add Graduate Student ===============");
        Console.WriteLine("Enter Student ID:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Student Mark:");
        float mark = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter Student project Mark:");
        float projectmark = float.Parse(Console.ReadLine());
        students[studentCount] = new GraduateStudent(id, name, mark, projectmark);
        studentCount++;
        Console.WriteLine("Graduate Student Added Successfully");
        
    }
    public void DisplayStudents()
    {
        Console.WriteLine("=============== Display Students ===============");
        for (int i = 0; i < studentCount; i++)
        {
            students[i].Display();
        }
    }
}