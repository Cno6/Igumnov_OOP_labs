using ParksWifi.ApplicationServices.Ports.Cache;
using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParksWifi.InfrastructureServices.Repositories
{
    public class NetworkWifiHotspotRepository : NetworkRepositoryBase, IReadOnlyWifiHotspotRepository
    {
        private readonly IDomainObjectsCache<DomainObjects.WifiHotspot> _wifiHotspotCache;

        public NetworkWifiHotspotRepository(string host, ushort port, bool useTls, IDomainObjectsCache<DomainObjects.WifiHotspot> wifiHotspotCache)
            : base(host, port, useTls)
            => _wifiHotspotCache = wifiHotspotCache;

        public async Task<DomainObjects.WifiHotspot> GetWifiHotspot(long id)
            => CacheAndReturn(await ExecuteHttpRequest<DomainObjects.WifiHotspot>($"WifiHotspot/{id}"));

        public async Task<IEnumerable<DomainObjects.WifiHotspot>> GetAllWifiHotspot()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<DomainObjects.WifiHotspot>>($"WifiHotspot"), allObjects: true);

        public async Task<IEnumerable<DomainObjects.WifiHotspot>> QueryWifiHotspot(ICriteria<DomainObjects.WifiHotspot> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<WifiHotspot>>($"WifiHotspot"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<DomainObjects.WifiHotspot> CacheAndReturn(IEnumerable<DomainObjects.WifiHotspot> wifiHotspot, bool allObjects = false)
        {
            if (allObjects)
            {
                _wifiHotspotCache.ClearCache();
            }
            _wifiHotspotCache.UpdateObjects(wifiHotspot, DateTime.Now.AddDays(1), allObjects);
            return wifiHotspot;
        }

        private DomainObjects.WifiHotspot CacheAndReturn(DomainObjects.WifiHotspot wifiHotspot)
        {
            _wifiHotspotCache.UpdateObject(wifiHotspot, DateTime.Now.AddDays(1));
            return wifiHotspot;
        }
    }
}
