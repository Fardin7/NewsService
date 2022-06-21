using Microsoft.EntityFrameworkCore;
using NewsService.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>(
    option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

builder.Services.AddScoped<IRepository, NewsRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
