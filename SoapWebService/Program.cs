using SoapWebService.Middlewares;
using SoapCore;
using SoapWebService.ServiceContracts;
using CoreUtilitiesLib.Services;
using CoreUtilitiesLib.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql
    (builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ISoapService, SoapService>();
builder.Services.AddSingleton<IAuthenticationService, BasicAuthenticationService>();

var app = builder.Build();

app.UseRouting();

app.UseMiddleware<AuthMiddleware>();

app.UseEndpoints(endpoints =>
{
  endpoints.UseSoapEndpoint<ISoapService>("/sayhello.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();
