using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Transactions;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//Console.WriteLine("Hello, World!");
//Console.Write("good morning");
//Console.WriteLine("good night");

//Console.WriteLine("enter your name");
//string name = Console.ReadLine();

//Console.WriteLine("Enter your age");
//string age = Console.ReadLine();

//Console.WriteLine("iam" + name + age + "years old");
//Console.WriteLine("I'm {0},I'm {1} years old", name, age);
//Console.WriteLine($ "I'm {name}, I'm  {age} years old ");


//Console.WriteLine("enter  First number");
//int a = int.Parse(Console.ReadLine());
//Console.WriteLine("enter second number");
//int b = int.Parse(Console.ReadLine());

//Console.WriteLine("sum  of two numbers is = " + (a + b));


//Console.WriteLine("Enter First number");
//int a = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter Second number");
//int b = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter Third number");
//int c = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter Fourth number");
//int d = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter Fifth number");
//int e = int.Parse(Console.ReadLine());

//double avg = (a + b + c + d + e) / 5.0;
//Console.WriteLine("Average of five numbers is = " + avg);


//Console.WriteLine("Enter A number:");
//int num = int.Parse(Console.ReadLine());

//if (num % 2 == 0)
//{
//    Console.WriteLine(num + "is an Even Number");
//}
//else
//{
//    Console.WriteLine(num + "is an Odd Number");
//}



//Console.WriteLine("Enter a year:");
//int year = int.Parse(Console.ReadLine());

//if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
//{
//    Console.WriteLine(year + "is a leap year");
//}
//else
//{
//    Console.WriteLine(year + "is not a leap year");
//}


//Console.Write("Enter the radius of the circle: ");
//double radius = double.Parse(Console.ReadLine());

//double area = Math.PI * radius * radius;

//Console.WriteLine("Area of the circle = " + area);


//Console.WriteLine("Enter First Number:");
//int num1 = int.Parse(Console.ReadLine());

//Console.WriteLine("Enter Second Number");
//int num2 = int.Parse(Console.ReadLine());

//if(num1>num2)
//{
//    Console.WriteLine(num1 + "is the biggest number ");
//}
//else if(num2 > num1){
//    Console.WriteLine(num2 + "is the biggest number");
//}
//else
//{
//    Console.WriteLine("Both Numbers are equal");
//}



//        Console.Write("Enter first number: ");
//        int num1 = Convert.ToInt32(Console.ReadLine());

//        Console.Write("Enter second number: ");
//        int num2 = Convert.ToInt32(Console.ReadLine());

//        Console.Write("Enter third number: ");
//        int num3 = Convert.ToInt32(Console.ReadLine());

//if (num1 >= num2 && num1 >= num3)
//{
//    Console.WriteLine(num1 + " is the biggest number.");
//}
//else if (num2 >= num1 && num2 >= num3)
//{
//    Console.WriteLine(num2 + " is the biggest number.");
//}
//else
//{
//    Console.WriteLine(num3 + " is the biggest number.");
//}






//    Console.WriteLine("Enter first number: ");
//    int a = Convert.ToInt32(Console.ReadLine());

//    Console.WriteLine("Enter second number: ");
//    int b = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("\nBefore swapping: a = " + a);
//Console.WriteLine("\nBefore Swapping: b= " + b);


//    int temp = a;
//    a = b;
//    b = temp;

//Console.WriteLine("After swapping: a = " + a);
//Console.WriteLine("After Swapping: b= " + b);



//Console.Write("Enter a string: ");
//string text = Console.ReadLine();

//int length = text.Length;

//Console.WriteLine("Length of the string = " + length);






// Console.WriteLine("Enter number of subjects: ");
//int n = int.Parse(Console.ReadLine());

//double totalMarks = 0;

//for (int i = 1; i <= n; i++)
//{
//    Console.Write("Enter marks of subject " + i + ": ");
//    double marks = double.Parse(Console.ReadLine());
//    totalMarks += marks;
//}

//double averageMarks = totalMarks / n;


//double cgpa = averageMarks / 9.5;

