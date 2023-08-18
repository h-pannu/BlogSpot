using Blogger.Server.DataContext;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Configuring Connection String
var bloggerConnectionString = builder.Configuration.GetConnectionString("Blogger");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(bloggerConnectionString));
builder.Services.AddDbContext<BloggerIdentityContext>(options => options.UseSqlServer(bloggerConnectionString));

builder.Services.AddDefaultIdentity<BloggerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BloggerIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
