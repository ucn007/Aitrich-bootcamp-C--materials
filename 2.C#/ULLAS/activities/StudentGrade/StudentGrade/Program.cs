namespace  StudentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Mark");
            float mark = float.Parse(Console.ReadLine());

            if (mark > 100)
            {
                Console.WriteLine("please enter a valid score");
            }
            else if (mark >= 90)
            {
                Console.WriteLine("Congrats! Your Grade is : A");
            }
            else if (mark <= 89 && mark >= 75)
            {
                Console.WriteLine("Congrats! Your Grade is : B");
            }
            else if (mark <= 74 && mark >= 50)
            {
                Console.WriteLine("Congrats! Your Grade is : c");
            }
            else if ( mark < 50)
            {
                Console.WriteLine("Better Luck next time! you failed");
            }
        }
    }
}