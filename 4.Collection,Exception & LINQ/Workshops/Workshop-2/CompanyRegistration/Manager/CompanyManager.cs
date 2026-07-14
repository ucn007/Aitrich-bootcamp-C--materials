using CompanyMember.Repository;
using CompanyMember.Exceptions;
using CompanyMember.Interfaces;
using CompanyMember.Model;
using CompanyMember.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CompanyMember.Interfaces;
using CompanyMember;
using System.Security.Cryptography.X509Certificates;

namespace CompanyMemberRegistration.Manager
{
	public class CompanyManager : IMenu
	{

		 CompanyRepository companyRepository=new CompanyRepository();
		CompanyManager cmpmanager;
		Lists list = new Lists();
		IMenu menu;
		public CompanyManager()
		{
		}
		public void DisplayMenu()
		{
			ShowcompanyMenu();
		}
		public void ShowcompanyMenu()
		{

			bool exitProgram = false;


			while (!exitProgram)
			{
				Console.WriteLine("Choose an option:");
				Console.WriteLine("1. Register");
				Console.WriteLine("2. List Companies");
				Console.WriteLine("3. JobProvider Menu");
				Console.WriteLine("4. Exit");
				Console.WriteLine();
				string option1 = Console.ReadLine();
				switch (option1)
				{
					case "1":
						Console.WriteLine("Register A Company");

						RegisterCompany();
						ShowcompanyMenu();
						break;
					case "2":
						
						List<Company>   = companyRepository.ListCompanies();

						list.Print(companies);
						Console.WriteLine();
						ShowcompanyMenu();
						break;
					case "3":Console.WriteLine("Enter Job Provider Menu");
						menu = new ProviderManager();
						menu.DisplayMenu();
						break;
					case "4":
						exitProgram = true;
						break;
					default:
						Console.WriteLine("invalid option ");
						break;
				}


			}
			void RegisterCompany()
			{
				try
				{
					Company company = new Company();
					// Register(company);
					Console.WriteLine("Please enter your Company Name:");
					company.Name = Console.ReadLine();
					company.Email = GetEmail();

					Console.WriteLine("Please enter your Company Website");

					company.Website = Console.ReadLine();
					

					company.Phone = GetPhoneNumber();

					Console.WriteLine("Enter about Company");
					company.About = Console.ReadLine();
					Console.WriteLine("Enter Company Vision");
					company.Vision = Console.ReadLine();
					Console.WriteLine("Enter Company Mission");
					company.Mission = Console.ReadLine();
					Console.WriteLine("Enter Company Location");
					company.Location = Console.ReadLine();
					Console.WriteLine("enter Company Address");
					company.Address = Console.ReadLine();

					bool result=companyRepository.register(company);
					if(result==true)
					{
						Console.WriteLine("!!!!!!!!Registration successful!!!!!!!");
						Console.ReadLine();
						
						ShowcompanyMenu();
					}
					
				}
				catch (UserAlreadyExistException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
			}
		}
			public string GetEmail()
			{
				try
				{
					Console.WriteLine("Please enter your email address:");
					string email = Console.ReadLine();
					Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");

					if (!regex.IsMatch(email))
						throw new InvalidFormatException("email was not in correct format :" + email);
					return email;
				}
				catch (InvalidFormatException ex)
				{
					Console.WriteLine(ex.Message + "\n");
					Console.WriteLine("try again...");
					return GetEmail();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message + "\n");
					return GetEmail();
				}
			}
			private long GetPhoneNumber()
			{
				try
				{
					Console.WriteLine("Please enter your phone number:");
					long Phone = long.Parse(Console.ReadLine());
					return Phone;
				}
				catch (Exception e)
				{
					Console.WriteLine("Enter valid phone number");
					return GetPhoneNumber();
				}
			}

		}
	}

