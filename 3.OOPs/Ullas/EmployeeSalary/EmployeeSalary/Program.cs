namespace MyNamespace
{
	public abstract class Employee
	{
		public abstract int employeId { get; set; }
		public abstract string empName { get; set; }

		public abstract void calculateSalary();
	}

	public class FulltimeEmployee: Employee
	{
		public  override int employeId{ get; set; }
		public  override string empName { get; set; }
        public double MonthlySalary { get; set; }
		public override void calculateSalary()
		{
			Console.WriteLine($"Employe Id: {this.employeId} \nEmployee Name: {this.empName} \nMonthly Salary: {this.MonthlySalary}");
		}
	}

	public class ParttimeEmployee: Employee
	{
		public  override int employeId{ get; set; }
		public  override string empName { get; set; }
        public  double whours { get; set; }
        public  double hsalary { get; set; }

        public override void calculateSalary()
		{
		 double salary = whours * hsalary;
		Console.WriteLine($"Employe Id: {this.employeId} \nEmployee Name: {this.empName} \nMonthly Salary: {salary}");
		}
	}
	
	public class Program
	{
		public static void Main(string[] args)
		{
			Employee fullTime = new FulltimeEmployee
			{
				employeId = 101,
				empName = "Ullas",
				MonthlySalary = 50000,
			};

			Employee partTime = new ParttimeEmployee
			{
				employeId  = 102,
				empName = "Rahul",
				whours = 80, 
				hsalary= 500
			};

			fullTime.calculateSalary();
			Console.WriteLine();

			partTime.calculateSalary();
		}
	}
};

