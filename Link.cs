using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class Link
    {
        public int Bandwidth { get; set; }
        private Device[] Devices = new Device[2];

        public Device GetOtherDevice(Device currentDevice)
        {
            Device result = null;

            for(int i = 0; i < Devices.Length; i++)
            {
                if(Devices[i] == currentDevice)
                {
                    switch (i)
                    {
                        case 0:
                            result = Devices[1];
                            break;
                        case 1:
                            result = Devices[0];
                            break;
                    }
                    break;
                }
            }

            return result;
        }

        public Link(Device[] devices, int bandwidth)
        {
            Bandwidth = bandwidth;
            Devices = devices;
        }
    }
}
