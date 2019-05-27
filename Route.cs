using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class Route
    {
        public List<Link> Links = new List<Link>();
        public List<Device> Devices = new List<Device>();
        public Device[] Ends = new Device[2];

        private Route(Device A, Device B, List<Link> links, List<Device> devices)
        {
            Ends[0] = A;
            Ends[1] = B;
            Links = links;
            Devices = devices;
        }

        public int MinimalBandwidth
        {
            get
            {
                int result = 0;

                foreach (Link el in Links)
                {
                    if (result > el.Bandwidth)
                    {
                        result = el.Bandwidth;
                    }
                }

                return result;
            }
        }

        public static int MaximalOfMinimalBandwidths(Device A, Device B)
        {
            List<Route> routes = new List<Route>();

            for(int i = 0; i < 20; i++)
            {
                routes.Add(FindRandomRoute(A, B));
            }

            int result = routes[0].MinimalBandwidth;

            foreach (Route el in routes)
            {
                if (result < el.MinimalBandwidth)
                {
                    result = el.MinimalBandwidth;
                }
            }

            return result;
        }

        public static Route FindRandomRoute(Device A, Device B)
        {
            List<Link> links = new List<Link>();
            List<Device> devices = new List<Device>();
            Random rnd = new Random();
            Device curDev = A;
            Device nextDev;
            devices.Add(curDev);
            while (!devices.Contains(B))
            {
                do
                {
                    bool BadWay = true;

                    foreach (Device el in curDev.AvailableDevices(Device.AvailableDevicesSearchingMode.AllDevicesAsNodes))
                    {
                        if (!devices.Contains(el))
                        {
                            BadWay = false;
                            break;
                        }
                    }
                    if (BadWay)
                    {
                        devices.Remove(devices.Last());
                        links.Remove(links.Last());
                        curDev = devices.Last();
                    }

                    nextDev = curDev.Ports[rnd.Next(0, curDev.Ports.Count)].GetOtherDevice(curDev);
                }
                while (devices.Contains(nextDev));

                devices.Add(nextDev);
                links.Add(Controller.getInstance().FindLink(curDev, nextDev));
                curDev = nextDev;
            }

            Route result = new Route(A, B, links, devices);
            return result;
        }
    }
}
