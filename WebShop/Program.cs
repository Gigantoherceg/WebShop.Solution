using Microsoft.EntityFrameworkCore;
using Services;
using Services.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<WebShopDbContext>(options
        => options.UseSqlite(connectionString));

builder.Services.AddScoped<IProductServices,ProductServices>();
builder.Services.AddScoped<ICustomerServices,CustomerServices>();
builder.Services.AddScoped<IOrderServices,OrderServices>();
builder.Services.AddScoped<ICartServices,CartServices>();

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

//using (var scop = app.Services.CreateScope())
//using (var context=scop.ServiceProvider.GetRequiredService<WebShopDbContext>())
//{
//    context.Database.EnsureDeleted();
//    context.Database.EnsureCreated();
//}

    app.Run();