//Console.WriteLine("\nAverage Marks = " + averageMarks);
//Console.WriteLine("Your CGPA = " + cgpa.ToString("0.00"));




//Console.WriteLine("Choose one traffic color: red,yellow,green");
//string color = Console.ReadLine().ToLower();

//switch (color)
//{
//    case "red":
//        Console.WriteLine("you entered red color, STOP Vehicle");
//        break;

//    case "yellow":
//        Console.WriteLine("you entered yellow color,  GET READY ");
//        break;

//    case "Green":
//        Console.WriteLine("you entered green color, Go ");
//        break;
//    default:
//        Console.WriteLine("Invalid error  choose RED,GREEN,YELLOW");
//        break;





//}





//for (int i = 1; i <= 10; i++)
//{
//    Console.WriteLine(i);
//}





//int num = 5;

//for (int i = 1; i <= 10; i++)
//{
//    Console.WriteLine("5 x " + i + " = " + (5 * i));
//}





//int sum = 0;

//for (int i = 1; i <= 50; i++)
//{
//    if (i % 2 == 0) 
//    {
//        sum += i;   
//    }
//}

//Console.WriteLine("Sum of even numbers from 1 to 50 is: " + sum);





//for(int i=100; i>=50; i--)
//{
//    Console.WriteLine(i);
//}




//for (int i = 1; i <= 50; i++)
//{
//    if (i % 3 == 0 && i % 5 == 0)
//        Console.WriteLine("fizzBuzz");

//    else if (i % 3 == 0)
//        Console.WriteLine("Fizz");


//    else if (i % 5 == 0)

//        Console.WriteLine("Buzz");
//    else
//        Console.WriteLine(i);
//}











//Console.WriteLine("Enter a number:");
//int number = int.Parse(Console.ReadLine());

//int original = number;
//int reverse = 0;

//while (number > 0)
//{
//    int digit = number % 10;
//    reverse = reverse * 10 + digit;
//    number = number / 10;
//}

//if (original == reverse)
//{
//    Console.WriteLine("The number is a Palindrome.");
//}
//else
//{
//    Console.WriteLine("The number is not a Palindrome.");
//}







//Console.WriteLine("Hello");
//Console.WriteLine("Clerin");



//Console.WriteLine("Ener the number:");
//    string input = Console.ReadLine();
//     int number=int.Parse(input);
//Console.WriteLine("{0} {0}  {0} {0}",number);
//Console.WriteLine("{0}{0}{0}{0}", number);
//Console.WriteLine("{0} {0} {0} {0}", number);
//Console.WriteLine("{0}{0}{0}{0}", number);



//int totalAmount = 1000;
//int balance = 0;
//int i = 1;
//Console.WriteLine("Enter the withdrawal amount:");
//int withdrawal = Convert.ToInt32(Console.ReadLine());

//while (int <= 1)
//{
//if (withdrawal <= totalamount)
//{
//        totalAmount -= withdrawal;

//        Console.WriteLine("Withdrawl successful");
//        Console.WriteLine("remaining balance: " + totalAmount);
//}





//int password = 12345678;
//Console.WriteLine("Enter the  password");
//int a = Convert.ToInt32(Console.ReadLine());

//while (a==password)
//{
//    Console.WriteLine("you Entered Successfully!!");
//    break;
//}
//if (a!=password)
//{
//    Console.WriteLine("password is incorrect");

//}


//Console.Write("Enter number of rows: ");
//int rows = Convert.ToInt32(Console.ReadLine());

//for (int i = 1; i <= rows; i++)
//{
//    for (int j = 1; j <= i; j++)
//    {
//        Console.Write("* ");
//    }
//    Console.WriteLine();
//}


//Console.Write("Enter number of rows: ");
//int rows = Convert.ToInt32(Console.ReadLine());

//for (int i = rows; i >= 1; i--)
//{
//    for (int j = 1; j <= i; j++)
//    {
//        Console.Write("* ");
//    }
//    Console.WriteLine();
//}


