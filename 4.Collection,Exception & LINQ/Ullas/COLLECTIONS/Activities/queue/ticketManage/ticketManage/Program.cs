using System.Collections;

namespace MyNamespace
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Queue tikeQueue = new Queue();
			 tikeQueue.Enqueue("Hello World! 1");
			 tikeQueue.Enqueue("Hello World! 2");
			 tikeQueue.Enqueue("Hello World! 3");
			 tikeQueue.Enqueue("Hello World! 5");
			 tikeQueue.Enqueue("Hello World! 4");
			 
			 Console.ReadKey();
			 Console.WriteLine("Customer in Queue" + tikeQueue.Count);
			 Console.ReadKey();
			 Console.WriteLine("Next Customer in priority" + tikeQueue.Peek());
			 Console.ReadKey();
			 
			 Console.WriteLine("Next Customer" + tikeQueue.Dequeue());
			 Console.ReadKey();
			 Console.WriteLine("Next Customer" + tikeQueue.Dequeue());
			 
			 
			 Console.ReadKey();
			 Console.WriteLine("Pending Customers" + tikeQueue.Count);
			 Console.WriteLine("Next Customer" + tikeQueue.Dequeue());	
			 
			 Console.ReadKey();
			 
		}
	}
};

