using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParksWifi.DomainObjects;
using ParksWifi.ApplicationServices.GetWifiHotspotListUseCase;
using ParksWifi.InfrastructureServices.Presenters;

namespace ParksWifi.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WifiHotspotController : ControllerBase
    {
        private readonly ILogger<WifiHotspotController> _logger;
        private readonly IGetWifiHotspotListUseCase _getWifiHotspotListUseCase;

        public WifiHotspotController(ILogger<WifiHotspotController> logger, IGetWifiHotspotListUseCase getWifiHotspotListUseCase)
        {
            _logger = logger;
            _getWifiHotspotListUseCase = getWifiHotspotListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllWifiHotspots()
        {
            var presenter = new ParksWifi.InfrastructureServices.Presenters.WifiHotspotListPresenter();
            await _getWifiHotspotListUseCase.Handle(GetWifiHotspotListUseCaseRequest.CreateAllWifiHotspotRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{wifiHotspotId}")]
        public async Task<ActionResult> GetWifiHotspot(long wifiHotspotId)
        {
            var presenter = new ParksWifi.InfrastructureServices.Presenters.WifiHotspotListPresenter();
            await _getWifiHotspotListUseCase.Handle(GetWifiHotspotListUseCaseRequest.CreateWifiHotspotRequest(wifiHotspotId), presenter);
            return presenter.ContentResult;
        }
        [HttpGet("Parks/{parkname}")]
        public async Task<ActionResult> GetParkNameFilter(string parkName)
        {
            var presenter = new WifiHotspotListPresenter();
            await _getWifiHotspotListUseCase.Handle(GetWifiHotspotListUseCaseRequest.CreateParkNameWifiHotspotRequest(parkName), presenter);
            return presenter.ContentResult;
        }
    }
}
