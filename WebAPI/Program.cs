using System.Text;
using System.Text.Json.Serialization;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IUserService,UserManager>();

builder.Services.AddScoped<IManagementDal,ManagementDal>();
builder.Services.AddScoped<IManagementService, ManagementManager>();

builder.Services.AddScoped<IAdminService, AdminManager>();


string securityKey = "thisIsA64CharactersLongSecretKeyForHmacShdfgsdfgsdgasdfazsdfasdfasdfgasdfvbasdvzsxdgfvqsf2q34r1234rwertfaxfgbaa512Signature12345";
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = "www.tmCarbon.app",
        ValidAudience = "www.tmCarbon.app",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = symmetricSecurityKey
    };
});

Log.Logger = new LoggerConfiguration().WriteTo.File("apiLog").CreateLogger();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//    options.JsonSerializerOptions.WriteIndented = true;
//});

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