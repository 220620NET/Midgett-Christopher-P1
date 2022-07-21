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

    public UserModel GetUserByID()
    {
        return _userRepo.GetUserByID();
    }

    public UserModel GetUserByUsername()
    {
        return _userRepo.GetUserByUsername();
    }

    public List<UserModel> GetAllUsers()
    {
        return _userRepo.GetAllUsers();
    }
}