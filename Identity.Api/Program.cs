using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdentityContext;
using IdentityContext.Data;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                   .MigrateDbContext<PersistedGrantDbContext>((_, __) => { })
                .MigrateDbContext<IdentityDBContext>((context, services) =>
                {
                    var env = services.GetService<IHostingEnvironment>();
                    var logger = services.GetService<ILogger<IdentityDbContextSeed>>();
                    var settings = services.GetService<IOptions<AppSettings>>();

                    new IdentityDbContextSeed()
                        .SeedAsync(context, env, logger, settings)
                        .Wait();
                })
                .MigrateDbContext<ConfigurationDbContext>((context, services) =>
                {
                    var configuration = services.GetService<IConfiguration>();

                    //new ConfigurationDbContextSeed()
                    //    .SeedAsync(context, configuration)
                    //    .Wait();
                }).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
