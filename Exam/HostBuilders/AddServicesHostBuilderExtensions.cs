using Exam.Domain.Service;
using Exam.EfCore.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.HostBuilders
{
    internal static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder) 
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<IPharmacyService, PharmacyService>();
            });
            return hostBuilder;
        }
    }
}
