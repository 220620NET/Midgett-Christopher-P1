using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class AuthController
{
    private readonly AuthService _service;
    public AuthController(AuthService service)
    {
        _service = service;
    }

    public IResult Register(UserModel user)
    {
        if(user.Username == null)
        {
            return Results.BadRequest("Username cannot be null");
        }
        try
        {
            _service.Register(user);
            return Results.Created("Register", user);
        }
        catch(UsernameNotAvailableException)
        {
            return Results.Conflict("This username already exists");
        }
    }

    public IResult Login(UserModel user)
    {
        if(user.Username == null)
        {
            return Results.BadRequest("Username cannot be null");
        }
        try
        {
            return Results.Ok(_service.LogIn(user));
        }
        catch(InvalidCredentialsException)
        {
            return Results.NoContent();
        }
    }
}