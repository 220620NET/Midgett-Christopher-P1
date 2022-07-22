using Models;
using Services;
using DataAccess;
using CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

//data access
builder.Services.AddSingleton<DBConnection>(ctx => DBConnection.GetInstance(builder.Configuration.GetConnectionString("EBS")));
builder.Services.AddScoped<IUserRepoDA, UserRepoDA>();
builder.Services.AddScoped<ITicketRepoDA, TicketRepoDA>();


//services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TicketService>();

//controllers
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<TicketController>();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.MapGet("/", () => "Hello World!\nYou're doing fine!");
app.MapGet("/greet/{name}", (string name) => {return $"Hi {name}";});

//---------Authorization stuff
app.MapPost("/auth/register", (UserModel user, AuthController controller) =>  controller.Register(user));
app.MapPost("/auth/login",  (UserModel user, AuthController controller) =>  controller.Login(user));


//----------------------user stuff
/// <summary>
/// gets a specific user by their user id
/// </summary>
/// <param name="userid">integer representation of users unique id</param>
/// <returns></returns>
app.MapGet("/users/getid{userid}", (int userid,UserController controller) => controller.GetUserByID(userid));

/// <summary>
/// gets a specific user by their username
/// </summary>
/// <param name="username"></param>
/// <returns></returns>
app.MapGet("/users/getusername{username}", (string username, UserController controller) => controller.GetUserByUsername(username));
app.MapGet("/users", (UserController controller) => controller.GetAllUsers());


//-----------------ticket stuff
app.MapPost("/tickets/submit", (TicketModel ticket, TicketController controller) => controller.CreateTicket(ticket));
app.MapPost("/tickets/update", (TicketModel ticket, TicketController controller) => controller.UpdateTicket(ticket));

/// <summary>
/// gets a ticket by its ID
/// </summary>
/// <param name="ID"></param>
/// <returns></returns>
app.MapGet("/tickets/getid{ID}", (int ID, TicketController controller) => controller.TicketByID(ID));
app.MapGet("/tickets/getauthor{Author}", (string Author, TicketController controller) => controller.TicketByAuthor(Author));
app.MapGet("/tickets/getstatus{Status}", (string Status, TicketController controller) => controller.TicketByStatus(Status));


app.Run();
