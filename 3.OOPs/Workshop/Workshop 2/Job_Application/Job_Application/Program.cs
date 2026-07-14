
using Job_Application.Models;
using Job_Application.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitProgram = false;
            JobSeekerManager seekerManager = new JobSeekerManager();

            while (!exitProgram)
            {
                Console.WriteLine(" Welcome To Hire Me Now! \n The jobseeker portal!");
                seekerManager.ShowMainMenu();
            }
        }


    }
}
