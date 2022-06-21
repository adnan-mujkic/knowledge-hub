using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
   s.AddSecurityDefinition("basic", new OpenApiSecurityScheme
   {
      Name = "Authorization",
      Type = SecuritySchemeType.Http,
      Scheme = "basic",
      In = ParameterLocation.Header
   });
   s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "basic"
                              }
                          },
                          new string[] {}
                    }
                });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<databaseContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("knowledge-hub")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICRUDService<BookResponse, BookSearchRequest, BookInsertRequest, BookInsertRequest>, BookService>();
builder.Services.AddScoped<ICRUDService<PaymentInfoResponse, UserPaymentInfoRequest, AddPaymentInfo, AddPaymentInfo>, CardService>();
builder.Services.AddScoped<ICRUDService<CityResponse, CitySearchRequest, CityInsertRequest, CityInsertRequest>, CityService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();

builder.Services.AddAuthentication("AuthService")
              .AddScheme<AuthenticationSchemeOptions, AuthService>("AuthService", null);
builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role));
});
builder.WebHost.UseUrls("http://localhost:5000", "http://192.168.1.103:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
