
using MassTransit;
using MassTransit.Definition;
using Microsoft.EntityFrameworkCore;
using NewsService.Consumer;
using NewsService.Data;
using GreenPipes;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<AppDBContext>(
    option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<CategoryCreateConsumer>();
    configure.AddConsumer<CategoryUpdateConsumer>();
    configure.AddConsumer<CategoryDeleteConsumer>();
    configure.UsingRabbitMq((context, configurator) =>
    {
       
        configurator.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("News", false));
        configurator.UseMessageRetry(retryConfigurator =>
        {
            retryConfigurator.Interval(3, TimeSpan.FromSeconds(5));
        });
    });
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddScoped<IRepository, NewsRepository>();
builder.Services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();

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
