using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using ParksWifi.DomainObjects;
using ParksWifi.InfrastructureServices.Gateways.Database;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ParksWifi.WebService.InfrastructureServices.Gateways
{
    public class GetJsonAndParse
    {
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
