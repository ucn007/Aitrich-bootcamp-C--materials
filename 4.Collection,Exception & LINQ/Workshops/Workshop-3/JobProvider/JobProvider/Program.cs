using JobProvider.Interface;
using JobProvider.Manager;

namespace JobProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new PublicManager();
            menu.DisplayMenu();
        }
    }
}