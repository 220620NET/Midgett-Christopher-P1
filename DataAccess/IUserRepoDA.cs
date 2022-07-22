using Models;

namespace DataAccess;

public interface IUserRepoDA
{
    UserModel GetUserByID(int? userID);
    UserModel GetUserByUsername(string Username);
    UserModel CreateUser(UserModel newUser);
    List<UserModel> GetAllUsers();
    void DeleteOneUser(int userID);
}