using ParksWifi.DesktopClient.InfrastructureServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;
using ParksWifi.InfrastructureServices.Gateways.Database;
using ParksWifi.WebService.InfrastructureServices.Gateways;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Data.Sqlite;

namespace ParksWifi.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            Button btn = new Button();
            btn.Name = "btn1";
            btn.Click += btn1_Click;
            DataContext = viewModel;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/861/rows?$top=1000&api_key=aa7d205e0e57ba3c61809d4c102c31e5");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            var optionsBuilder = new DbContextOptionsBuilder<WifiHotspotContext>();
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            string newnewpath = System.IO.Path.Combine(newPath, "ParksWifi.WebService", "ParksWifi.db");
            optionsBuilder.UseSqlite($"Data Source={newnewpath}");
            var context = new WifiHotspotContext(options: optionsBuilder.Options);
            context.Database.ExecuteSqlRaw("DELETE FROM WifiHotspot");
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
        }
    }
}