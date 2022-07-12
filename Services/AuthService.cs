using CustomExceptions;
using Models;
using DataAccess;

namespace Services;

public class AuthService
{
    private readonly IUserRepoDA _userRepo;

    public AuthService(IUserRepoDA repository)
    {
        _userRepo = repository;
    }
}