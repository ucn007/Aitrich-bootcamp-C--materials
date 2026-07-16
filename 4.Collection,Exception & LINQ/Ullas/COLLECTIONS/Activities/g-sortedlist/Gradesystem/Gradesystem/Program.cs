namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int,String> students = new SortedList<int,string>();

            void addStudet()
            {
                Console.WriteLine("Add student\n");
                Console.WriteLine("Enter Student id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Student Grade: ");
                string grade = Console.ReadLine();
                students.Add(id, grade);
                Console.WriteLine("Student Added Successfully");
                
            }

            void searchStudent()
            {
                Console.WriteLine("Search Student");
                Console.WriteLine("Enter Student Id: ");
                int id = int.Parse(Console.ReadLine());

                if (students.ContainsKey(id))
                {
                    Console.WriteLine("Student found ");
                    Console.WriteLine(students.IndexOfKey(id));
                }
                else
                {
                    Console.WriteLine("No Student Found");
                }
            }

            void display()
            {
                foreach (KeyValuePair<int, string> student in students)
                {
                    Console.WriteLine($"Id: {student.Key} - Grade: {student.Value}");
                      
                    Console.WriteLine("\n");
                }
            }

            void delete()
            {
                Console.WriteLine("Enter Student Id: ");
                int id = int.Parse(Console.ReadLine());

                if (students.ContainsKey(id))
                {
                    Console.WriteLine("Student :" + id + "Deleted");
                    students.Remove(id);
                }
                else
                {
                    Console.WriteLine("No Student Found");
                }
            }

            void DeleteAll()
            {
                Console.WriteLine("Delete All Students");
                students.Clear();
                
            }
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Grade Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. View Students");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Delete All Student");
                Console.WriteLine("6. Exit Program");
                Console.WriteLine("\nEnter your Choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        addStudet();
                        break;
                    }
                    case 2:
                    {
                        searchStudent();
                        break;
                    }
                    case 3:
                    {
                        display();
                        break;
                    }
                    
                    case 4:
                    {
                        delete();
                        break;
                    }
                    case 5:
                    {
                        DeleteAll();
                        break;
                    }
                    case 6:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid Choice");
                        break;
                    }
                }

                
            }
        }
    }
};

