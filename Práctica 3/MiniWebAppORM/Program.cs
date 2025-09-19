using Microsoft.EntityFrameworkCore;
using MiniWebAppORM.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexi�n a PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar el DbContext con PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
