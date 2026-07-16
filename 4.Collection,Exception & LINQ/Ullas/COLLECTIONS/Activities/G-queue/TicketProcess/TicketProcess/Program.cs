namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> tickets = new Queue<string>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nTicket Management\n");
                Console.WriteLine("1. Create Ticket"); 
                Console.WriteLine("2. Pending Tickets");
                Console.WriteLine("3. Process Ticket ");
                Console.WriteLine("4. Process Tickets");
                Console.WriteLine("5. Exit Application");
                
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        Console.Write("Enter Ticket ID: ");
                        string ticketID = Console.ReadLine();
                        tickets.Enqueue(ticketID);
                        Console.WriteLine("Ticket Created");
                        break;
                    }
                    case 2:
                    {
                        int count = 1;
                        foreach (string ticket in tickets)
                        {
                            Console.WriteLine($"Ticket #{count}: {ticket}");
                            count++;
                        }
                        break;
                    }
                    case 3:
                    {
                        tickets.Dequeue();
                      break;
                    }
                    case 4:
                    {
                        while (tickets.Count > 0)
                        {
                            Console.WriteLine($"Ticket #{tickets.Count}: {tickets.Dequeue()}");
                          
                        }
                        break;
                    }
                    case 5:
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

