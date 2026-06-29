internal class Program
{








    private static void Main(string[] args)
    {

        double[] temp=new double[7];

        temp[0] = 44;
        temp[1] = 33;
        temp[2] = 43;
        temp[3] = 32;
        temp[4] = 33;
        temp[5] = 36;
        temp[6] = 30;


        for (int i = 0; i<temp.Length;i++)
        {
           if(temp[i] == 0) { temp[i] = 0; }
            Console.WriteLine("Average temperature: " + i);
        }


       

    }
}