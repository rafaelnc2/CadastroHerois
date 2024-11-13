using CadastroHerois.Api.Endpoints;
using CadastroHerois.Api.Extensions;
using CadastroHerois.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddServices(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalErrorHandler>();

var app = builder.Build();

app.UseExceptionHandler(opt => { });

app.MapHerosEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();