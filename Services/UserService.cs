using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class UserService
{
    private readonly IUserRepoDA _userRepo;

    public UserService(IUserRepoDA repo)
    {
        _userRepo = repo;
    }

    public UserModel GetUserByID(int? userID)
    {
        return _userRepo.GetUserByID(userID);
    }

    public UserModel GetUserByUsername(string? username)
    {
        return _userRepo.GetUserByUsername(username);
    }

    public List<UserModel> GetAllUsers()
    {
        return _userRepo.GetAllUsers();
    }
}