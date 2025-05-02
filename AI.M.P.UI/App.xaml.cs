using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AI.M.P.Infrastructure.Data;
using AI.M.P.Infrastructure.Repositories;
using AI.M.P.Application.UseCases;
using AI.M.P.Application.Interfaces;
using AI.M.P.UI.ViewModels;

namespace AI.M.P.UI
{
    public partial class App : System.Windows.Application

    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(opts =>
                        opts.UseSqlite("Data Source=app.db"));

                    services.AddScoped<IAccountRepository, AccountRepository>();
                    services.AddScoped<RegisterAccountUseCase>();

                    services.AddTransient<MainWindow>();
                    services.AddTransient<MainWindowViewModel>();
                })
                .Build();
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            using var scope = _host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.EnsureCreatedAsync();

            var main = _host.Services.GetRequiredService<MainWindow>();
            main.DataContext = _host.Services.GetRequiredService<MainWindowViewModel>();
            main.Show();
        }
    }
}
