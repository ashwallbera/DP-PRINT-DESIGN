using Microsoft.EntityFrameworkCore;
using aspnetcoreAPI.Models;
using TodoApi.Models;
using aspnetcoreAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("DpPrintDesign"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "DP PRINT & DESIGN", Version = "v1" });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DP PRINT & DESIGN v1"));
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
