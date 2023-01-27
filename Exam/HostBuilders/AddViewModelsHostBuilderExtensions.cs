using Exam.ViewModels;
using Exam.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Exam.HostBuilders
{
    internal static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder) 
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<NotFoundViewModel>();
                services.AddTransient<FirstViewModel>();

                services.AddSingleton<ViewModelBase.CreateViewModel<NotFoundViewModel>>(s => () => s.GetRequiredService<NotFoundViewModel>());
                services.AddSingleton<ViewModelBase.CreateViewModel<FirstViewModel>>(s => () => s.GetRequiredService<FirstViewModel>());

                services.AddSingleton<ViewModelFactory>();
            });
            return hostBuilder;
        }
    }
}
