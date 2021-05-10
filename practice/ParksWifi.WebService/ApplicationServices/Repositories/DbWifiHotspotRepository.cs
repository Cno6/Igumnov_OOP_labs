using System;
using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using ParksWifi.ApplicationServices.Ports.Gateways.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.ApplicationServices.Repositories
{
    public class DbWifiHotspotRepository : IReadOnlyWifiHotspotRepository,
                                           IWifiHotspotRepository
    {
        private readonly IWifiHotspotDatabaseGateway _databaseGateway;

        public DbWifiHotspotRepository(IWifiHotspotDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<DomainObjects.WifiHotspot> GetWifiHotspot(long id)
            => await _databaseGateway.GetWifiHotspot(id);

        public async Task<IEnumerable<DomainObjects.WifiHotspot>> GetAllWifiHotspot()
            => await _databaseGateway.GetAllWifiHotspot();

        public async Task<IEnumerable<DomainObjects.WifiHotspot>> QueryWifiHotspot(ICriteria<DomainObjects.WifiHotspot> criteria)
            => await _databaseGateway.QueryWifiHotspot(criteria.Filter);

        public async Task AddWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
            => await _databaseGateway.AddWifiHotspot(wifiHotspot);

        public async Task RemoveWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
            => await _databaseGateway.RemoveWifiHotspot(wifiHotspot);

        public async Task UpdateWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
            => await _databaseGateway.UpdateWifiHotspot(wifiHotspot);

        public async Task ParseAndPush()
            => await _databaseGateway.ParseAndPush();
    }
}
