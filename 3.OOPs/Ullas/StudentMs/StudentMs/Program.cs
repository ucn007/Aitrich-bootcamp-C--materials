namespace MyNamespace
{
    class Program
    {
      
       
        static void Main()
        {
            Student student = new Student();
            bool exit = false;
            while (!exit)
            {
                 Console.WriteLine("=========================== Student Management ==========================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Student");
            Console.WriteLine("3. Exit Program");
            
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {   
                   student.addStudent();
                    break;
                }
                case 2:
                {
                    student.DisplayStudent();
                 
                    break;
                }
                case 3:
                {
                    exit = true;
                    break;
                }
                default:
                {
                    
                    Console.WriteLine("Invalid Input");
                    break;
                }
            } 
            }
          
        }
    }
};

