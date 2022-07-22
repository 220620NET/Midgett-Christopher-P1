using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }
    public UserModel GetUserByID(int? userID)
    {
        return _service.GetUserByID(userID);
    }

    public UserModel GetUserByUsername(string? username)
    {
        return _service.GetUserByUsername(username);
    }
    public List<UserModel> GetAllUsers()
    {
        return _service.GetAllUsers();
    }
}