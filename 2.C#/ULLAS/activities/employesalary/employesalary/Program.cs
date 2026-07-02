namespace MyNamespace
{
    using System;
    using System.Linq;   
    class Program
    {
        static void Main()
        {
            string[] employees = new string[5]{"John", "Paul", "George", "Alex","Ajin"};
            double[] salary = new double[5] { 50000, 35000, 40000, 45000, 60000 };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(employees[i] + "-"  + salary[i]);
                Console.WriteLine("");
            }
            
            int j = Array.IndexOf(salary, salary.Max());

            Console.WriteLine("Highest Paid Employee: " + employees[j]);
            Console.WriteLine(salary[j]);
        }
      
    }
};