//Console.Write("Enter number of rows: ");
//int rows = Convert.ToInt32(Console.ReadLine());

//for (int i = 1; i <= rows; i++)
//{

//    for (int space = i; space < rows; space++)
//    {
//        Console.Write(" ");
//    }


//    for (int num = 1; num <= i; num++)
//    {
//        Console.Write(num + " ");
//    }

//    Console.WriteLine();
//}




//Console.Write("Enter number of rows: ");
//int rows = Convert.ToInt32(Console.ReadLine());

//for (int i = 1; i <= rows; i++)
//{

//    for (int space = i; space < rows; space++)
//    {
//        Console.Write(" ");
//    }


//    for (int star = 1; star <= (2 * i - 1); star++)
//    {
//        Console.Write("*");
//    }

//    Console.WriteLine();
//}




//Console.Write("Enter number of rows: ");
//int rows = Convert.ToInt32(Console.ReadLine());

//for (int i = 1; i <= rows; i++)
//{

//    for (int space = 1; space <= rows - i; space++)
//    {
//        Console.Write(" ");
//    }


//    for (int star = 1; star <= (2 * i - 1); star++)
//    {
//        Console.Write("*");
//    }

//    Console.WriteLine();
//}



//for (int rows = 1; rows <= 10; rows++)
//{
//    for (int cols = 1; cols <= rows; cols++)
//    {

//        Console.Write(" * ");
//    }
//    Console.WriteLine();
//}



//for(int rows=5;  rows>=1; rows--)
//{
//    for (int cols = 1; cols<=rows; cols++)
//    {
//        Console.Write("*");
//    }
//    Console.WriteLine();
//}

//int k= 5;


//for (int rows = 1; rows <= 5; rows++)
//{
//    for(int cols=1;  cols<=rows; cols++)
//    {
//        Console.Write(" ");
//    }
//    Console.WriteLine();
//}



//array problems


//int[] num = new int[5];

//num[0] = 10;
//num[1] = 20;
//num[2] = 30;
//num[3] = 40;
//num[4] = 50;

//int sum = 0;

//for (int i = 0; i < num.Length; i++)
//{
//    sum += num[i];

//}
//Console.WriteLine("sum of array is:" + sum);




//int[] largest = new int[7];

//largest[0] = 20;
//largest[1] = 34;
//largest[2] = 68;
//largest[3] = 50;
//largest[4] = 70;
//largest[5] = 90;
//largest[6] = 98;

//int biggest = largest[0];

//for(int i=0; i<largest.Length; i++)
//{
//    if (largest[i]>biggest)
//    {
//        biggest = largest[i];
//    }


//}
//Console.WriteLine("largest element in the array is:" + biggest);




//int[] count = new int[7];

//count[0] = 2;
//count[1] = 5;
//count[2] = 9;
//count[3] = 7;
//count[4] = 6;
//count[5] = 10;
//count[6] = 3;

//int  evencount= 0;
//int  oddcount = 0;

//for (int i = 0; i < count.Length; i++)
//{
//    if (count[i] % 2 == 0)
//    {
//        evencount++;
//    }
//    else
//    {
//        oddcount++;
//    }
//}
//    Console.WriteLine("Total even numbers is:" + evencount);
//    Console.WriteLine("Total odd numbers is :" + oddcount);




//int[] reverse = new int[4];

//reverse[0] = 1;
//reverse[1] = 2;
//reverse[2] = 3;
//reverse[3] = 4;



//for (int i = reverse.Length - 1; i >= 0; i--)
//{

//    Console.WriteLine(reverse[i]);
//}





//Console.WriteLine("Enter the element to search:");
//int value = Convert.ToInt32(Console.ReadLine());  // ✅ user input

//int[] search = new int[5];

//search[0] = 1;
//search[1] = 2;
//search[2] = 3;
//search[3] = 4;
//search[4] = 5;

//bool found = false;  // flag to track if found

//for (int i = 0; i < search.Length; i++)
//{
//    if (search[i] == value)   // ✅ correct variable name
//    {
//        found = true;
//        break;  // stop once found
//    }
//}

