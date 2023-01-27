using Exam.Domain.Model;
using Exam.EfCore;
using Exam.HostBuilders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Exam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        private IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddDbContext()
                .AddServices()
                .AddStore()
                .AddViewModels()
                .AddViews();
        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            await using var ctx = _host.Services.GetRequiredService<DbContextFactory>().CreateDbContext();
            await ctx.Database.EnsureCreatedAsync();

            var window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }
    }
}
