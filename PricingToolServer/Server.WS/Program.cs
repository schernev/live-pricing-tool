var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:8888");

builder.Services.AddControllers();

var app = builder.Build();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.MapControllers();

app.Run();