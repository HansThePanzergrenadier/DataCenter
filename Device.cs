using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    abstract class Device
    {
        public int Bandwidth { get; set; }
        public List<Link> Ports { get; set; }
        public string DeviceType = null;

        public List<Device> AvailableDevices
        {
            get
            {
                foreach(Link el in Ports)
                {
                    Device device = el.GetOtherDevice(this);
                    if(device.DeviceType != "Router")
                    {
                        AvailableDevices.Add(device);
                    }
                    else if(device.DeviceType == "Router")
                    {
                        AvailableDevices.AddRange(device.AvailableDevices);
                    }
                }

                return AvailableDevices;
            }
        }

        public void ConnectToDevice(Device OtherDevice, int linkBandwidth)
        {
            Device[] devices = { this, OtherDevice };
            Link NewLink = new Link(devices, linkBandwidth);
            Ports.Add(NewLink);
            OtherDevice.Ports.Add(NewLink);
        }
    }
}
