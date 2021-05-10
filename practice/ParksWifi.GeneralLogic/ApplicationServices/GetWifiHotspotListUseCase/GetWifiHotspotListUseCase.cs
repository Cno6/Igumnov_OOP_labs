using System.Threading.Tasks;
using System.Collections.Generic;
using ParksWifi.DomainObjects;
using ParksWifi.DomainObjects.Ports;
using ParksWifi.ApplicationServices.Ports;

namespace ParksWifi.ApplicationServices.GetWifiHotspotListUseCase
{
    public class GetWifiHotspotListUseCase : IGetWifiHotspotListUseCase
    {
        private readonly IReadOnlyWifiHotspotRepository _readOnlyWifiHotspotRepository;

        public GetWifiHotspotListUseCase(IReadOnlyWifiHotspotRepository readOnlyWifiHotspotRepository)
            => _readOnlyWifiHotspotRepository = readOnlyWifiHotspotRepository;

        public async Task<bool> Handle(GetWifiHotspotListUseCaseRequest request, IOutputPort<GetWifiHotspotListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.WifiHotspot> wifiHotspots = null;
            if (request.WifiHotspotId != null)
            {
                var wifiHotspot = await _readOnlyWifiHotspotRepository.GetWifiHotspot(request.WifiHotspotId.Value);
                wifiHotspots = (wifiHotspot != null) ? new List<DomainObjects.WifiHotspot>() { wifiHotspot } : new List<DomainObjects.WifiHotspot>();

            }
            else if (request.ParkName != null)
            {
                wifiHotspots = await _readOnlyWifiHotspotRepository.QueryWifiHotspot(new ParkNameCriteria(request.ParkName));
            }
            else
            {
                wifiHotspots = await _readOnlyWifiHotspotRepository.GetAllWifiHotspot();
            }
            outputPort.Handle(new GetWifiHotspotListUseCaseResponse(wifiHotspots));
            return true;
        }
    }
}
