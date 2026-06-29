internal class Program
{
    struct Student{
        public int RollNo;
        public string Name;
        public int g1, g2, g3, g4, g5;
        public double average;
    }
    static void Main(string[] args)
    {
        Console.Write("Enter the no.of students: ");
        int n=int.Parse(Console.ReadLine());

        Student[] students = new Student[n];
       

        for(int i=0; i<n; i++)
        {
            Console.Write("Enter Rollno:");
            students[i].RollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter name:");
            students[i].Name = Console.ReadLine();
            Console.WriteLine($"Enter grade of 5 subject for student {i+1}:");
            Console.Write($"Enter the grade for subject1:");
            students[i].g1=int.Parse(Console.ReadLine());
            Console.Write($"Enter the grade for subject2:");
            students[i].g2 = int.Parse(Console.ReadLine());
            Console.Write($"Enter the grade for subject3:");
            students[i].g3 = int.Parse(Console.ReadLine());
            Console.Write($"Enter the grade for subject4:");
            students[i].g4 = int.Parse(Console.ReadLine());
            Console.Write($"Enter the grade for subject5:");
            students[i].g5 = int.Parse(Console.ReadLine());
            students[i].average = (students[i].g1 + students[i].g2 + students[i].g3 + students[i].g4 + students[i].g5) / 5;
            Console.WriteLine();
            
            Console.WriteLine("Students details :");
            Console.WriteLine();
            Console.WriteLine($"\nRoll no: {students[i].RollNo} \nName: {students[i].Name} \ngrade for subject1: {students[i].g1} \ngrade for subject2: {students[i].g2} \ngrade for subject3: {students[i].g3}  \ngrade for subject4: {students[i].g4} \ngrade for subject5: {students[i].g5}  ");
            Console.WriteLine($"Average of grade: {students[i].average}");
            Console.WriteLine();
        }

    }
}