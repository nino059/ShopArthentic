using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using Arthentic.Common;
using System.Configuration;
using Arthentic.Libs.Repository;
using Microsoft.Extensions.DependencyInjection;
using Arthentic.Repository.Authen;

namespace Arthentic.UnitTest
{
    public class BaseConfigService
    {
        public IOptions<AppSettings> Option;
        public readonly IConfiguration ConfigurationRoot;

        public BaseConfigService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            ConfigurationRoot = builder.Build();
            Option = Options.Create(new AppSettings
            {
                Secret = ""
            });

            IServiceCollection service = new ServiceCollection();
            service.Configure<Settings>(
               options =>
               {
                   options.ConnectionString = ConfigurationRoot.GetSection("MongoDb:ConnectionString").Value;
                   options.Database = ConfigurationRoot.GetSection("MongoDb:Database").Value;
               });

            service.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(ConfigurationRoot.GetSection("MongoDb:ConnectionString").Value));
            service.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
