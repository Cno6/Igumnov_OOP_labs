using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParksWifi.ApplicationServices.Interfaces;

namespace ParksWifi.ApplicationServices.GetWifiHotspotListUseCase
{
    public interface IGetWifiHotspotListUseCase : IUseCase<GetWifiHotspotListUseCaseRequest, GetWifiHotspotListUseCaseResponse>
    {
    }
}
