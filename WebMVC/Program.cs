using AutoMapper;
using Bussines.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using WebMVC.ApiServices;
using WebMVC.ApiServices.interfaces;
using WebMVC.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<AuthTokenHandler>();
builder.Services.AddHttpClient<IAuthApiService, AuthApiService>(opt =>
{
    opt.BaseAddress = new Uri("https://localhost:7194/api/");
});
 
builder.Services.AddHttpClient<IUserApiService, UserApiService>(opt =>
{
    opt.BaseAddress = new Uri("https://localhost:7194/api/");
}).AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Admin/Auth/Login";
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
    opt.Cookie.Name = "mvccookie";

});
#region AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion  



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseStatusCodePagesWithRedirects("Admin/Error/MyStatusCode?code={9}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //admin/hpöe/inde
    endpoints.MapAreaControllerRoute(
      areaName: "Admin",
      name: "areas",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
