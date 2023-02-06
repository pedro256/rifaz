using App.Rifas.Core.Api;
using App.Rifas.Core.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(c =>
{
    c.Filters.Add<ExceptionFilter>();
});

DependenceInjections.Config(builder.Services, builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
