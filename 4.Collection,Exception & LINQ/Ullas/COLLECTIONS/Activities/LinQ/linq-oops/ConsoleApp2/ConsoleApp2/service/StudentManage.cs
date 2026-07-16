using MyNamespace.Models;

namespace MyNamespace.service;

public class StudentManage
{
    List<Student> students = new List<Student>();

    public void AddStudent()
    {
        Console.WriteLine("Enter Student ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Student Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Student Mark:");
        float mark = float.Parse(Console.ReadLine());

        students.Add(new Student(id, name, mark));

        Console.WriteLine($"Student {name} Added");
    }
    public void DeleteStudent()
    {
        Console.WriteLine("Enter Student ID:");
        int id = Convert.ToInt32(Console.ReadLine());
        if (students.Find(x => x.Id == id) == null)
        {
            Console.WriteLine("Student not found");
        }
        else
        {
            Console.WriteLine("Student"+ students[id].Name  +" Deleted");
            students.Remove(students.Find(x => x.Id == id));
        }
    }
    public void DisplayStudents()
    {
        foreach (Student s in students)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Id : {s.Id}");
            Console.WriteLine($"Name : {s.Name}");
            Console.WriteLine($"Mark : {s.Mark}");
            
        }
    }

    public void printStudentp()
    {
        var result = students.Where(student => student.Mark > 50).ToList();
        
        Console.WriteLine("Passed Students");
        foreach (var item in result)
        {
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Id: {item.Id}\nName: {item.Name}\nMark: {item.Mark}\n");
        }
    }
    
    public void printStudentf()
    {
        var result = students.Where(student => student.Mark < 50).ToList();
        
        Console.WriteLine("Failed Students");
        foreach (var item in result)
        {
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Id: {item.Id}\nName: {item.Name}\nMark: {item.Mark}\n");
        }
    }

    public void SearchStudents()
    {
      Console.WriteLine("Search Students");
      Console.WriteLine("1. Search Students with Id");
      Console.WriteLine("2. Search Students with Name");
      int choice = Convert.ToInt32(Console.ReadLine());

      if (choice == 1)
      {
          Console.WriteLine("Enter Student ID:");
          int id = Convert.ToInt32(Console.ReadLine());
          if (students.Find(x => x.Id == id) == null)
          {
              Console.WriteLine("Student not found");
          }
          else 
          {
              var result =  students.Where(student => student.Id == id).ToList();
              foreach (var item in result)
              {
                  Console.WriteLine($"Student Found");
                  Console.WriteLine($"ID: {item.Id}  \nNAME: {item.Name}  \nMARK: {item.Mark}  ");
              }
              
          }
      }
      else if (choice == 2)
      {
          Console.WriteLine("Enter Student ID:");
          string name = Console.ReadLine();
          if (students.Find(x => x.Name == name) == null)
          {
              Console.WriteLine("Student not found");
          }
          else 
          {
              var result =  students.Where(student => student.Name == name).ToList();
              foreach (var item in result)
              {
                  Console.WriteLine($"Student Found");
                  Console.WriteLine($"ID: {item.Id}  \nNAME: {item.Name}  \nMARK: {item.Mark}  ");
              }
              
          }
      }
      else
      {
          Console.WriteLine("Invalid Input");
      }
      
      
    }

    public void FindToopper()
    {
        var result = students.MaxBy(student => student.Mark);
        Console.WriteLine($"___________ Topper Details ___________");
        Console.WriteLine("Name" + result.Id + ", Mark" + result.Mark);
    }

    public void FindLeastMark()
    {
        var result = students.MinBy(student => student.Mark);
        Console.WriteLine($"___________ Least Mark Details ___________");
        Console.WriteLine("Name" + result.Id + ", Mark" + result.Mark);
    }

    public void FindAverage()
    {
        var result = students.Average(student => student.Mark);
        Console.WriteLine($"___________ Average Mark Details ___________");
        Console.WriteLine($"Average Mark: {result}");
    }

    public void createGroup()
    {
        Console.WriteLine("Enter the limit");
        int limit = Convert.ToInt32(Console.ReadLine());
        if (limit > students.Count)
        {
            Console.WriteLine("Limit Exceeded");
        }
        else
        {
            var result = students.Take(limit).ToList();
            Console.WriteLine($"{result.Count} Students Group Created");
            Console.WriteLine("__________________________________________");
            foreach (var item in result)
            {
                Console.WriteLine($"Id : {item.Id}  Name: {item.Name}  Mark: {item.Mark}");
            }
        }
    }
    
    public void skipGroup()
    {
        Console.WriteLine("Enter the limit");
        int limit = Convert.ToInt32(Console.ReadLine());
        if (limit > students.Count)
        {
            Console.WriteLine("Limit Exceeded");
        }
        else
        {
            var result = students.Skip(limit).ToList();
            Console.WriteLine($" Students list after skipping {result.Count} students ");
            Console.WriteLine("__________________________________________");
            foreach (var item in result)
            {
                Console.WriteLine($"Id : {item.Id}  Name: {item.Name}  Mark: {item.Mark}");
            }
        }
    }

    public void findFullMark()
    {
        var result = students.FindAll(student => student.Mark == 100);
        Console.WriteLine($"{result.Count} Students Having Full Mark");
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Id}  Mark: {item.Mark}");
        }
        
    }

    public void printName()
    {
        var result = students.Select(student => student.Name );
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}