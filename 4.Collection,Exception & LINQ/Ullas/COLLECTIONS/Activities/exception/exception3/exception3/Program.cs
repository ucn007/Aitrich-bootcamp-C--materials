namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i = int.MaxValue;
                int j = checked(i + 1);
                Console.WriteLine(j);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
};

