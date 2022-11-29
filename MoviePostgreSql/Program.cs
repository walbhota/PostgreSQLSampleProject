using Microsoft.EntityFrameworkCore;
using MoviePostgreSql.Data;
using MoviePostgreSql.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieDataContext>(o
    => o.UseNpgsql(builder.Configuration.GetConnectionString("MovieDb"), b => b.MigrationsAssembly("MoviePostgreSql"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Seed();

app.Run();
