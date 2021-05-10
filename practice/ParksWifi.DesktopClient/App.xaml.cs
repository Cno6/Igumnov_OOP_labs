using Microsoft.Extensions.DependencyInjection;
using ParksWifi.ApplicationServices.GetWifiHotspotListUseCase;
using ParksWifi.ApplicationServices.Ports.Cache;
using ParksWifi.ApplicationServices.Repositories;
using ParksWifi.DesktopClient.InfrastructureServices.ViewModels;
using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using ParksWifi.InfrastructureServices.Cache;
using ParksWifi.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ParksWifi.DesktopClient 
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<WifiHotspot>, DomainObjectsMemoryCache<WifiHotspot>>();
            services.AddSingleton<NetworkWifiHotspotRepository>(
                x => new NetworkWifiHotspotRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<WifiHotspot>>())
            );
            services.AddSingleton<CachedReadOnlyWifiHotspotRepository>(
                x => new CachedReadOnlyWifiHotspotRepository(
                    x.GetRequiredService<NetworkWifiHotspotRepository>(),
                    x.GetRequiredService<IDomainObjectsCache<WifiHotspot>>()
                )
            );
            services.AddSingleton<IReadOnlyWifiHotspotRepository>(x => x.GetRequiredService<CachedReadOnlyWifiHotspotRepository>());
            services.AddSingleton<IGetWifiHotspotListUseCase, GetWifiHotspotListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
