using RideBooking.Infrastructure.GateWay.ApiAgents.IpLocation;
using RideBooking.Infrastructure.GateWay.ApiAgents.Listing;
using RideBooking.Infrastructure.GateWay.ClientAgent.Web;
using RideBooking.Infrastructure.GateWay.Config;
using RideBooking.Service.Services;
using RideBookingWebAPI.App_Start;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataProtection();
// Add services to the container.
builder.Services.AddSingleton<ApiConfig>()
                //   .AddScoped<IHttpService, HttpService>()
                .AddScoped<IBookingApiAgent, BookingApiAgent>()
                .AddScoped<IBookingService, BookingService>()
                .AddScoped<ILocationService, LocationService>()
                .AddScoped<ILocationApiAgent, LocationApiAgent>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IHttpService, HttpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGlobalErrorHandlingMiddleware();

app.MapControllers();

app.Run();
