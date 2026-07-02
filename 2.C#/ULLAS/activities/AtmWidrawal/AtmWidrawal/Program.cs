namespace AtmWidrawal
{
	class MainClass
	{
		public static void Main()
		{
			Console.WriteLine("Enter Your Account Balence");
			double balance = double.Parse(Console.ReadLine());
			Console.WriteLine("Enter Amount you need to Withdraw");
			double withdraw = double.Parse(Console.ReadLine());

			if (balance >= withdraw)
			{
				Console.WriteLine("Transaction successful");
			}
			else
			{
				Console.WriteLine("Insufficient Balance");
			}
		}
	}
}