using Application.Services.Service;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TsetmcCrawler.Configuration.DependecyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Dependency Injection
builder.Services.AddApplicationServices();
//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials() // Needed for WebSockets
              .SetIsOriginAllowed(origin => true); // Allow all origins (change for production)
    });
});

//Add In memory DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("MyInMemoryDb"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add SignalR Hub
app.MapHub<SignalRHub>("/SignalRHub");


//Todo take it to another folder for BackGroundTasks
//using (var scope = app.Services.CreateScope()) // ایجاد یک Scope جدید
//{
//    var crawlerService = scope.ServiceProvider.GetRequiredService<CrawlerService>();
//    Task.Run(() => crawlerService.Start());
//}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
