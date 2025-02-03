using Microsoft.EntityFrameworkCore;
using RecordShop.Repository;
using RecordShop.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

//if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddDbContext<RecordShopDbContext>(options =>
//                            options.UseInMemoryDatabase(databaseName: "RecordShopDB"));
//}
//else if (builder.Environment.IsProduction())
//{
//var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = "Server=.\\SQLEXPRESS;Database=RecordShopDB;User Id=sa;Password=Password@123;Trust Server Certificate=True";
    builder.Services.AddDbContext<RecordShopDbContext>(options =>
                           options.UseSqlServer(connectionString));



builder.Services.AddControllers();
builder.Services.AddScoped<IAlbumsRepository, AlbumsRepository>();
builder.Services.AddScoped<IAlbumsService, AlbumsService>();
builder.Services.AddScoped<IArtistsRepository, ArtistsRepository>();
builder.Services.AddScoped<IArtistsService, ArtistsService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//    // Ensures the in-memory database is initialized
//    using (var scope = app.Services.CreateScope())
//    {
//        var dbContext = scope.ServiceProvider.GetRequiredService<RecordShopDbContext>();
//        dbContext.Database.EnsureCreated();
//    }
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Logger.LogInformation("Logger*****: started");

app.Run();
