using CentralLibrary.Mapper;
using CentralLibrary.Repository;
using CentralLibrary.Repository.Base;
using CentralLibrary.Service;
using CentralLibrary.Service.Base;
using CentralLibrary.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("LibraryDbContext");

Console.WriteLine(connectionString);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 2, 0)),
        options => options.EnableRetryOnFailure(
            maxRetryCount: 0,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    ));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
