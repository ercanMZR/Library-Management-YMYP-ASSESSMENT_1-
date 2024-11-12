using Microsoft.EntityFrameworkCore;
using YMYP_ASSESSMENT_1.Models.Repositories;
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
builder.Services.AddScoped<IBookService,BookService>();//Interfacesiz eklersem e�er unittest yazm�yaca��m.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));// Art�k sisteme bir entity girdi�im zaman onu repositorysini yazmama gerek yok.

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
