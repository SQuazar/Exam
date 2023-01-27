using Exam.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.HostBuilders
{
    internal static class AddStoreHostBuildersExtensions
    {
        public static IHostBuilder AddStore(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, MainNavigator>();
            });
            return hostBuilder;
        }
    }
}
