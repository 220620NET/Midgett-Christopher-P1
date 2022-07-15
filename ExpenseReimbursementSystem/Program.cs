using Models;
using Services;
using DataAccess;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


UserRepoDA userRepoDA = new UserRepoDA();

UserModel newUser = new UserModel("paul", "sddfb", "employee");

userRepoDA.CreateUser(newUser);

List<UserModel> users = userRepoDA.GetAllUsers();

Console.WriteLine($"Number of Users: {users.Count()}");
foreach(UserModel user in users)
{
    Console.WriteLine(user);
}

UserModel users2 = userRepoDA.GetUserByUsername("paul");

Console.WriteLine("Got user by username:");
Console.WriteLine(users2);


UserModel users3 = userRepoDA.GetUserByID("2");

Console.WriteLine("Got user by ID:");
Console.WriteLine(users3);






/*
bool running = true;

do
{
    Console.WriteLine("Welcome to Expense Reimbursement System");
    Console.WriteLine("Do a thing");
    Console.WriteLine("[1]User testing stuff\n[2]Ticket testing stuff\n[0]Exit");

    string? input = Console.ReadLine();

    switch(input)
    {
        case "1":
            //user commands
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Create User\n[2] Get all users\n[3] Get user by ID\n"
                +"[4] Get user by username\n[5] Delete User\n[6] Exit");
            
            string input2 = Console.ReadLine();
            switch(input2)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default:
                    break;
            }
            break;
        case "2":
            //ticket commands
            break;
        case "0":
            running = false;
            break;
        default:
        Console.WriteLine("Invalid Input");
        break;
    }
}while(running);
*/