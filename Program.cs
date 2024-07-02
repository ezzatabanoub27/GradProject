using FinalAppG.Data;
using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using FinalAppG.EXtentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<TourismContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false);
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<TourismContext>().AddDefaultTokenProviders();

builder.Services.addJWTAuth(builder.Configuration);


var app = builder.Build();




 






//builder.Services
//    .AddAuthentication(x =>
//    {
//        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(
//        JwtBearerDefaults.AuthenticationScheme,
//        token =>
//        {
//            var key = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"])
//            );
//            token.TokenValidationParameters = new TokenValidationParameters()
//            {
//                IssuerSigningKey = key,
//                ValidIssuer = builder.Configuration["JWT:Issuer"],
//                ValidAudience = builder.Configuration["JWT:Audience"],
//                ValidateIssuer = true,
//                ValidateAudience = true,
//                ValidateLifetime = true,
//                ClockSkew = TimeSpan.Zero
//            };

//            token.Events = new JwtBearerEvents
//            {
//                OnMessageReceived = context =>
//                {
//                    var accessToken = context.Request.Cookies["accessToken"];
//                    return Task.CompletedTask;
//                }
//            };
//        }
//    );


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors( c=> c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
