using ParksWifi.DomainObjects;
using ParksWifi.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.ApplicationServices.GetWifiHotspotListUseCase
{
    public class GetWifiHotspotListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.WifiHotspot> WifiHotspot { get; }

        public GetWifiHotspotListUseCaseResponse(IEnumerable<DomainObjects.WifiHotspot> wifiHotspot) => WifiHotspot = wifiHotspot;
    }
}
