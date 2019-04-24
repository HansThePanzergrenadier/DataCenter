using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class Router : Device
    {
        public Router()
        {
            Ports = new List<Link>();
            DeviceType = "Router";
        }
    }
}
