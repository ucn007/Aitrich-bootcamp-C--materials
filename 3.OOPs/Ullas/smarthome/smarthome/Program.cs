using smarthome;
using System;

namespace  smarthome 

{
	public class SmartFan: ISwitchable, IMonitorable
	{
		public bool status { get; set; } 

		public void TurnOn()
		{
			status = true;
			Console.WriteLine("Device Turned On");
		}

		public void TurnOff()
		{
			status = false;
			Console.WriteLine("Device Turned Off");
		}

		public void showStatus()
		{
			if (status = true)
				Console.WriteLine("Device Running Successfully");
			else
				Console.WriteLine("Device is Turned Off");
		}
	}
	class Program
	{
		
		static void Main(string[] args)
		{
			SmartFan fan = new SmartFan();
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("======================== Welcome to SmartHome ========================");
				Console.WriteLine("1. Turn On");
				Console.WriteLine("2. Turn Off");
				Console.WriteLine("3. Show Status");
				Console.WriteLine("4. Exit");
				Console.WriteLine("Enter your choice: ");
				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
					{
						fan.TurnOn();
						break;
					}
					case 2:
					{
						fan.TurnOff();
						break;
					}
					case 3:
					{
						fan.showStatus();
						break;	
					}
					case 4:
					{
						exit = true;
						break;
					}
					default:
					{
						Console.WriteLine("Invalid Input");
						break;
					}
				}
			}
		}
	}
};

