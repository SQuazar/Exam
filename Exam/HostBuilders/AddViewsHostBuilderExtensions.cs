using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Exam.ViewModels;

namespace Exam.HostBuilders
{
    internal static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder hostBuilder) 
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });
            return hostBuilder;
        }
    }
}
