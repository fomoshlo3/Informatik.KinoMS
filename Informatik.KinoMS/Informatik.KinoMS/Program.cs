using Informatik.KinoMS.Client.Pages;
using Informatik.KinoMS.Components;
using Informatik.KinoMS.Data.DbContexts;
using Informatik.KinoMS.Data.Entities;
using Informatik.KinoMS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Informatik.KinoMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Add services to the container.
            //services.AddSwaggerGen();
            services.AddScoped<IHallManagement, HallManagement>()
                    .AddScoped<IMovieManagement, MovieManagement>();

            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();


            //DbConnection
            services.AddDbContextFactory<CinemaDbContext>(options => 
                options.UseLazyLoadingProxies()
                       .UseSqlServer(builder.Configuration.GetConnectionString("Default")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();

                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();

                    db.Database.Migrate();
                }
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();


            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Counter).Assembly);

            //app.MapSwagger();

            app.Run();
        }
    }
}
