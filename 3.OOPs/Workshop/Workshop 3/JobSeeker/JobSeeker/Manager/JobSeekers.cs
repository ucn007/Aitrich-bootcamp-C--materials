using JobSeeker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Manager
{
    public class JobSeekers : User
    {
        private const int Max_JobSeeker = 10;
        private const int Max_jobs = 100;
        public JobSeekers[] user = new JobSeekers[Max_JobSeeker];
        private  int numSeeker = 0;


        private Job[] jobs = new Job[Max_jobs];
        private int numJobs = 0;

        int id = 1;
        //Register

        public override void Register()

        {

      //user.Id= id;
            id++;
           
            Console.Write("Enter firstname: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter lastname: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter designation: ");
            string designation = Console.ReadLine();


            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            // Check if username is already taken
          

            // Add provider to array
           var seeker= new JobSeekers(id,
                firstname,
                lastname,
                email,
                designation,
                password);
            user[numSeeker] = seeker;
            numSeeker = numSeeker+1;
          
            Console.WriteLine("Registration successful. Please log in to continue.");
            
        }
        public JobSeekers()
        {

        }


        public JobSeekers(int id, string firstName, string email, string phone, string password, string gender) : base(id,firstName, email, phone, password, gender)
        {
            Id= id;
                FirstName= firstName;
            Email= email;
            Phone= phone;
            Password = password;
            Gender=gender;

        }

      

        //public override void Register()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
