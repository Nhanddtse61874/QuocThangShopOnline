using LogicHandler.RepositoryInterface;
using MediatorHandler.RepositoryInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QuocThangDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DbContext, QuocThangDbContext>();
var assembly = Assembly.Load("LogicHandler");
builder.Services.AddMediatR(assembly);

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
