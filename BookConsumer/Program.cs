using BookConsumer.Data;
using BookConsumer.Repositories;
using BookConsumer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddHostedService<BookSubscriber>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt => opt.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
