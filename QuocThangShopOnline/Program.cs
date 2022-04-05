using DataAccessLayer.RepositoryInterface;
using IdentityInfra.Database;
using IdentityInfra.Identity;
using LogicHandler.Identity;
using LogicHandler.RepositoryInterface;
using MediatorHandler.RepositoryInterface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Identity;
using Persistence.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QuocThangDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<IdentityClientContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DbContext, QuocThangDbContext>();

builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IClientApplicationUserService, ClientApplicationUserService>();
builder.Services.AddScoped<IClientApplicationRoleService, ClientApplicationRoleService>();
builder.Services.AddScoped<DbContext, IdentityClientContext>();
var assembly = Assembly.Load("LogicHandler");

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
               .AddCookie(IdentityConstants.ApplicationScheme, options =>
               {
                   options.SlidingExpiration = true;
                   options.LoginPath = "/admin/account/login";
                   options.LogoutPath = "/admin/account/login";
                   options.AccessDeniedPath = "/admin/account/login";
               })
               .AddCookie(IdentityConstants.TwoFactorUserIdScheme, options =>
               {
                   options.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
               })
               .AddExternalCookie();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatR(assembly);


IdentityBuilder clientBuilder = builder.Services.AddIdentityCore<ClientApplicationUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
});
clientBuilder.AddRoles<ClientApplicationRole>()
    .AddSignInManager<SignInManager<ClientApplicationUser>>()
    .AddEntityFrameworkStores<IdentityClientContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}");

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Category}/{action=Index}");

app.Run();
