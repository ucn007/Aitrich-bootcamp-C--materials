
using JobSeeker.Interfaces;
using JobSeeker.Manager;

namespace JobSeeker
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