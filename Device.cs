using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    abstract class Device
    {
        public List<Link> Ports = new List<Link>();
        public string DeviceType = null;

        public List<Device> AvailableDevices
        {
            get
            {
                AvailableDevices = null;

                if (Ports.LongCount() != 0)
                {
                    foreach (Link el in Ports)
                    {
                        Device device = el.GetOtherDevice(this);
                        if (device.DeviceType == "PhysicalMachine")
                        {
                            AvailableDevices.Add(device);
                        }
                        else if (device.DeviceType != "PhysicalMachine")
                        {
                            AvailableDevices.AddRange(device.AvailableDevices);
                        }
                    }
                }

                return AvailableDevices;
            }

            private set { AvailableDevices = value; }
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
