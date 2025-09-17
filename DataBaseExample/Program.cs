using AutoMapper;
using DataBaseExample.Data;
using DataBaseExample.Profiles;
using DataBaseExample.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core with SQL Server
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Create MapperConfiguration
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<BookProfile>();
    cfg.AddProfile<CategoryProfile>();
    cfg.AddProfile<UserProfile>();
});

// Create IMapper instance
IMapper mapper = mapperConfig.CreateMapper();

// Register it as a singleton
builder.Services.AddSingleton(mapper);


// Add services to the container.
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<UserService>();


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
