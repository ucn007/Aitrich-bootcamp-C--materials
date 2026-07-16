

namespace Dictonary_tasj.Manage;

public class StudentOperations
{
   private Dictionary<int, string> students = new Dictionary<int, string>();

 public  void AddStudent()
   {
      Console.WriteLine("Add Student");
      Console.Write("Student ID: ");
      int id = int.Parse(Console.ReadLine());
      Console.Write("Student name: ");
      string name = Console.ReadLine();
      if (students.ContainsKey(id))
      {
         Console.Write($"Id: {students[id]} Already Exists");
      }
      else
      {
         students.Add(id, name);
         Console.Write($"{name} has been added ");
      }
    
      
      
   }

  public void DeleteStudent()
   {
      Console.Write("Student ID: ");
      int id = Convert.ToInt32(Console.ReadLine());

     
         if (students.ContainsKey(id))
         {
            Console.Write($"{students[id]} has been deleted \n");
            students.Remove(id); 
         }

         else
         {
            Console.Write($"{id} not found ");
         }
      
      
   }

 public  void DisplayStudents()
   {
      foreach (var student in students)
      {
         Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++");
         Console.WriteLine($" Id: {student.Key}\n Name: {student.Value}");
      }
   }
   
  public void deleteallStudents()
   {
     students.Clear();
     Console.WriteLine("All Students Deleted");
   }
   
 public  void SearchStudent()
   {
      Console.Write("Student ID: ");
      int id = int.Parse(Console.ReadLine());
      if (students.ContainsKey(id))
      {
        Console.Write($"Id: {students[id]} ");
      }
      else
      {
         Console.Write($"{id} not found ");
      }
   }
   

}