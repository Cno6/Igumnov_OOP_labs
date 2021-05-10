using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParksWifi.WebService.InfrastructureServices.Gateways
{
    public class Cells
    {
        public string FunctionFlag { get; set; }

        public string WiFiName { get; set; }

        public string Name { get; set; }

        public string ParkName { get; set; }
    }

    public class ResultFromServer
    {
        public int Number { get; set; }
        public Cells Cells { get; set; }
    }
}
