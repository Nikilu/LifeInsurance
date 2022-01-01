using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PremiumCalculationMicroservice.Common;
using PremiumCalculationMicroservice.Interface;
using PremiumCalculationMicroservice.Service;
using System;

namespace PremiumCalculationMicroservice
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
            services.AddControllers(); 
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpClient(Constants.API_ENDPOINT, client =>
            {
                client.BaseAddress = new Uri(Configuration["GatewayApiEndpoint"]);
            });
            services.AddTransient<IPremiumCalculationService, PremiumCalculationService>();
            services.AddTransient<IOccupationService, OccupationService>(); 
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
            });
        }
    }
}
