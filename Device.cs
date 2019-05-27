using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataCenter
{
    public abstract class Device
    {
        public Figure Figure { get; set; }
        public List<Link> Ports = new List<Link>();
        public DeviceTypes DeviceType; 
        public enum DeviceTypes
        {
            PhysicalMachine,
            Router,
            TaskGenerator
        }

        public enum AvailableDevicesSearchingMode
        {
            RoutersAsNodes, //for building a path and determining minimal bandwidth (BFS)
            AllNearestMachines,
            AllDevicesAsNodes //for connection checking (BFS)
        }

        public List<Device> AvailableDevices(AvailableDevicesSearchingMode arg)
        {
            if (Ports.LongCount() > 0)
            {
                List<Device> result = new List<Device>();
                switch (arg)
                {
                    case AvailableDevicesSearchingMode.AllNearestMachines:
                        foreach (Link el in Ports)
                        {
                            Device device = el.GetOtherDevice(this);
                            if (device.DeviceType == DeviceTypes.PhysicalMachine)
                            {
                                result.Add(device);
                            }
                            else if (device.DeviceType == DeviceTypes.Router)
                            {
                                result.AddRange(device.AvailableDevices(AvailableDevicesSearchingMode.AllNearestMachines));
                            }
                        }
                        result = result.Distinct().ToList();
                        result.Remove(this);
                        break;
                    case AvailableDevicesSearchingMode.RoutersAsNodes:
                        foreach (Link el in Ports)
                        {
                            Device device = el.GetOtherDevice(this);
                            if (device.DeviceType != DeviceTypes.TaskGenerator)
                            {
                                result.Add(device);
                            }
                        }
                        break;
                    case AvailableDevicesSearchingMode.AllDevicesAsNodes:
                        foreach (Link el in Ports)
                        {
                            Device device = el.GetOtherDevice(this);
                            result.Add(device);
                        }
                        break;
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        
    }
}
