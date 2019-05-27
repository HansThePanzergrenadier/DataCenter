using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    public class Link
    {
        public LineConnect Line { get; set; }
        public int Bandwidth { get; set; }
        public Device[] Devices = new Device[2];

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

        public Link(Device[] devices, int bandwidth, LineConnect line)
        {
            Line = line;
            Bandwidth = bandwidth;
            Devices = devices;
            Controller.getInstance().Links.Add(this);
            line.Owner = this;
        }
    }
}
