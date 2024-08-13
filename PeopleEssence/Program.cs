using Microsoft.EntityFrameworkCore;
using PeopleEssence.BusinessLayer.Interface;
using PeopleEssence.DataContext.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<PeopleEssenceDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DBConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // Enable transient error resiliency with retry options
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,           // Maximum number of retries
                maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                errorNumbersToAdd: null      // List of specific error numbers to trigger retries
            );
        });
});



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
