namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] classes =
            {
                new[] { "Maths", "Science" },
                new[] { "Maths", "Science", "English" },
                new[] { "Computer" }
            };
            
            for (int i = 0 ; i < classes.Length; i++)
                {
                Console.WriteLine("Class"+ (i + 1));
                for (int j = 0; j < classes[i].Length; j++)
                    {
                    Console.WriteLine(classes[i][j]);
                    }
                Console.WriteLine();
                }
        }
    }
};

