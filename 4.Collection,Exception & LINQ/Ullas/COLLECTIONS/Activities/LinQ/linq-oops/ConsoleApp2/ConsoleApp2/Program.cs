using MyNamespace.service;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManage student =  new StudentManage();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++ Student Management System +++++++++++++++++++++++++++++++++++");
                Console.WriteLine("1.  Add Student");
                Console.WriteLine("2.  Delete Student");
                Console.WriteLine("3.  Display Students");
                Console.WriteLine("4.  Students Passed in Exam");
                Console.WriteLine("5.  Students Failed in Exam");
                Console.WriteLine("6.  Search Student");
                Console.WriteLine("7.  Find Topper");
                Console.WriteLine("8.  Find Least Mark");
                Console.WriteLine("9.  Find Average Mark");
                Console.WriteLine("10. Create Group");
                Console.WriteLine("11. Skip and Print Students");
                Console.WriteLine("12. Student Scored full mark(100)");
                Console.WriteLine("13. Show only Student Names");
                Console.WriteLine("14. Exit");
                
                Console.WriteLine("\n\nEnter Your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        student.AddStudent();
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 2:
                    {
                        student.DeleteStudent();
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 3:
                    {
                        student.DisplayStudents();
                        Console.WriteLine("\n\n");
                        break; 
                    }
                    case 4:
                    {
                        student.printStudentp();
                        Console.WriteLine("\n\n");
                        break;  
                    }
                    case 5:
                    {
                        student.printStudentf();
                        Console.WriteLine("\n\n");
                        break;  
                    }
                    case 6:
                    {
                        student.SearchStudents();
                        Console.WriteLine("\n\n");
                        break; 
                    }
                    case 7:
                    {
                        student.FindToopper();
                        Console.WriteLine("\n\n");
                        break;  
                    }
                    case 8:
                    {
                        student.FindLeastMark();
                        Console.WriteLine("\n\n");
                        break;  
                    }
                    case 9:
                    { 
                       student.FindAverage();
                       Console.WriteLine("\n\n");
                       break; 
                    }
                    case 10:
                    {
                        student.createGroup();
                        Console.WriteLine("\n\n");
                        break; 
                    }
                    case 11:
                    {
                        student.skipGroup();
                        Console.WriteLine("\n\n");
                        break; 
                    }
                    
                    case 12:
                    {
                        student.findFullMark();
                        Console.WriteLine("\n\n");
                        break; 
                    }
                    
                    case 13:
                    {
                        student.printName();
                        Console.WriteLine("\n\n");
                        break; 
                    }
                    case 14:
                    {
                        Console.Clear();
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("invalid choice");
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
};

