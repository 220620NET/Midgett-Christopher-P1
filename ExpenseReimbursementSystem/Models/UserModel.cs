namespace Models;
public class UserModel
{
    public UserModel()
    {
        UserId = 0;
        Username = " ";
        Password = " ";
        Role = " ";
    }

    public UserModel(int Id, string name,string pass, string userRole)
    {
        UserId = Id;
        Username = name;
        Password = pass;
        Role = userRole;
    }

    public int UserId{get;set;}
    public string Username{get;set;}
    public string Password{get;set;}
    public string Role{get;set;}
}