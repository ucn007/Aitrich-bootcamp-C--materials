using System;

namespace InventoryApp
{
    public class program
    {



        struct Item
        {
            public int ItemCode;
            public string ItemName;
            public int Quantity;
        }


        public static void Main(string[] args)
        {
            Item[] items = new Item[4];

            Console.WriteLine("Enter  the details ");

            for (int i = 0; i < 4; i++)
            {



                Console.WriteLine("Enter item Code:");
                items[i].ItemCode = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Enter item name :");
                items[i].ItemName = Console.ReadLine();

                Console.WriteLine("Enter Quantity:");
                items[i].Quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();



                Console.Write("Enter Item Code to search: ");
                int searchCode = Convert.ToInt32(Console.ReadLine());


            }
        }
    }
}
        
   

  



