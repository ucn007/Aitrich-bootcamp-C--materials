

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Company
{
	public Company()
	{

	}
	public Company(int id, string name, string email, string website, long phone, string about, string vision, string mission, string location, string address)
	{
		Id = id;
		Name = name;
		Email = email;
		Website = website;
		Phone = phone;
		About = about;
		Vision = vision;
		Mission = mission;
		Location = location;
		Address = address;
	}

	public int Id { get; set; }

	public string Name { get; set; }

	public string Email { get; set; } 
	public string Website { get; set; }

	public long Phone { get; set; }
	
	public string About { get; set; }

	public string Vision { get; set; }

	public string Mission { get; set; }

	public string Location { get; set; }

	public string Address { get; set; }



	

	
}
