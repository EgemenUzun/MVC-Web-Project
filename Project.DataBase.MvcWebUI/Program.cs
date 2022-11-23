using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.DataBase.Business.Abstract;
using Project.DataBase.Business.Concrete;
using Project.DataBase.DataAccess.Abstract;
using Project.DataBase.DataAccess.Concrete.EntityFramework;
using Project.DataBase.MvcWebUI.Entities;
using Project.DataBase.MvcWebUI.Middlewares;
using Project.DataBase.MvcWebUI.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddMvc(options => options.EnableEndpointRouting=false);

builder.Services.AddRazorPages();

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddSingleton<ICartSessionService, CartSessionService>();
builder.Services.AddSingleton<ICartService, CartService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseNpgsql("User Id=postgres;Password=1234;Host=localhost;Database=Northwind1;Persist Security Info=True;"));
builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.UseFileServer();
app.UseNodeModules(builder.Environment.ContentRootPath);

app.MapRazorPages();
app.UseMvc(ConfigureRoutes);

void ConfigureRoutes(IRouteBuilder routeBuilder)
{
    routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
}

app.UseRouting();


app.Run();
