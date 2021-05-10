using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ParksWifi.ApplicationServices.GetWifiHotspotListUseCase
{
    public class ParkNameCriteria : ICriteria<DomainObjects.WifiHotspot>
    {
        public string ParkName { get; }

        public ParkNameCriteria(string parkName)
            => this.ParkName = parkName;

        public Expression<Func<DomainObjects.WifiHotspot, bool>> Filter
            => (pn => pn.ParkName == ParkName);
    }
}
