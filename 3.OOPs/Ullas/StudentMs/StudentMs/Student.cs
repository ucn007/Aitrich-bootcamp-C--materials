namespace MyNamespace;

public class Student
{
    
    private  double _StudentId { get; set; }
    private  string _Name { get; set; }
    private  string _Department { get; set; }
    private static double[] _Mark { get; set; } = new double[5];

    public  double StudentId
    {
        get { return _StudentId; }
        set
        {
            _StudentId = value;
        }
    }

    public  string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Department
    {
        get { return _Department; }
        set { _Department = value; }
    }
    
    public  double[] Mark
    {
        get { return _Mark; }
        set { _Mark = value; } 
    }

    int stdcount = 0;
    static Student[] _student = new Student[10];
    public void addStudent()
    {
        _student[stdcount] = new Student(); 
        Console.WriteLine("Please enter student Id:");
        _student[stdcount].StudentId =  Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter student Name:");
        _student[stdcount].Name = Console.ReadLine();
        Console.WriteLine("Please enter student Department:");
        _student[stdcount].Department = Console.ReadLine();
        Console.WriteLine("Please enter student Mark:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Mark #" + (i + 1) + ": ");
            _student[stdcount].Mark[i] = Convert.ToDouble(Console.ReadLine());
        }

        stdcount++;
        Console.WriteLine("Student Added Successfully");
        Console.ReadKey();
        Console.Clear();
    }

    public void DisplayStudent()
    {
        for (int i = 0; i < stdcount; i++)
        {
            Console.WriteLine("============================ Student Details =======================");
            Console.WriteLine("Student Id: " + _student[i].StudentId);
            Console.WriteLine("Student Name: " + _student[i].Name);
            Console.WriteLine("Student Department: " + _student[i].Department);
            for (int j = 0; j < 5; j++)
            {
                Console.Write("Mark #" + (j + 1) + ": " + _student[i].Mark[j]);
            }
                        
            Console.WriteLine("\n");
        }
    }
}