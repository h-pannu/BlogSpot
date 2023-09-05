﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Blogger.WebAPI.Data;
using Blogger.WebAPI.DBContext;
using Blogger.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.WithOrigins("https://localhost:7231/")
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("_myAllowSpecificOrigins", builder =>
     builder.WithOrigins("https://localhost:7231/")
      .SetIsOriginAllowed((host) => true) // this for using localhost address
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});
//

//Configuring Connection String
var Conn_String = builder.Configuration.GetConnectionString("Conn_String");
builder.Services.AddDbContext<BloggerDBContext>(options => options.UseSqlServer(Conn_String));

builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<BloggerDBContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Configured Auto mappers
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                       new OpenApiInfo
                       {
                           Title = "API Title",
                           Version = "V1",
                           Description = "API Description"
                       });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "Authorization header using the Bearer scheme. Example \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    swagger.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securitySchema,Array.Empty<string>() }
    });
});

//Added JWT Authentication
builder.Services.AddAuthentication(f =>
{
    f.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    f.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(k =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    k.SaveToken = true;
    k.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ClockSkew = TimeSpan.Zero
    };

});

// Add services to the container.

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

//app.UseCors("_myAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseCors("_myAllowSpecificOrigins"); 

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



app.Run();
