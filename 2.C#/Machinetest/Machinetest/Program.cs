

namespace MyNamespace
{
    enum department
    {
        ComputerScience,
        Electronics,
        Mechanical,
        Civil
    }
    class Program
    {
        public struct Student
        {
            public int studentId;
            public string name;
            public int age;
            public department department;
            public float[] score;
        }

        static int studentCount = 0;
        static bool exit = false;

        static void Main(string[] args)
        {
            Student[] students = new Student[10];

            while (!exit)
            {
                Console.WriteLine("========== Student Management ==========");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Student Details");
                Console.WriteLine("3. Show Total & Average");
                Console.WriteLine("4. Show Grade");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        if (studentCount == students.Length)
                        {
                            Console.WriteLine("Student list is full.");
                            break;
                        }

                        Console.Write("Enter Student ID: ");
                        students[studentCount].studentId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Name: ");
                        students[studentCount].name = Console.ReadLine();

                        Console.Write("Enter Student Age: ");
                        students[studentCount].age = Convert.ToInt32(Console.ReadLine());

                        department dept;

                        while (true)
                        {
                            Console.Write("Enter Department (ComputerScience, Electronics, Mechanical, Civil): ");

                            if (Enum.TryParse(Console.ReadLine(), true, out dept))
                            {
                                students[studentCount].department = dept;
                                break;
                            }

                            Console.WriteLine("Invalid Department. Try Again.");
                        }

                        students[studentCount].score = new float[5];

                        Console.WriteLine("Enter Marks:");

                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($"Subject {i + 1}: ");
                            students[studentCount].score[i] = Convert.ToSingle(Console.ReadLine());
                        }

                        studentCount++;

                        Console.WriteLine("Student Added Successfully.");

                        break;

                    case 2:



                    {
                       

                        for (int i = 0; i < studentCount; i++)
                        {

                            Console.WriteLine("Student Details");
                            Console.WriteLine("------------------------");
                            Console.WriteLine("ID : " + students[i].studentId);
                            Console.WriteLine("Name : " + students[i].name);
                            Console.WriteLine("Age : " + students[i].age);
                            Console.WriteLine("Department : " + students[i].department);

                            Console.WriteLine("Marks:");

                            for (int j = 0; j < 5; j++)
                            {
                                Console.WriteLine("Subject " + (j + 1) + " : " + students[i].score[j]);
                            }



                        }

                        break; 
                    }
                        

                     

                    case 3:
                        int sid;
                        bool found = false;
                        Console.Write("Enter Student ID: ");
                        sid = Convert.ToInt32(Console.ReadLine());

                        found = false;

                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i].studentId == sid)
                            {
                                found = true;

                                double total = students[i].score.Sum();
                                double average = total / 5;

                                Console.WriteLine("Total Marks : " + total);
                                Console.WriteLine("Average : " + average);

                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Student Not Found.");
                        }

                        break;

                    case 4:

                        Console.Write("Enter Student ID: ");
                        sid = Convert.ToInt32(Console.ReadLine());

                        found = false;

                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i].studentId == sid)
                            {
                                found = true;

                                double average = students[i].score.Sum() / 5;

                                Console.WriteLine("Average : " + average);

                                if (average >= 90)
                                    Console.WriteLine("Grade : A");
                                else if (average >= 80)
                                    Console.WriteLine("Grade : B");
                                else if (average >= 70)
                                    Console.WriteLine("Grade : C");
                                else if (average >= 60)
                                    Console.WriteLine("Grade : D");
                                else
                                    Console.WriteLine("Grade : F");

                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Student Not Found.");
                        }

                        break;

                    case 5:

                        exit = true;
                        Console.WriteLine("Thank you!");
                        break;

                    default:

                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}