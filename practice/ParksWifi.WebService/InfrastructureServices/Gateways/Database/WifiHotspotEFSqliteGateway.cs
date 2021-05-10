using ParksWifi.DomainObjects;
using ParksWifi.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using ParksWifi.WebService.InfrastructureServices.Gateways;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace ParksWifi.InfrastructureServices.Gateways.Database
{
    public class WifiHotspotEFSqliteGateway : IWifiHotspotDatabaseGateway
    {
        private readonly WifiHotspotContext _wifiHotspotContext;

        public WifiHotspotEFSqliteGateway(WifiHotspotContext wifiHotspotContext)
            => _wifiHotspotContext = wifiHotspotContext;

        public async Task<DomainObjects.WifiHotspot> GetWifiHotspot(long id)
           => await _wifiHotspotContext.WifiHotspots.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<DomainObjects.WifiHotspot>> GetAllWifiHotspot()
            => await _wifiHotspotContext.WifiHotspots.ToListAsync();

        public async Task<IEnumerable<DomainObjects.WifiHotspot>> QueryWifiHotspot(Expression<Func<DomainObjects.WifiHotspot, bool>> filter)
            => await _wifiHotspotContext.WifiHotspots.Where(filter).ToListAsync();

        public async Task AddWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
        {
            _wifiHotspotContext.WifiHotspots.Add(wifiHotspot);
            await _wifiHotspotContext.SaveChangesAsync();
        }

        public async Task UpdateWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
        {
            _wifiHotspotContext.Entry(wifiHotspot).State = EntityState.Modified;
            await _wifiHotspotContext.SaveChangesAsync();
        }

        public async Task RemoveWifiHotspot(DomainObjects.WifiHotspot wifiHotspot)
        {
            _wifiHotspotContext.WifiHotspots.Remove(wifiHotspot);
            await _wifiHotspotContext.SaveChangesAsync();
        }

        public async Task ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/861/rows?$top=1000&api_key=aa7d205e0e57ba3c61809d4c102c31e5");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<WifiHotspotContext>();
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            string newnewpath = System.IO.Path.Combine(newPath, "ParksWifi.WebService", "WifiHotspot.db");
            optionsBuilder.UseSqlite($"Data Source={newnewpath}");
            var context = new WifiHotspotContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM WifiHotspots");
            using (context)
            {
                foreach (var item in resultServer)
                {
                    DomainObjects.WifiHotspot wifiHotspot = new DomainObjects.WifiHotspot();
                    wifiHotspot.ParkName = item.Cells.ParkName;
                    wifiHotspot.FunctionFlag = item.Cells.FunctionFlag;
                    wifiHotspot.WiFiName = item.Cells.WiFiName;
                    wifiHotspot.Name = item.Cells.Name;
                    context.Entry(wifiHotspot).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            await Task.CompletedTask;
        }
    }
}
