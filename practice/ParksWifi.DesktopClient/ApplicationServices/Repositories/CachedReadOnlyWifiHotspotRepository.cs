using ParksWifi.ApplicationServices.Ports.Cache;
using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using ParksWifi.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParksWifi.InfrastructureServices.Repositories
{
    public class CachedReadOnlyWifiHotspotRepository : ReadOnlyWifiHotspotRepositoryDecorator
    {
        private readonly IDomainObjectsCache<DomainObjects.WifiHotspot> _wifiHotspotCache;

        public CachedReadOnlyWifiHotspotRepository(IReadOnlyWifiHotspotRepository wifiHotspotRepository,
                                             IDomainObjectsCache<DomainObjects.WifiHotspot> wifiHotspotCache)
            : base(wifiHotspotRepository)
            => _wifiHotspotCache = wifiHotspotCache;

        public async override Task<DomainObjects.WifiHotspot> GetWifiHotspot(long id)
            => _wifiHotspotCache.GetObject(id) ?? await base.GetWifiHotspot(id);

        public async override Task<IEnumerable<DomainObjects.WifiHotspot>> GetAllWifiHotspot()
            => _wifiHotspotCache.GetObjects() ?? await base.GetAllWifiHotspot();

        public async override Task<IEnumerable<DomainObjects.WifiHotspot>> QueryWifiHotspot(ICriteria<DomainObjects.WifiHotspot> criteria)
            => _wifiHotspotCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryWifiHotspot(criteria);
    }
}
