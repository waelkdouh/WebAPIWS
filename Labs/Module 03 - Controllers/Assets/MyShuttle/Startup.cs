using Microsoft.AspNetCore.Builder;
using MyShuttle.Web.AppBuilderExtensions;
using MyShuttle.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyShuttle.Model;
using Microsoft.AspNetCore.Identity;

namespace MyShuttle.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: true)
                .SetBasePath(env.ContentRootPath)
                .Build();

            Configuration = config;
        }
        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataContext(Configuration);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MyShuttleContext>()
                .AddDefaultTokenProviders();

            services.ConfigureDependencies();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureRoutes();
            MyShuttleDataInitializer.InitializeDatabaseAsync(app.ApplicationServices).Wait();
        }
    }
}
