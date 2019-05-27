using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class Router : Device
    {
        public Router(Figure figure)
        {
            figure.Owner = this;
            Figure = figure;
            Ports = new List<Link>();
            DeviceType = DeviceTypes.Router;
        }
    }
}