//if (found)
//{
//    Console.WriteLine("This number exists in the array.");
//}
//else
//{
//    Console.WriteLine("This number does not exist in the array.");
//}



//matrix problems

//int[,] matrix = new int[3, 3];

//matrix[0, 0] = 45;
//matrix[0, 1] = 22;
//matrix[0, 2] = 32;
//matrix[1, 0] = 98;
//matrix[1, 1] = 76;
//matrix[1, 2] = 54;
//matrix[2, 0] = 31;
//matrix[2, 1] = 80;
//matrix[2, 2] = 13;

//int sum = 0;

//for(int i=0; i<3;i++)
//{
//    for (int j = 0; j < 3; j++)
//        sum += matrix[i, j];
//}
//Console.WriteLine("sum:" + sum);




//int[,] mul = new int[2, 2];
//mul[0, 0] = 1;
//mul[0, 1] = 2;
//mul[1, 0] = 3;
//mul[1, 1] = 4;

//int muls = 1;

//for(int i=0; i<2; i++)
//{
//    for (int j = 0; j < 2; j++)
//        muls *= mul[i ,j];
//}
//Console.WriteLine("multiplication is:" + muls);



//int[,] sums = new int[3, 3];

//sums[0, 0] = 0;
//sums[0, 1] = 1;
//sums[0, 2] = 2;
//sums[1, 0] = 3;
//sums[1, 1] = 4;
//sums[1, 2] = 5;

//sums[2, 0] = 7;
//sums[2, 1] = 8;
//sums[2, 2] = 9;

//for (int i = 0; i < 3; i++)
//{


//    int rowsums = 0;
//    for (int j = 0; j < 3; j++)
//    {
//        rowsums += sums[i, j];
//    }
//    Console.WriteLine("sum of row " + (i + 1) + "=" + rowsums);
//}
//for(int j = 0; j < 3; j++)
//{
//    int colsums = 0;
//    for(int i=0; i < 3; i++)
//    {
//        colsums += sums[i, j];
//    }
//    Console.WriteLine("sum of coumn" + (j + 1) + "=" + colsums);
//}




//int[,] Transpose = new int[3, 3];

//Transpose[0, 0] = 1;
//Transpose[0, 1] = 2;
//Transpose[0, 2] = 3;
//Transpose[1, 0] = 4;
//Transpose[1, 1] = 5;
//Transpose[1, 2] = 6;
//Transpose[2, 0] = 7;
//Transpose[2, 1] = 8;
//Transpose[2, 2] = 9;


//for (int i = 0; i < 3; i++)
//{
//    for (int j = 0; j < 3; j++)
//    {
//        Console.Write(Transpose[i, j] + "");
//    }
//    Console.WriteLine();
//}





//for (int i = 0; i < 3; i++)
//{
//    for (int j = 0; j < 3; j++)
//    {
//        Console.Write(Transpose[j, i] + "");

//    }
//    Console.WriteLine();
//}





//int[][] marks = new int[3][];
//marks[0] = new int[] { 10, 20, 30 };
//marks[1] = new int[] { 40, 50, 90, 65, 97 };
//marks[2] = new int[] { 43, 85 };


//int sum = 0;

//for (int i = 0; i < marks.Length; i++)
//{
//    for (int j = 0; j < marks[i].Length; j++)
//    {

//        sum += marks[i][j] ;

//    }
//    Console.WriteLine("sum of jagged array is:" + sum);


//}







//int[][] month = new int[3][];

//month[0] = new int[] { 31 };
//month[1] = new int[] { 28 };
//month[2] = new int[] { 30 };

//for (int i = 0; i < month.Length; i++)
//{
//    Console.WriteLine("Month " + (i + 1) + " has " + month[i][0] + " days");
//}





//int[][] star = new int[4][];

//star[0] = new int[1];
//star[1] = new int[2];
//star[2] = new int[3];
//star[3] = new int[4];

//for (int i = 0; i < star.Length; i++)
//{
//    for (int j = 0; j < star[i].Length; j++)
//    {
//        Console.Write("*");
//    }
//

