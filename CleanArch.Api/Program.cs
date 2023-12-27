using MyProject.Application.IServices;
using MyProject.Application.Services;
using MyProject.Infrastructure;
using log4net.Config;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using MyProject.Domain.Entities;
using Microsoft.OData.Edm;
using MyProject.Application.Interfaces;
using MyProject.Infrastructure.Repository;
using FluentValidation;
using MyProject.Application.DTO.User;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

/*var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Contact>("Contacts");*/
/*uilder.Services.AddControllers()
.AddOData(options =>
    options.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100)
    .AddRouteComponents("odata", GetEdmModel()));
*/
builder.Services.AddDbContext<MyProject.Infrastructure.Data.AppDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
    });
//Configure Log4net.
//XmlConfigurator.Configure(new FileInfo("log4net.config"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPermissionGroupService, PermissionGroupService>();
builder.Services.AddScoped<IUserGroupService, UserGroupService>();

//Injecting services.
builder.Services.RegisterServices();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Description = "api key.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                },
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

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
/*static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
    modelBuilder.EntitySet<User>("UserOData");
    return modelBuilder.GetEdmModel();
}*/