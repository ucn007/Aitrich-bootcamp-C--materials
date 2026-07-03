namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            int[,] m1 = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] m2 = new int[3, 3]
            {
                { 3, 4, 5 },
                { 6, 7, 8 },
                { 9, 1, 1 }
            };
Console.WriteLine("first matrix");
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    Console.Write(m1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.WriteLine("second matrix");
            for (int i = 0; i < m2.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    Console.Write(m2[i, j] + "");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("sum : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   int sum =  m1[i, j] + m2[i, j];
                   Console.Write(sum + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Subtraction : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int sum =  m1[i, j] + m2[i, j];
                    Console.Write(sum + " ");
                }
                Console.WriteLine();
            }
        }
    }
};

