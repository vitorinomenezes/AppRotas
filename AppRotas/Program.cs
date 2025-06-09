// CheapestRouteApi.Api/Program.cs
using Application;
using Application.MappingProfiles;
using Application.Services;
using Domain.Abstractions;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rotas de Viagem"
                                        ,
        Version = "v1"
                                        ,
        Description = ".\r\n<h1><b>Teste Técnico - João Vitorino Menezes Neto</b></h1>"
                                        ,
        Contact = new OpenApiContact
        {
            Name = "Vitorino - vitorino_menezes@outlook.com",
            Email = "vitorino_menezes@outlook.com"
        }
                                        ,
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }

    });

    c.ResolveConflictingActions(apiDescription => apiDescription.FirstOrDefault());

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    #region Swagger Authorization
    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description =
    //        "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
    //        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
    //        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer",
    //    BearerFormat = "JWT",
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //            {
    //                {
    //                    new OpenApiSecurityScheme
    //                    {
    //                        Reference = new OpenApiReference
    //                        {
    //                            Type = ReferenceType.SecurityScheme,
    //                            Id = "Bearer"
    //                        }
    //                    },
    //                    Array.Empty<string>()
    //                }
    //            });
    #endregion
});

// Configure SQL Server connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.ApplyIoC();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rotas API V1");
        c.RoutePrefix = string.Empty; // Serve the Swagger UI at the app's root (/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Apply migrations on startup (for development purposes, consider alternatives for production)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.Run();