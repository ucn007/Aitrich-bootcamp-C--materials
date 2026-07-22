using System;
namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pets = { "Dog", "Cat", "Parrot" };
                Console.WriteLine(pets[10]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
};

