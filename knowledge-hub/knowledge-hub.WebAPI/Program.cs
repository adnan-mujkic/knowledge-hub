using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Stripe;
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
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICRUDService<PaymentInfoResponse, AddPaymentInfo, AddPaymentInfo>, knowledge_hub.WebAPI.Services.CardService>();
builder.Services.AddScoped<ICRUDService<CityResponse, CityInsertRequest, CityInsertRequest>, CityService>();
builder.Services.AddScoped<IReviewService, knowledge_hub.WebAPI.Services.ReviewService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<IOrderService, knowledge_hub.WebAPI.Services.OrderService>();
builder.Services.AddScoped<ICRUDService<CategoryResponse, CategoryInsertRequest, CategoryInsertRequest>, CategoryService>();
builder.Services.AddScoped<ICRUDService<LanguageResponse, LanguageInsertRequest, LanguageInsertRequest>, LanguageService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();


builder.Services.AddAuthentication("AuthService")
              .AddScheme<AuthenticationSchemeOptions, AuthService>("AuthService", null);
builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role));
});

StripeConfiguration.ApiKey = "sk_test_51LDPJEJa87uOA78Aa5nA9zW3NmWxlSImbu3sR7MxH6NksDwGGqFHcrNUs8tVLxxZgURUviHWaSLmv79gul4gyJw8007rQAOjqB";

var app = builder.Build();

app.UseStaticFiles();


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

using (var scope = app.Services.CreateScope())
{
   var dbcontext = scope.ServiceProvider.GetRequiredService<databaseContext>();
   dbcontext.Database.EnsureCreated();
}

app.Run();
