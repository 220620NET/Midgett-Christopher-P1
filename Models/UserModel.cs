using CustomExceptions;

namespace Models;
public class UserModel 
{
    public int UserId{get;set;}
    public string Username
    {
        get;
        set;
    }
    public string Password{get;set;}
    public string Role{get;set;}

    public UserModel()
    {
        UserId = 0;
        Username = " ";
        Password = " ";
        Role = " ";
    }

    public UserModel(int Id, string name,string pass, string userRole)
    {
        this.UserId = Id;
        this.Username = name;
        this.Password = pass;
        this.Role = userRole;
    }

    public UserModel(string name,string pass, string userRole)
    {
        this.UserId = 0;
        this.Username = name;
        this.Password = pass;
        this.Role = userRole;
    }

    public override string ToString()
    {
        //return base.ToString();
        return "UserID: " + this.UserId + ", Username: " + this.Username + ", Password: " 
            + this.Password + ", Role: " + this.Role;
    }
}
