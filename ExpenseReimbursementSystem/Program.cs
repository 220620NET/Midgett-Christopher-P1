using Models;
using Services;
using DataAccess;
using CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreareBuilder(args);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();