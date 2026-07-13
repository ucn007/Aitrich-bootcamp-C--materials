namespace Agency.interface;

public interface IUser
{
    private int _id;
    private string _name;
    private string _email;
    private string _phone;
    private string _address;
    private string _state;
    private string _country;
    private string _gender;
    
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string Email { get => _email; set => _email = value; }
    public string Phone { get => _phone; set => _phone = value; }
    public string Address { get => _address; set => _address = value; }
    public string State { get => _state; set => _state = value; }
    public string Country { get => _country; set => _country = value; }
    public string Gender { get => _gender; set => _gender = value; }
    
    
    

}