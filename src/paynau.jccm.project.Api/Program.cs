using Microsoft.EntityFrameworkCore;
using paynau.jccm.project.Api.Middleware;
using paynau.jccm.project.Application;
using paynau.jccm.project.Infraestructure;
using paynau.jccm.project.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);


// Replace 'YourDbContext' with the name of your own DbContext derived class.
builder.Services.AddDbContext<PaynauDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration.GetConnectionString("ConexionMySql"), ServerVersion.Parse("8.4.2-mysql"))
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


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

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();





using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Obtener el contexto de la base de datos y el logger
        var context = services.GetRequiredService<PaynauDbContext>();
        var logger = services.GetRequiredService<ILogger<PaynauDbContextSeed>>();
        await context.Database.MigrateAsync();
        await PaynauDbContextSeed.SeedAsync(context, logger);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error durante el proceso de seeding de la base de datos.");
    }
}






app.Run();
