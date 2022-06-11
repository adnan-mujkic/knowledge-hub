using knowledge_hub.WebAPI.Database;
using knowledge_hub.WebAPI.Intefraces;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.WebAPI.Model.Responses;
using knowledge_hub.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<databaseContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("knowledge-hub")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICRUDService<BookResponse, BookSearchRequest, BookInsertRequest, BookInsertRequest>, BookService>();

builder.WebHost.UseUrls("http://localhost:5000", "http://192.168.1.103:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
