using BookStore.Models.Domain;
using BookStore.Repositories.Absract;
using BookStore.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("constr")
            ));

            builder.Services.AddScoped<IGenreService,GenreService>();

			builder.Services.AddScoped<IAutherService, AutherService>();

			builder.Services.AddScoped<IPublisherService, PublisherService>();

			builder.Services.AddScoped<IBookService, BookService>();

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
                pattern: "{controller=Genre}/{action=Add}/{id?}");

            app.Run();
        }
    }
}