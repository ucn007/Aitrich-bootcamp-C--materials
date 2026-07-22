using Exercise.Manager;

namespace  WorkShop;
public class Program
{
    public static void Main(string[] args)
    {
        PublicManager manager = new PublicManager();
        manager.ShowMenu();
    }
}