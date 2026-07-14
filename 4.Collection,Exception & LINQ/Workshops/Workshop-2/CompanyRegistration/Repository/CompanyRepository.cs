using Admin_Job.Enums;
using CompanyMember.Exceptions;
using CompanyMember.Interfaces;
using CompanyMember.Model;
using CompanyMember.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMember.Repository
{
	public  class CompanyRepository: ICompanyRepository
	{
		private int nextId = 0;

		private List<Company> Companies = new List<Company>();
		public bool register(Company company)
		{
			company.Id = nextId;
			nextId++;
			if (Companies.Find(e => e.Email == company.Email) == null)
			{
				Companies.Add(company);
				return true;
				
			}
			throw new UserAlreadyExistException(company.Email);
		}
		public List<Company> ListCompanies()
		{
			return Companies;
		}
	}
}
