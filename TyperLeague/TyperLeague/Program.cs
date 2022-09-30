using MediatR;
using Microsoft.EntityFrameworkCore;
using TyperLeague.ApplicationServices.API.Domain;
using TyperLeague.ApplicationServices.API.Mappings;
using TyperLeague.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(BetsProfile).Assembly);

builder.Services.AddMediatR(typeof(ResponseBase<>));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddDbContext<TyperLeagueStorageContext>(
    opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TyperLeagueDatabaseConnection")));

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
