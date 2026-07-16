using Dictonary_tasj.Manage;

namespace  Dictonary_tasj
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            StudentOperations student =  new StudentOperations();

            while (!exit)
            {
                Console.WriteLine("Student Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Delete All Students");
                Console.WriteLine("5. Display All Students");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        student.AddStudent();
                        break;
                    }
                    case 2:
                    {
                        student.DeleteStudent();
                        break;
                    }
                    case 3:
                    {
                        student.SearchStudent();
                        break;
                    }
                    case 4:
                    {
                        student.deleteallStudents();
                        break;
                    }
                    case 5:
                    {
                        student.DisplayStudents();
                        break;
                    }
                    case 6:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.Write("Enter a valid option");
                        break;
                    }   
                }
            }
        }
    }
}