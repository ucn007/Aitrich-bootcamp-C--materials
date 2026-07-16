namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            List <int> numbers = new List<int>() {80,10,20,35,40,55,60,75,80};
            
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. List numbers Greater than 50 ");
                Console.WriteLine("2. List All Even numbers  ");
                Console.WriteLine("3. List All Odd numbers  ");
                Console.WriteLine("4. List First number greater than 50  "); 
                Console.WriteLine("5. Count of All numbers greater than 50  ");
                Console.WriteLine("6. Count of All numbers    ");
                Console.WriteLine("7. Check  exist or not  ");
                Console.WriteLine("8. Find Larger number , Small Number, Average");
                Console.WriteLine("9. Sort Numbers");
                Console.WriteLine("10. Sort By decending");
                Console.WriteLine("11. Remove Duplicate Values");
                Console.WriteLine("12. Take numbers by limit");
                Console.WriteLine("13. Skip  numbers by limit");
                
                Console.WriteLine("\n\nEnter Choice: ");
                
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        var result = numbers.Where(x => x > 50);
                        Console.WriteLine("Numbers > 50");
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                       break;
                    }
                    case 2:
                    {
                        var result = numbers.Where(x => x % 2 == 0);
                        Console.WriteLine("Even numbers  ");
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 3:
                    {
                        var result = numbers.Where(x => x % 2 != 0);
                        Console.WriteLine("Odd numbers  ");
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 4:
                    {
                        var result = numbers.First(x => x > 50);
                        Console.WriteLine("First number greater than 50:" + result);
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 5:
                    {
                       var result = numbers.Count(x => x > 50); 
                       Console.WriteLine("Count of numbers greater than 50:" + result);
                       Console.WriteLine("\n\n");
                       break;
                    }
                    case 6:
                    {
                        var result = numbers.Count(); 
                        Console.WriteLine("Total numbers :" + result);
                        Console.WriteLine("\n\n");
                        break;
                    }
                    
                    case 7:
                    {
                        Console.WriteLine("Enter number to check ");
                        int searchNumber = Convert.ToInt32(Console.ReadLine());
                        var result = numbers.Any(x => x == searchNumber);
                        if (result == true)
                        {
                            Console.WriteLine("Number Exist");
                            
                        }
                        else
                        {
                            Console.WriteLine("Number Not Exist");
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 8:
                    {
                        var max =  numbers.Max(x => x);
                        var min = numbers.Min(x => x);
                        var avg =  numbers.Average(x => x);
                        Console.WriteLine("Max number :" + max);
                        Console.WriteLine("Min number :" + min);
                        Console.WriteLine("Avg number :" + avg);
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 9:
                    {
                        var result = numbers.OrderBy(x => x).ToList();
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 10:
                    {
                        var result = numbers.OrderByDescending(x => x).ToList();
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 11:
                    {
                        var result = numbers.Distinct().ToList();
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Duplicates Removed");
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 12:
                    {
                        Console.WriteLine("Enter the limit ");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        var result = numbers.Take(limit).ToList();
                        Console.WriteLine("Numbers upto the limit: " + limit);
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                    case 13:
                    {
                        Console.WriteLine("Enter the limit to skip");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        var result = numbers.Skip(limit).ToList();
                        Console.WriteLine("Numbers skipped upto the limit: " + limit);
                        foreach (var item in result)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n\n");
                        break;
                    }
                }
            }
            
           

          
        }
    }
};

