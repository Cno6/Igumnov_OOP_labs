using System;
using System.Collections.Generic;
using System.Text;

namespace ParksWifi.DomainObjects
{
    public class WifiHotspot : DomainObject 
    {
        public string FunctionFlag { get; set; }

        public string WiFiName { get; set; }

        public string Name { get; set; }

        public string ParkName { get; set; }
    }
}
