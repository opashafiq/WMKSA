using Application.Abstractions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application;
using Infrastructure;
using MediatR;
using FLS.GLS.API;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Application.Operations.Person.Commands;
using Domain.Entities;
using Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Infrastructure.Data.ApplicationDBContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("ApplicationDBContextConnection"))
                    );

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IBranchMasterRepository, BranchMasterRepository>();
builder.Services.AddScoped<IBranchMasterRepository, BranchMasterRepository>();
builder.Services.AddScoped<ICustomerMasterRepository, CustomerMasterRepository>();
builder.Services.AddScoped<ISubCustomerMasterRepository, SubCustomerMasterRepository>();
builder.Services.AddScoped<IVendorMasterRepository, VendorMasterRepository>();
builder.Services.AddScoped<ITransporterMasterRepository, TransporterMasterRepository>();
builder.Services.AddScoped<ITruckMasterRepository, TruckMasterRepository>();
builder.Services.AddScoped<IDriverMasterRepository, DriverMasterRepository>();
builder.Services.AddScoped<IPackageMasterRepository, PackageMasterRepository>();
builder.Services.AddScoped<IUnitMasterRepository, UnitMasterRepository>();
builder.Services.AddScoped<IRecItemMasterRepository, RecItemMasterRepository>();
builder.Services.AddScoped<IItemServiceRepository, ItemServiceRepository>();
builder.Services.AddScoped<IItemsRateMasterRepository, ItemsRateMasterRepository>();
builder.Services.AddScoped<IItemsRateMasterDetailsRepository, ItemsRateMasterDetailsRepository>();
builder.Services.AddScoped<IJobOrderRepository, JobOrderRepository>();
builder.Services.AddScoped<IReceiveItemsNewRepository, ReceiveItemsNewRepository>();
builder.Services.AddScoped<IReceiveItemsNewDetailRepository, ReceiveItemsNewDetailRepository>();
builder.Services.AddScoped<IReceiveItemsNewReleaseRepository, ReceiveItemsNewReleaseRepository>();
builder.Services.AddScoped<IReceiveItemsNewReleaseDetailRepository, ReceiveItemsNewReleaseDetailRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IErrorHandlingService, ErrorHandlingService>();
builder.Services.AddScoped<IItemManagementService, ItemManagementService>();
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<IReceiveItemsNewReleaseInvoiceRepository, ReceiveItemsNewReleaseInvoiceRepository>();
builder.Services.AddScoped<IReceiveItemsNewReleaseInvoiceChargeRepository, ReceiveItemsNewReleaseInvoiceChargeRepository>();
builder.Services.AddScoped<IReceiveItemsNewReleaseRecepitRepository, ReceiveItemsNewReleaseRecepitRepository>();


object value = builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddMediatR(typeof(CreatePerson));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Identity Service
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();
/////////////
///
/// 
/// 
///

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:7034") // The URL of your frontend application
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()); // Allow credentials
});


//// JWT Token Generation Symmetric Key and Services
//var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-signing-key this-is-signing-key this-is-signing-key")); // This should be the key given during token creation
//var tokenValidationParameter = new TokenValidationParameters()
//{
//    IssuerSigningKey = signingKey,
//    ValidateIssuer = false,
//    ValidateAudience = false
//};

//// Validate the incoming JWT here
//builder.Services.AddAuthentication
//    (x => x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
//        .AddJwtBearer(jwt =>
//        {
//            jwt.TokenValidationParameters = tokenValidationParameter;
//        }
//        );


//////////////////////////////////////////////////
///

//// For putting bearer token through swagger

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


//////////////////////////////////////////////


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

/**********************************************/
var startup = new Startup(builder.Configuration); // My custom startup class.
startup.Configure(app, app.Environment,app.Services); // Configure the HTTP request pipeline.

////////////////////////////////////////////////////////////

app.Run();



