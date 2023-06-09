// 1. Usigns to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args); 
//2. Conecction with database
const String CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);


//3. Add context to services of builder

builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));




// Add services to the container.

builder.Services.AddControllers();

//4. Add custom services (folder services)
builder.Services.AddScoped<IStudentsService, StudentsService>();

//TODO: Add the rest of services


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//5. CORS-Config
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();


