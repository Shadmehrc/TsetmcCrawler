using Application.Services.Service;
using Application.Services.ServiceInterface;
using Domain.Models.Models;
using Infrastructure.DAL.RepositoryInterface;
using Infrastructure.DAL.RepositoryService;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Dependency Injection
builder.Services.AddScoped<ICrawlerService, CrawlerService>();
builder.Services.AddScoped<ITsetmcCrawlerDAL, TsetmcCrawlerDAL>();
builder.Services.AddScoped<ISignalRHub, SignalRHub>();

//Add DB Service
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<SignalRHub>("/SignalRHub");


//todo take it to another folder for BackGroundTasks
//using (var scope = app.Services.CreateScope()) // ایجاد یک Scope جدید
//{
//    var crawlerService = scope.ServiceProvider.GetRequiredService<CrawlerService>();
//    Task.Run(() => crawlerService.Start());
//}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
