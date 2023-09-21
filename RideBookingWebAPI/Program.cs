using RideBooking.Infrastructure.GateWay.ApiAgents.Base;
using RideBooking.Infrastructure.GateWay.ApiAgents.IpLocation;
using RideBooking.Infrastructure.GateWay.ApiAgents.Listing;
using RideBooking.Infrastructure.GateWay.ClientAgent.Web;
using RideBooking.Infrastructure.GateWay.Config;
using RideBooking.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IHttpService, HttpService>()
                .AddSingleton<ApiConfig>()
                .AddScoped<IBookingApiAgent, BookingApiAgent>()
                .AddScoped<IBookingService, BookingService>()
                .AddScoped<ILocationService, LocationService>()
                .AddScoped<ILocationApiAgent, LocationApiAgent>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
