using System.Net;
using Newtonsoft.Json;
using ParksWifi.ApplicationServices.Ports;
using ParksWifi.ApplicationServices.GetWifiHotspotListUseCase;

namespace ParksWifi.InfrastructureServices.Presenters
{
    public class WifiHotspotListPresenter : IOutputPort<GetWifiHotspotListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public WifiHotspotListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetWifiHotspotListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.WifiHotspot) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
