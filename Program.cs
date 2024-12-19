using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TicketingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurarea DbContext pentru SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=isticketing.db"));

// Adaugă serviciile MVC
builder.Services.AddControllers();

// Configurare Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Adaugă Swagger în pipeline-ul aplicației
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketingAPI v1");
        c.RoutePrefix = string.Empty; // Swagger UI va fi disponibil direct la root-ul aplicației
    });
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Pornirea aplicației
app.Run();