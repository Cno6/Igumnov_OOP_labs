using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParksWifi.DomainObjects.Repositories
{
    public abstract class ReadOnlyWifiHotspotRepositoryDecorator : IReadOnlyWifiHotspotRepository
    {
        private readonly IReadOnlyWifiHotspotRepository _wifiHotspotRepository;

        public ReadOnlyWifiHotspotRepositoryDecorator(IReadOnlyWifiHotspotRepository wifiHotspotRepository)
        {
            _wifiHotspotRepository = wifiHotspotRepository;
        }

        public virtual async Task<IEnumerable<WifiHotspot>> GetAllWifiHotspot()
        {
            return await _wifiHotspotRepository?.GetAllWifiHotspot();
        }

        public virtual async Task<WifiHotspot> GetWifiHotspot(long id)
        {
            return await _wifiHotspotRepository?.GetWifiHotspot(id);
        }

        public virtual async Task<IEnumerable<WifiHotspot>> QueryWifiHotspot(ICriteria<WifiHotspot> criteria)
        {
            return await _wifiHotspotRepository?.QueryWifiHotspot(criteria);
        }
    }
}
