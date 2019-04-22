using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class Router : Device
    {
        public Router(int bandwidth)
        {
            Bandwidth = bandwidth;
            Ports = new List<Link>();
            DeviceType = "Router";
        }
    }
}
