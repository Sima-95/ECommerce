using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Application;
using ECommerce.Infrastructure;
using StoreakApiService.Core.Helper;
using StoreakApiService.Core.Projects;
using StoreakApiService.Core.Responses;

namespace ECommerce
{
    public class Startup : StoreakApiService.Core.Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
            : base(configuration, env)
        {
            ApiProjectSettings.ProjectId = ProjectNames.demo;
            ApiProjectSettings.UseSession = true;
            ApiProjectSettings.Databasename = "ECommerce";

            ApiProjectSettings.EnvironmentType = ProjectEnvironmentType.LocalHost;
            ApiProjectSettings.UsePostFix = false;
            ApisUrl.LoadUrls(ProjectEnvironmentType.TestProduction);
            ApiProjectSettings.UseCache = false;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // Auto Mapper Configurations
            base.ConfigureAutoMapper(services, new MapperProfile());

            // Services DI
            services.AddScoped<UnitOfWork>();

            // Responses DI
            services.AddSingleton<IResponseMessages, ResponseMessages>();

            // DBContext Intialization with connection string
            base.ConfigureDatabase<ModelContext>(services);
        }
    }
}
