using Models;

namespace DataAccess;

public interface IUserRepoDA
{
    UserModel GetUserByID(string userID);
    UserModel GetUserByUsername(string Username);
    bool CreateUser(UserModel newUser);
    List<UserModel> GetAllUsers();
    void DeleteOneUser(int userID);
}