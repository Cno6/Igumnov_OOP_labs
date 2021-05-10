using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ParksWifi.DomainObjects.Ports
{
    public interface IReadOnlyWifiHotspotRepository
    {
        Task<WifiHotspot> GetWifiHotspot(long id);

        Task<IEnumerable<WifiHotspot>> GetAllWifiHotspot();

        Task<IEnumerable<WifiHotspot>> QueryWifiHotspot(ICriteria<WifiHotspot> criteria);

    }

    public interface IWifiHotspotRepository
    {
        Task AddWifiHotspot(WifiHotspot wifiHotspot);

        Task RemoveWifiHotspot(WifiHotspot wifiHotspot);
             
        Task UpdateWifiHotspot(WifiHotspot wifiHotspot);
        Task ParseAndPush();
    }
}
