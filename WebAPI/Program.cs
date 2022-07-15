var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!\nYou're doing fine!");
app.MapGet("/greet/{name}", (string name) => {return $"Hi {name}";});

app.Run();
