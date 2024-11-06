using Microsoft.EntityFrameworkCore;
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;
using YMYP_ASSESSMENT_1.Models.Services;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();//Interfacesiz ekliyorum ��nk� unittest yazm�yaca��m.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
