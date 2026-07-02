namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            int[,] arr =
            {
                
                {   10, 20, 30 },
                {   40, 50, 60 },
                {   10, 20, 30 }
            };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total Marks");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int sum = 0;
                int avg = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                    avg =  sum / arr.GetLength(1);
                }

                Console.WriteLine($"Student {i} total = {sum}");
                Console.WriteLine($"Average Mark = {avg}");
            }
        }
    }
};

