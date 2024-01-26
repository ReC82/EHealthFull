using EhealthV2.Data;
using EhealthV2.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IDoctorsController, DoctorsController>();
builder.Services.AddTransient<IClinicsController, ClinicController>();
//string MSSQL = "Server=(localdb)\\MSSQLLocalDB;Database=ehealth;Trusted_Connection=True;MultipleActiveResultSets=true";
string SQLITE = "Data Source=ehealth.db";
builder.Services.AddDbContext<DoctorsContext>(options => options.UseSqlite(SQLITE));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});


builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllerRoute(
    name: "EHealthV2",
    pattern: "{controller}/{action}/{id?}");

app.MapRazorPages();

app.Run();
