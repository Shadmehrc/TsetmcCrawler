using Application.Services.Service;
using Application.Services.ServiceInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICrawlerService, CrawlerService>();
builder.Services.AddScoped<ISignalRHub, SignalRHub>();
builder.Services.AddSignalR();


builder.Services.AddScoped<CrawlerService>();

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