//Console.WriteLine();









//int[] largest = new int[3] { 4, 5, 8 };

//int max = largest[0];

//foreach (int num in largest)
//{
//    if (num > max)
//        max = num;
//}

//Console.WriteLine("Largest element in the array is: " + max);






//class programs
//{


//    enum TrafficLight { red, Yellow, green }

//    static void Main()
//    {
//        TrafficLight signal = TrafficLight.red;

//        if (signal == TrafficLight.red)
//        {
//            Console.WriteLine("Stop");
//        }
//        else if (signal == TrafficLight.Yellow)
//        {
//            Console.WriteLine("Ready to go");
//        }
//        else
//        {
//            Console.WriteLine("Go");
//        }

//    }
//}


//using System;
//class nothing
//{
//    enum OrderStatus { pending, shipped, Delivered, Cancelled }

//    static void Main()
//    {
//        OrderStatus status = OrderStatus.pending;

//        switch (status)
//        {
//            case OrderStatus.pending:
//                Console.WriteLine("pending");
//                break;

//            case OrderStatus.shipped:
//                Console.WriteLine("Shipped");
//                break;
//            case OrderStatus.Delivered:
//                Console.WriteLine("Delivrered");
//                break;
//            case OrderStatus.Cancelled:
//                Console.WriteLine("Cancelled");
//                break;
//            default:
//                Console.WriteLine("invalid");
//                break;



//        }
//    }
//}



//using System;

//class Hello
//{
//    enum CoffeeSize { Small = 1, Medium = 2, Large = 3 }

//    static void Main()
//    {
//        Console.WriteLine("Choose a coffee size:");
//        Console.WriteLine("1. Small");
//        Console.WriteLine("2. Medium");
//        Console.WriteLine("3. Large");
//        Console.Write("Enter your choice (1-3): ");

//        int choice = Convert.ToInt32(Console.ReadLine());
//        CoffeeSize selectedSize = (CoffeeSize)choice;

//        if (selectedSize == CoffeeSize.Small)
//        {
//            Console.WriteLine("You selected small coffee.");
//        }
//        else if (selectedSize == CoffeeSize.Medium)
//        {
//            Console.WriteLine("You selected medium coffee.");
//        }
//        else if (selectedSize == CoffeeSize.Large)
//        {
//            Console.WriteLine("You selected large coffee.");
//        }
//        else
//        {
//            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
//        }
//    }
//}




using System;

//class Program
//{

//    enum JobRole { Manager, Developer, Designer, Tester }

//    static void Main()
//    {

//        JobRole role = JobRole.Developer;


//        if (role == JobRole.Manager)
//        {
//            Console.WriteLine("You are managing the project.");
//        }
//        else if (role == JobRole.Developer)
//        {
//            Console.WriteLine("You are developing software.");
//        }
//        else if (role == JobRole.Designer)
//        {
//            Console.WriteLine("You are creating UI designs.");
//        }
//        else if (role == JobRole.Tester)
//        {
//            Console.WriteLine("You are testing the application.");
//        }
//    }
//}





//using System;

//class Program
//{

//    enum TicketType { Child = 1, Adult = 2, Senior = 3 }

//    static void Main()
//    {

//        TicketType ticket = TicketType.Adult;


//        if (ticket == TicketType.Child)
//        {
//            Console.WriteLine("Ticket Price: ₹100");
//        }
//        else if (ticket == TicketType.Adult)
//        {
//            Console.WriteLine("Ticket Price: ₹200");
//        }
//        else if (ticket == TicketType.Senior)
//        {
//            Console.WriteLine("Ticket Price: ₹150");
//        }
//    }




//using System;

//class Program
//{

//    enum Weather { Sunny, Rainy, Cloudy, Stormy }

//    static void Main()
//    {

//        Weather today = Weather.Rainy;


