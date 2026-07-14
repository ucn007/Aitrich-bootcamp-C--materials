using ConsoleApp1.Manage;

namespace  ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
StudentManage studentManage = new StudentManage();
            while (!exit)
            {
                Console.WriteLine("****************************** Student Management System ******************************");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Graduation Student");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. Exit");
                
                Console.WriteLine("\nEnter Your Choice:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        studentManage.AddStudent();
                        break;
                    }
                    case 2:
                    {
                        studentManage.AddGradeStudent();
                        break;
                    }
                    case 3:
                    {
                        studentManage.DisplayStudents();
                        break;
                    }
                    case 4:
                    {
                        exit = true;
                        break;
                    }
                }
            }
        }
    }
}