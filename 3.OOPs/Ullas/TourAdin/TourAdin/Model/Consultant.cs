using TourAdin.Interface;

namespace TourAdin.Model;

public class Consultant: IAgency_Consultant
{
    private int _id;
    private string _name;
    private string _email;
    private double _phone;
    private string _address;
    private string _city;
    private string _state;
    private string _country;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public double Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }
    
    
    
}