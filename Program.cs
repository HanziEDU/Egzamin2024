using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Egzamin2024.Interfaces;
using Egzamin2024.Services;  // Dodaj odpowiedni¹ przestrzeñ nazw dla DefaultDateProvider
using Egzamin2024.Models;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IDateProvider, DefaultDateProvider>();
        builder.Services.AddSingleton<NoteService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
