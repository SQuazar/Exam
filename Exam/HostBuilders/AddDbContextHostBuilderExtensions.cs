using Exam.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Exam.HostBuilders
{
    internal static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder) 
        {
            hostBuilder.ConfigureServices((ctx, services) => 
            {
                void Configure(DbContextOptionsBuilder builder)
                {
                    builder.UseSqlite("Data Source=Database.db");
                }
                services.AddDbContext<DatabaseContext>((Action<DbContextOptionsBuilder>)Configure);
                services.AddSingleton<DbContextFactory>(new DbContextFactory(Configure));
            });
            return hostBuilder;
        }
    }
}
