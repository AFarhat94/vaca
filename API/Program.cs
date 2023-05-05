using API.Extensions;
using Infra.Data;
using Infra.Data.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors(opts => {
    opts.AddPolicy("AngularPolicy", config => {
        config
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("Http://localhost:4200");
    });
});

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

app.UseCors("AngularPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<VacaDbContext>();
var identityContext = services.GetRequiredService<VacaIdentityDbContext>();
try
{
    //await context.Database.MigrateAsync();
    await identityContext.Database.MigrateAsync();
}
catch(Exception)
{ }

app.Run();
