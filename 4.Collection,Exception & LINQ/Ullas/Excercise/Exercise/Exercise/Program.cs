using Exercise.Interface;
using Exercise.Manager;

namespace Exercise;

public class Program
{
    public static void Main(string[] args)
    {
        PublicManager manager = new PublicManager();
        manager.ShowMenu();
    }


}