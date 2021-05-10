using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.ApplicationServices.Repositories
{
    public class InMemoryWifiHotspotRepository : IReadOnlyWifiHotspotRepository,
                                                 IWifiHotspotRepository
    {
        private readonly List<DomainObjects.WifiHotspot> _wifiHotspot = new List<DomainObjects.WifiHotspot>();

        public InMemoryWifiHotspotRepository(IEnumerable<DomainObjects.WifiHotspot> wifiHotspot = null)
        {
            if (wifiHotspot != null)
            {
                _wifiHotspot.AddRange(wifiHotspot);
            }
        }

        public Task AddWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
        {
            _wifiHotspot.Add(wifiHotspot);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.WifiHotspot>> GetAllWifiHotspot()
        {
            return Task.FromResult(_wifiHotspot.AsEnumerable());
        }

        public Task<DomainObjects.WifiHotspot> GetWifiHotspot(long id)
        {
            return Task.FromResult(_wifiHotspot.Where(o => o.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.WifiHotspot>> QueryWifiHotspot(ICriteria<DomainObjects.WifiHotspot> criteria)
        {
            return Task.FromResult(_wifiHotspot.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
        {
            _wifiHotspot.Remove(wifiHotspot);
            return Task.CompletedTask;
        }

        public Task UpdateWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
        {
            var foundWifiHotspot = GetWifiHotspot(wifiHotspot.Id).Result;
            if (foundWifiHotspot == null)
            {
                AddWifiHotspot(wifiHotspot);
            }
            else
            {
                if (foundWifiHotspot != wifiHotspot)
                {
                    _wifiHotspot.Remove(foundWifiHotspot);
                    _wifiHotspot.Add(wifiHotspot);
                }
            }
            return Task.CompletedTask;
        }
        public Task ParseAndPush()
        {
            throw new NotImplementedException();
        }
    }
}
