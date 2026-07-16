namespace MyNamespace
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Library.management.Library library = new Library.management.Library();
			
			bool exit = false;

			while (!exit)
			{
				 Console.WriteLine("Library Management");
				 Console.WriteLine("1. Add Book");
				 Console.WriteLine("2. Remove Book with Id");
				 Console.WriteLine("3. Remove Book With Name");
				 Console.WriteLine("4. Show All Books");
				 Console.WriteLine("5. Remove All Books");
				 Console.WriteLine("6. Search By Name");
				 Console.WriteLine("7. Exit");
						
				 Console.WriteLine("\nEnter your choice: ");
				 int choice = Convert.ToInt32(Console.ReadLine());

				 switch (choice)
				 {
					 case 1:
					 {
						 Console.WriteLine("Enter Book ID: ");
						 string id =  Console.ReadLine();
						 Console.WriteLine("Enter Book Name: ");
						 string name = Console.ReadLine();
						 library.addBook(id, name);
						 break;
					 }
					 case 2:
					 {
						 Console.WriteLine("Enter Book ID: ");
						 string id = Console.ReadLine();
						 library.removeBook(id);
						 break;
					 }
					 case 3:
					 {
						 Console.WriteLine("Enter Book Name: ");
						 string name = Console.ReadLine();
						 library.removeBookName(name);
						 break;
					 }
					 case 4:
					 {
						 Console.WriteLine("All Books \n ");
						 library.DisplayBooks();
						 break;
					 }
					 case 5:
					 {
						 library.deleteAllBook();
						 break;
					 }
					 case 6:
					 {
						 Console.WriteLine("Enter name of book to search: ");
						 string name = Console.ReadLine();
						 library.SearchBook(name);
						 break;
					 }
					 case 7:
					 {
						 exit = true;
						 break;
					 }
					 default:
					 {
						Console.WriteLine("invalid choice");
						break;
					 }
				 }
					
					
			}

		}
	}
};

