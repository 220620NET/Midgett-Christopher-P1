using CustomExceptions;
using Models;
using DataAccess;
using System.Text.Json;

namespace Services;

public class AuthService
{
    private readonly IUserRepoDA _userRepo;

    //dependency injection
    public AuthService(IUserRepoDA repository)
    {
        _userRepo = repository;
    }

    public async Task<UserModel> Register(UserModel newUser)
    {
        try
        {
            await _userRepo.GetUserByUsername(newUser.Username);
            throw new UsernameNotAvailableException();
        }
        catch(ResourceNotFoundExceptions)
        {
            return _userRepo.CreateUser(newUser);
        }
    }

    public async Task<UserModel> LogIn(UserModel userToFind)
    {
        try
        {
            UserModel foundUser = await _userRepo.GetUserByUsername(userToFind.Username);

            if(userToFind.Password == foundUser.Password)
            {
                return foundUser;
            }
        }
        catch(ResourceNotFoundExceptions)
        {
            throw new InvalidCredentialsException();
        }
    }
}