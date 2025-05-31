using Microsoft.EntityFrameworkCore;
using SqlLibrary;
using RestaurantManagement.DataService.Implementation;
using RestaurantManagement.DataService.Interface;
using FluentValidation.AspNetCore;
using FluentValidation;
using RestaurantManagement.Validations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;
using RestaurantManagement.BusinessService.Interface;
using RestaurantManagement.BusinessService.Implementation;
using RestaurantManagement.Data.Context;
using RestaurantManagement.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthenticatonDataService, AuthenticationDataService>();
builder.Services.AddScoped<IBookTableDataService, BookTableDataService>();
builder.Services.AddScoped<IOrderFoodDataService, OrderFoodDataService>();
builder.Services.AddScoped<IGenerateBillDataService, GenerateBillDataService>();
builder.Services.AddScoped<IInventoryManagementDataService, InventoryManagementDataService>();
builder.Services.AddScoped<IAdminManagementDataService, AdminManagementDataServices>();
builder.Services.AddScoped<IAdminManagementService, AdminManagementService>(); 
builder.Services.AddScoped<IGenerateBillService, GenerateBillService>(); 
builder.Services.AddScoped<IOrderFoodService, OrderFoodService>(); 
builder.Services.AddScoped<IInventoryManagementService, InventoryManagementService>(); 
builder.Services.AddScoped<IBookTableService, BookTableService>(); 
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>(); 

builder.Services.AddDbContext<RestaurentManagementContext>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services.AddSingleton(builder.Configuration.GetConnectionString("defaultConnection"));

builder.Services.AddDbContext<RestaurentManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserRegisterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddMenuValidator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Token", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

InitializeDatabase initializeDatabase = new InitializeDatabase(builder.Configuration.GetConnectionString("defaultConnection"));
await initializeDatabase.InitializeAsync();
app.Run();