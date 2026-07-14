
namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the number of total Subjects:");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine("Enter Your Marks of the subjects:");
           
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Your Marks are : ");
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("Enter your Choice: ");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Average ");
            Console.WriteLine("3. Largest Mark ");
            Console.WriteLine("4. Smallest Mark ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                {
                    int sum = arr.Sum();
                    Console.WriteLine("The sum of marks: "+sum);
                    break;
                }
                case 2:
                {
                    int avg = arr.Sum()/arr.Length;
                    Console.WriteLine("The average of marks:"+avg);
                    break;
                    
                }
                case 3:
                {
                    int max = arr.Max();
                    Console.WriteLine("The largest in the Mark is:"+ max);
                    break;
                    
                }
                case 4:
                {
                    int min = arr.Min();
                    Console.WriteLine("The smallest in the Mark is :"+ min);
                    break;
                    
                }
            }
        }
    }
};

