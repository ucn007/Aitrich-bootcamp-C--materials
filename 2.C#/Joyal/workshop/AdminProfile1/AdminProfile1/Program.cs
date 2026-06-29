internal class Program
{
    struct AdminProfile
    {
        public string fullame;
        public string username;
        public string email;
        public long phone;
    }
    private static void Main(string[] args)
    {
        AdminProfile[] admin = new AdminProfile[1];
        string ch;
        Console.WriteLine("------------\n");
        Console.WriteLine("Welocome to Admin section\n");
        Console.WriteLine("------------\n");
        do
        {
            Console.WriteLine("A - Registerr as admin");
            Console.WriteLine("B - Display admin details");
            Console.WriteLine("----------\n");
            Console.WriteLine("select an option: ");
            string select=Console.ReadLine();
            switch (select) 
            {
                case "A":
                    Console.WriteLine("-----Admin Registeration-----\n");
                    Console.WriteLine("Enter the name of the admin: \n");
                    admin[0].fullame = Console.ReadLine();
                    Console.WriteLine("Enter the username of the admin: \n");
                    admin[0].username = Console.ReadLine();
                    Console.WriteLine("Enter the email of the admin: \n");
                    admin[0].email = Console.ReadLine();
                    Console.WriteLine("Enter the phone number of the admin: \n");
                    admin[0].phone = Convert.ToInt64(Console.ReadLine());

                    break;

                case "B":
                    Console.WriteLine("-----Admin Details------\n");
                    Console.WriteLine($"Admin name: {admin[0].fullame}\n Admin username: {admin[0].username}\n Admin email: {admin[0].email}\n Admin phone number: {admin[0].phone}");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;

            }
            Console.WriteLine("Do you want to continue (Y/N)");
            ch=Console.ReadLine();

        }while (ch=="Y" || ch=="y");
    }
}