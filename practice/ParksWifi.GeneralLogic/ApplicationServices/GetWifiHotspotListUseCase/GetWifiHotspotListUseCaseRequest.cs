using ParksWifi.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.ApplicationServices.GetWifiHotspotListUseCase
{
    public class GetWifiHotspotListUseCaseRequest : IUseCaseRequest<GetWifiHotspotListUseCaseResponse>
    {
        public string ParkName { get; private set; }
        public long? WifiHotspotId { get; private set; }

        private GetWifiHotspotListUseCaseRequest()
        { }

        public static GetWifiHotspotListUseCaseRequest CreateAllWifiHotspotRequest()
        {
            return new GetWifiHotspotListUseCaseRequest();
        }

        public static GetWifiHotspotListUseCaseRequest CreateWifiHotspotRequest(long wifiHotspotId)
        {
            return new GetWifiHotspotListUseCaseRequest() { WifiHotspotId = wifiHotspotId };
        }
            public static GetWifiHotspotListUseCaseRequest CreateParkNameWifiHotspotRequest(string parkName)
            {
            return new GetWifiHotspotListUseCaseRequest() { ParkName = parkName };  
        }

        }
    }


