using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using ODataSamples.Infrastructure;
using ODataSamples.Infrastructure.ODataMappings;

namespace ODataSamples
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddControllers();

            // 1. OData - Add o Data service
            services.AddOData();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // 2. OData - Enable Dependency Injection on current routes
                // endpoints.EnableDependencyInjection();

                // 3. OData - Enable operations for all entities
                // endpoints.Select().Filter().OrderBy().Expand().MaxTop(100);

                //endpoints.EnableDependencyInjection(builder =>
                //{
                //    var modelConfig = ODataMappings.GetEdmModel(app.ApplicationServices);
                //    builder.AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(IEdmModel), sp => modelConfig)
                //    .AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new StringAsEnumResolver())
                //    .AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new UnqualifiedCallAndEnumPrefixFreeResolver { EnableCaseInsensitive = true });
                //});

                endpoints.EnableDependencyInjection(builder =>
                {
                    builder.AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(IEdmModel), sp => EdmDtoConfig.GetEdmModel(app.ApplicationServices))
                    .AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new StringAsEnumResolver())
                    .AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new UnqualifiedCallAndEnumPrefixFreeResolver { EnableCaseInsensitive = true });
                });
            });
        }
    }
}
