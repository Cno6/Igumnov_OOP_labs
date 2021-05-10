using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using ParksWifi.ApplicationServices.GetWifiHotspotListUseCase;
using ParksWifi.ApplicationServices.Ports.Gateways.Database;
using ParksWifi.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using ParksWifi.ApplicationServices.Repositories;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using ParksWifi.WebService.InfrastructureServices.Gateways;
using ParksWifi.WebService.Scheduler;

namespace ParksWifi.WebService 
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
            services.AddDbContext<WifiHotspotContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "WifiHotspot.db")}")
            );
            services.AddHostedService<ScheduleTask>();
            services.AddScoped<IWifiHotspotDatabaseGateway, WifiHotspotEFSqliteGateway>();

            services.AddScoped<DbWifiHotspotRepository>();
            services.AddScoped<IReadOnlyWifiHotspotRepository>(x => x.GetRequiredService<DbWifiHotspotRepository>());
            services.AddScoped<IWifiHotspotRepository>(x => x.GetRequiredService<DbWifiHotspotRepository>());

            services.AddScoped<IGetWifiHotspotListUseCase, GetWifiHotspotListUseCase>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
