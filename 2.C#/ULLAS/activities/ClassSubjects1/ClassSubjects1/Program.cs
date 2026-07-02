namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months =
            {
                "January", "February", "March"
            };
            int[][] sales =
            {
                new[] { 1000, 2000 },
                new[] { 200, 500, 400 },
                new[] { 200,800,400 }
            };
            
            for (int i = 0 ; i < months.Length; i++)
            {
                Console.WriteLine(months[i]);
                for (int j = 0; j< sales[i].Length ; j++)
                {
                    Console.WriteLine(sales[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total monthky sales");
            for (int i = 0 ; i < months.Length; i++)
            {
                Console.WriteLine(months[i]);
               
                    Console.WriteLine(sales[i].Sum());
               
                Console.WriteLine();
            }
            
        }
    }
};