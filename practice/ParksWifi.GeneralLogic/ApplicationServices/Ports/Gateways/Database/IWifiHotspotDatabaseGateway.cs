using ParksWifi.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParksWifi.ApplicationServices.Ports.Gateways.Database
{
    public interface IWifiHotspotDatabaseGateway
    {
        Task AddWifiHotspot(DomainObjects.WifiHotspot wifiHotspot);

        Task RemoveWifiHotspot(DomainObjects.WifiHotspot wifiHotspot);

        Task UpdateWifiHotspot(DomainObjects.WifiHotspot wifiHotspot);

        Task<DomainObjects.WifiHotspot> GetWifiHotspot(long id);

        Task<IEnumerable<DomainObjects.WifiHotspot>> GetAllWifiHotspot();

        Task<IEnumerable<DomainObjects.WifiHotspot>> QueryWifiHotspot(Expression<Func<DomainObjects.WifiHotspot, bool>> filter);
        Task ParseAndPush();
    }
}
