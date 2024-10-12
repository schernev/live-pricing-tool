using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Server.Data;
using Server.Data.Model;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8888");

ConfigureServices(builder.Services);


var app = builder.Build();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets(webSocketOptions);

app.MapControllers();

app.UseCors("AllowAll");

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDataContext, DataContext>();
    services.AddTransient<IDataAccessService, DataAccessService>();
    services.AddTransient<IPriceTickerService, PriceTickerService>();

    services.AddControllers();

    var keyConfigValue = builder.Configuration["AppSettings:JWTSecret"];
    var key = Encoding.ASCII.GetBytes(keyConfigValue!);
    services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });
}