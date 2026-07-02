
namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        double z = 3.74 ;
        Console.WriteLine((int)z);
      Console.WriteLine("enter first number:");
      int a = int.Parse(Console.ReadLine());
      Console.WriteLine("enter second number:");
      int b = int.Parse(Console.ReadLine());
      
      Console.WriteLine("enter second number:");
      int c = int.Parse(Console.ReadLine());

      if (a > b)
      {
          if (a > c)
          {
              Console.WriteLine(a);
          }
          else
          {
              Console.WriteLine(c);
          }
      }
      else 
      {
          if (b > c)
          {
              Console.WriteLine(b);
          }
          else
          {
              Console.WriteLine(c);
          }
      }  
      
      
      Console.WriteLine("enter number between 1 to 10");
      int l =int.Parse(Console.ReadLine());

      switch (l)
      {
          case 1:
          {
              Console.WriteLine(1);
              break;
          }
          case 2:
          {
              Console.WriteLine(2);
              break;
          }
          case 3:
          {
              Console.WriteLine(3);
              break;
          }
          case 4:
          {
              Console.WriteLine(4);
              break;
          }
          case 5:
          {
              Console.WriteLine(5);
              break;
          }
          case 6:
          {
              Console.WriteLine(6);
              break;
          }
          case 7:
          {
              Console.WriteLine(7);
              break;
          }
          case 8:
          {
              Console.WriteLine(8);
              break;
          }
          case 9:
          {
              Console.WriteLine(9);
              break;
          }
          case 10:
          {
              Console.WriteLine(10);
              break;
          }
      }

      string[] cars = { "Suzuki, Mahindra, Volvo, BMW, Benz" };
      foreach (string car in cars)
      {
          Console.WriteLine(car);
      }

      int i = 0; 
      do
      {
          
          Console.WriteLine(cars[i++]);
          i++;
      }
      while (i < cars.Length);

    }
    
}