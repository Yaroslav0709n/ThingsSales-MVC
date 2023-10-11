using ThingsSales.Data.ContextData;
using Microsoft.EntityFrameworkCore;
using ThingsSales.Web.Extension;
using ThingsSales.Service;
using AutoMapper;
using ThingsSales.Service.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"), b => b.MigrationsAssembly("ThingsSales.Web")));

builder.Services.AddIdentityService();
builder.Services.AddDataAccess();
builder.Services.AddApplicationService();
builder.Services.AddSession();
builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Register}/{id?}");

app.Run();
