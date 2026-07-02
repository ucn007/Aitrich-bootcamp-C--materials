using System;

namespace MyNamespace
{
    class Program
    {
        struct Account
        {
            public int number;
            public string CustomerName;
            public double Balance;
        }

        static Account[] accounts = new Account[10];
        static int AccountCounter = 0;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n========== Banking System ==========");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit or Withdraw Money");
                Console.WriteLine("3. Show Customer with Highest Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Select Operation: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        if (AccountCounter >= accounts.Length)
                        {
                            Console.WriteLine("Maximum account limit reached.");
                            break;
                        }

                        Console.Write("Enter Account Number: ");
                        int accNo = int.Parse(Console.ReadLine());

                        bool exists = false;

                        for (int i = 0; i < AccountCounter; i++)
                        {
                            if (accounts[i].number == accNo)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (exists)
                        {
                            Console.WriteLine("Account number already exists.");
                            break;
                        }

                        accounts[AccountCounter].number = accNo;

                        Console.Write("Enter Customer Name: ");
                        accounts[AccountCounter].CustomerName = Console.ReadLine();

                        Console.Write("Enter Initial Balance: ");
                        accounts[AccountCounter].Balance = double.Parse(Console.ReadLine());

                        AccountCounter++;

                        Console.WriteLine("Account Created Successfully.");
                        break;
                    }

                    case 2:
                    {
                        Console.Write("Enter Account Number: ");
                        int accNo = int.Parse(Console.ReadLine());

                        bool found = false;

                        for (int i = 0; i < AccountCounter; i++)
                        {
                            if (accounts[i].number == accNo)
                            {
                                found = true;

                                Console.WriteLine($"Welcome {accounts[i].CustomerName}");
                                Console.WriteLine("1. Deposit");
                                Console.WriteLine("2. Withdraw");
                                Console.Write("Choose Option: ");

                                int option = int.Parse(Console.ReadLine());

                                Console.Write("Enter Amount: ");
                                double amount = double.Parse(Console.ReadLine());

                                if (option == 1)
                                {
                                    accounts[i].Balance += amount;

                                    Console.WriteLine("Deposit Successful.");
                                    Console.WriteLine("Current Balance: " + accounts[i].Balance);
                                }
                                else if (option == 2)
                                {
                                    if (amount > accounts[i].Balance)
                                    {
                                        Console.WriteLine("Insufficient Balance.");
                                    }
                                    else
                                    {
                                        accounts[i].Balance -= amount;

                                        Console.WriteLine("Withdrawal Successful.");
                                        Console.WriteLine("Current Balance: " + accounts[i].Balance);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Option.");
                                }

                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Account not found.");
                        }

                        break;
                    }

                    case 3:
                    {
                        if (AccountCounter == 0)
                        {
                            Console.WriteLine("No accounts available.");
                            break;
                        }

                        int index = 0;
                        double maxBalance = accounts[0].Balance;

                        for (int i = 1; i < AccountCounter; i++)
                        {
                            if (accounts[i].Balance > maxBalance)
                            {
                                maxBalance = accounts[i].Balance;
                                index = i;
                            }
                        }

                        Console.WriteLine("\nCustomer With Highest Balance");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Account Number : " + accounts[index].number);
                        Console.WriteLine("Customer Name  : " + accounts[index].CustomerName);
                        Console.WriteLine("Balance        : " + accounts[index].Balance);

                        break;
                    }

                    case 4:
                    {
                        exit = true;
                        Console.WriteLine("Thank you for using the Banking System.");
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Invalid Choice.");
                        break;
                    }
                }
            }
        }
    }
}