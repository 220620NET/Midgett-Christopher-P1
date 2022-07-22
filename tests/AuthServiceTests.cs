using Moq;
using Models;
using CustomExceptions;
using Services;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Tests;

public class AuthServiceTest
{
    [Fact]
    public void TestDuplicateUsername()
    {
        
        var mockrepo = new Mock<IUserRepoDA>();
        
        UserModel userToAdd = new UserModel
        {
            Username = "Name",
            Password = "password"
        };

        UserModel userToReturn = new UserModel
        {
            Username = "Name",
            Password = "password"
        };

        mockrepo.Setup(repo => repo.GetUserByUsername(userToAdd.Username)).Returns(userToReturn);

        AuthService service = new AuthService(mockrepo.Object);

        Assert.Throws<UsernameNotAvailable>(() => service.Register(userToAdd));

        mckrepo.Verify(repo => repo.GetUserByUsername(userToAdd.Username), Times.Once());

    }

    [Fact]
    public void TestUsernameDoesntExist()
    {

        var mockrepo = new Mock<UserModel>(); 
        
        UserModel userToAdd = new UserModel
        {
            Username = "Name123",
            password = "passw0rd!",
        };

        UserModel userToReturn = new UserModel
        {
            Username = "Name12345",
            password = "passw0rd!",
        };

        mockrepo.Setup(repo => repo.GetUserByUsername(userToAdd.Username)).Throws<ResourceNotFound>();;

        AuthService service = new AuthService(mockrepo.Object);
       
        Assert.Throws<ResourceNotFound>(() => service.LogIn(userToAdd.Username, userToAdd.password));
        
        mockrepo.Verify(repo => repo.GetUserByUsername(userToAdd.Username), Times.Once());
    }

    [Fact]
    public void TestPasswordIncorrect()
    {
        var mockrepo = new Mock<UserModel>(); 

        UserModel userToAdd = new UserModel
        {
            Username = "Name123",
            password = "passw0rd!",
        };

        UserModel userToReturn = new UserModel
        {
            Username = "Name123",
            password = "p@ssw0rd!",
        };

        mockrepo.Setup(repo => repo.GetUserByUsername(userToAdd.Username)).Returns(userToReturn);//maybe throws here

        AuthService service = new AuthService(mockrepo.Object);
       
        Assert.Throws<InvalidCredentials>(() => service.Login(userToAdd.Username, userToAdd.password));
        
        mockrepo.Verify(repo => repo.GetUserByUsername(userToAdd.Username), Times.Once());
    } 
}