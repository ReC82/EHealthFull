using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();

        services.AddTransient<IDoctorsController, DoctorsController>();
        services.AddTransient<ILoginController, LoginController>();
        services.AddTransient<IClinicsController, ClinicController>();

        string SQLITE = "Data Source=ehealth.db";
        services.AddDbContext<DoctorsContext>(options => options.UseSqlite(SQLITE));

        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors("AllowOrigin");

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "EHealthV2",
                pattern: "{controller}/{action}/{id?}");
            endpoints.MapRazorPages();
        });

        // Handle requests for directories
        app.Use(async (context, next) =>
        {
            if (context.Request.Path.HasValue && context.Request.Path.Value.EndsWith("/"))
            {
                context.Response.Redirect("/"); // Redirect to the root page or any custom page
                return;
            }

            await next();
        });
    }
}