//        if (today == Weather.Sunny)
//        {
//            Console.WriteLine("Wear sunglasses.");
//        }
//        else if (today == Weather.Rainy)
//        {
//            Console.WriteLine("Carry an umbrella.");
//        }
//        else if (today == Weather.Cloudy)
//        {
//            Console.WriteLine("It might rain soon.");
//        }
//        else if (today == Weather.Stormy)
//        {
//            Console.WriteLine("Stay indoors for safety.");
//        }
//    }
//}      


//using System;

//class Program
//{

//    struct Employee
//    {
//        public int EmployeeId;
//        public string EmployeeName;
//        public string Department;
//        public double Salary;
//    }

//    static void Main()
//    {

//        Employee emp1;
//        emp1.EmployeeId = 101;
//        emp1.EmployeeName = "John Doe";
//        emp1.Department = "HR";
//        emp1.Salary = 35000;


//        Employee emp2;
//        emp2.EmployeeId = 102;
//        emp2.EmployeeName = "Clerin Paul";
//        emp2.Department = "IT";
//        emp2.Salary = 50000;


//        Console.WriteLine("Employee 1 Details:");
//        Console.WriteLine("ID: " + emp1.EmployeeId);
//        Console.WriteLine("Name: " + emp1.EmployeeName);
//        Console.WriteLine("Department: " + emp1.Department);
//        Console.WriteLine("Salary: ₹" + emp1.Salary);
//        Console.WriteLine();

//        Console.WriteLine("Employee 2 Details:");
//        Console.WriteLine("ID: " + emp2.EmployeeId);
//        Console.WriteLine("Name: " + emp2.EmployeeName);
//        Console.WriteLine("Department: " + emp2.Department);
//        Console.WriteLine("Salary: ₹" + emp2.Salary);
//    }
//}




//using System;

//class Program
//{
//    // Define structure
//    struct Product
//    {
//        public int ProductId;
//        public string ProductName;
//        public string Category;
//        public double Price;
//    }

//    static void Main()
//    {

//        Product p1;
//        p1.ProductId = 201;
//        p1.ProductName = "Laptop";
//        p1.Category = "Electronics";
//        p1.Price = 55000;


//        Product p2;
//        p2.ProductId = 202;
//        p2.ProductName = "Chair";
//        p2.Category = "Furniture";
//        p2.Price = 2500;


//        Product p3;
//        p3.ProductId = 203;
//        p3.ProductName = "T-Shirt";
//        p3.Category = "Clothing";
//        p3.Price = 800;

//        Console.WriteLine("Product 1 Details:");
//        Console.WriteLine("ID: " + p1.ProductId);
//        Console.WriteLine("Name: " + p1.ProductName);
//        Console.WriteLine("Category: " + p1.Category);
//        Console.WriteLine("Price: ₹" + p1.Price);
//        Console.WriteLine();

//        Console.WriteLine("Product 2 Details:");
//        Console.WriteLine("ID: " + p2.ProductId);
//        Console.WriteLine("Name: " + p2.ProductName);
//        Console.WriteLine("Category: " + p2.Category);
//        Console.WriteLine("Price: ₹" + p2.Price);
//        Console.WriteLine();

//        Console.WriteLine("Product 3 Details:");
//        Console.WriteLine("ID: " + p3.ProductId);
//        Console.WriteLine("Name: " + p3.ProductName);
//        Console.WriteLine("Category: " + p3.Category);
//        Console.WriteLine("Price: ₹" + p3.Price);
//    }
//}





//using System;

//class Program
//{
//    // Define structure
//    struct Student
//    {
//        public int RollNo;
//        public string Name;
//        public string Course;
//        public int TotalMarks;
//    }

//    static void Main()
//    {

//        Student s1;
//        s1.RollNo = 1;
//        s1.Name = "Alice Johnson";
//        s1.Course = "Computer Science";
//        s1.TotalMarks = 480;


//        Student s2;
//        s2.RollNo = 2;
//        s2.Name = "Clerin Paul";
//        s2.Course = "Information Technology";
//        s2.TotalMarks = 450;


//        Student s3;
//        s3.RollNo = 3;
//        s3.Name = "Rahul Sharma";
//        s3.Course = "Electronics";
//        s3.TotalMarks = 420;


