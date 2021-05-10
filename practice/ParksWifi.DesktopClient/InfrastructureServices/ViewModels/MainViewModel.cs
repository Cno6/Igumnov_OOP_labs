using ParksWifi.ApplicationServices.GetWifiHotspotListUseCase;
using ParksWifi.ApplicationServices.Ports;
using ParksWifi.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ParksWifi.DesktopClient.InfrastructureServices.ViewModels 
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetWifiHotspotListUseCase _getWifiHotspotListUseCase;

        public MainViewModel(IGetWifiHotspotListUseCase getWifiHotspotListUseCase)
            => _getWifiHotspotListUseCase = getWifiHotspotListUseCase;

        private Task<bool> _loadingTask;
        private DomainObjects.WifiHotspot _currentWifiHotspot;
        private ObservableCollection<DomainObjects.WifiHotspot> _WifiHotspot;

        public event PropertyChangedEventHandler PropertyChanged;

        public DomainObjects.WifiHotspot CurrentWifiHotspot
        {
            get => _currentWifiHotspot;
            set
            {
                if (_currentWifiHotspot != value)
                {
                    _currentWifiHotspot = value;
                    OnPropertyChanged(nameof(CurrentWifiHotspot));
                }
            }
        }

        private async Task<bool> LoadWifiHotspots()
        {
            var outputPort = new OutputPort();
            bool result = await _getWifiHotspotListUseCase.Handle(GetWifiHotspotListUseCaseRequest.CreateAllWifiHotspotRequest(), outputPort);
            if (result)
            {
                WifiHotspots = new ObservableCollection<DomainObjects.WifiHotspot>(outputPort.WifiHotspots);
            }
            return result;
        }

        public ObservableCollection<DomainObjects.WifiHotspot> WifiHotspots
        {
            get
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadWifiHotspots();
                }

                return _WifiHotspot;
            }
            set
            {
                if (_WifiHotspot != value)
                {
                    _WifiHotspot = value;
                    OnPropertyChanged(nameof(WifiHotspots));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetWifiHotspotListUseCaseResponse>
        {
            public IEnumerable<DomainObjects.WifiHotspot> WifiHotspots { get; private set; }

            public void Handle(GetWifiHotspotListUseCaseResponse response)
            {
                if (response.Success)
                {
                    WifiHotspots = new ObservableCollection<DomainObjects.WifiHotspot>(response.WifiHotspot);
                }
            }
        }
    }
}
