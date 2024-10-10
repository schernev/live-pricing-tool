using Server.Data;
using Server.Data.Model;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:8888");

var services = builder.Services;

ConfigureServices(services);

services.AddControllers();

var app = builder.Build();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDataContext, DataContext>();
    services.AddTransient<IDataAccessService, DataAccessService>();
    services.AddTransient<IPriceTickerService, PriceTickerService>();
}