//        Console.WriteLine("Student 1 Details:");
//        Console.WriteLine("Roll No: " + s1.RollNo);
//        Console.WriteLine("Name: " + s1.Name);
//        Console.WriteLine("Course: " + s1.Course);
//        Console.WriteLine("Total Marks: " + s1.TotalMarks);
//        Console.WriteLine();

//        Console.WriteLine("Student 2 Details:");
//        Console.WriteLine("Roll No: " + s2.RollNo);
//        Console.WriteLine("Name: " + s2.Name);
//        Console.WriteLine("Course: " + s2.Course);
//        Console.WriteLine("Total Marks: " + s2.TotalMarks);
//        Console.WriteLine();

//        Console.WriteLine("Student 3 Details:");
//        Console.WriteLine("Roll No: " + s3.RollNo);
//        Console.WriteLine("Name: " + s3.Name);
//        Console.WriteLine("Course: " + s3.Course);
//        Console.WriteLine("Total Marks: " + s3.TotalMarks);
//    }
//}




//using System;

//class Program
//{

//    struct Car
//    {
//        public string CarNumber;
//        public string CarModel;
//        public string CompanyName;
//        public double Price;
//    }

//    static void Main()
//    {

//        Car car1;
//        car1.CarNumber = "TN09AB1234";
//        car1.CarModel = "Swift";
//        car1.CompanyName = "Maruti Suzuki";
//        car1.Price = 700000;


//        Car car2;
//        car2.CarNumber = "KL07CD5678";
//        car2.CarModel = "Creta";
//        car2.CompanyName = "Hyundai";
//        car2.Price = 1500000;


//        Console.WriteLine("Car 1 Details:");
//        Console.WriteLine("Car Number: " + car1.CarNumber);
//        Console.WriteLine("Car Model: " + car1.CarModel);
//        Console.WriteLine("Company Name: " + car1.CompanyName);
//        Console.WriteLine("Price: ₹" + car1.Price);
//        Console.WriteLine();

//        Console.WriteLine("Car 2 Details:");
//        Console.WriteLine("Car Number: " + car2.CarNumber);
//        Console.WriteLine("Car Model: " + car2.CarModel);
//        Console.WriteLine("Company Name: " + car2.CompanyName);
//        Console.WriteLine("Price: ₹" + car2.Price);
//    }
//}





//using System;

//class Program
//{
    
//    struct Book
//    {
//        public int BookId;
//        public string Title;
//        public string Author;
//        public double Price;
//    }

//    static void Main()
//    {
       
//        Book b1;
//        b1.BookId = 101;
//        b1.Title = "The Alchemist";
//        b1.Author = "Paulo Coelho";
//        b1.Price = 350;

       
//        Book b2;
//        b2.BookId = 102;
//        b2.Title = "Clean Code";
//        b2.Author = "Robert C. Martin";
//        b2.Price = 550;

        
//        Book b3;
//        b3.BookId = 103;
//        b3.Title = "Introduction to Algorithms";
//        b3.Author = "Thomas H. Cormen";
//        b3.Price = 950;

        
//        Console.WriteLine("Book 1 Details:");
//        Console.WriteLine("Book ID: " + b1.BookId);
//        Console.WriteLine("Title: " + b1.Title);
//        Console.WriteLine("Author: " + b1.Author);
//        Console.WriteLine("Price: ₹" + b1.Price);
//        Console.WriteLine();

//        Console.WriteLine("Book 2 Details:");
//        Console.WriteLine("Book ID: " + b2.BookId);
//        Console.WriteLine("Title: " + b2.Title);
//        Console.WriteLine("Author: " + b2.Author);
//        Console.WriteLine("Price: ₹" + b2.Price);
//        Console.WriteLine();

//        Console.WriteLine("Book 3 Details:");
//        Console.WriteLine("Book ID: " + b3.BookId);
//        Console.WriteLine("Title: " + b3.Title);
//        Console.WriteLine("Author: " + b3.Author);
//        Console.WriteLine("Price: ₹" + b3.Price);
//    }
//}




        

































































































































