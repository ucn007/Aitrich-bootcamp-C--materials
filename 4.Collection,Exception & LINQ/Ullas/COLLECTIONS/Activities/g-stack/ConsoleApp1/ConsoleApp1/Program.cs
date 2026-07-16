namespace MyNamespace
{
    class History
    {
        private Stack<string> history = new Stack<string>();
        
        public void addHistory(string s)
        {
            history.Push(s);
            Console.WriteLine("visited:" + s);
        }
        public void goBack()
        {
            if (history.Count > 0)
            {
                history.Pop();
                Console.WriteLine("Moving to: " + history.Peek());
            }
            else
            {
                Console.WriteLine("No more history");
            }
        }

        public void historyCount()
        {
            Console.WriteLine("Total visited pages" + history.Count);
        }
        
        public void deleteAll()
        {
            if (history.Count > 0)
            {
                Console.WriteLine("Are you sure you want to delete all history?");
                Console.WriteLine("1. Confirm");
                Console.WriteLine("2. Cancel");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    history.Clear();
                    Console.WriteLine("All history deleted");
                }

                else if (choice == 2)
                {
                    Console.WriteLine("Operation Cancelled");
                }
                else
                {
                    Console.WriteLine("invalid Choice");
                }
            }
            else
            {
                Console.WriteLine("No history to delete");
            }
           
        }
         
    }
    class Program
    {
        static void Main(string[] args)
        {
            History h = new History();
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("============================ Browser History ============================");
                Console.WriteLine("1. Add History");
                Console.WriteLine("2. GoBack");
                Console.WriteLine("3. History Count");
                Console.WriteLine("4. Clear History");
                Console.WriteLine("5. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        Console.WriteLine("Enter url");
                        string url = Console.ReadLine();
                        h.addHistory(url);
                        break;
                    }
                    case 2:
                    {
                        h.goBack();
                        break;
                    }
                    case 3:
                    {
                        h.historyCount();
                        break;
                    }
                    case 4:
                    {
                        h.deleteAll();
                        break;
                    }
                    case 5:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid option");
                        break;
                    }
                }
                
            }
        }
    }
};

