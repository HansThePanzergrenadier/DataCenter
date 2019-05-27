using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataCenter
{
    class Controller //used to manage data-center. have only 1 instance for all project
    {
        private Controller()
        {
            GlobalTimer.AutoReset = true;
            GlobalTimer.Interval = 100;
            GlobalTimer.Elapsed += GlobalTimer_Elapsed;
        }

        private void GlobalTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DoOperations();
        }

        private static Controller instance = new Controller();
        public static Controller getInstance()
        {
            return instance;
        }
        public Timer GlobalTimer = new Timer();
        public List<Device> Devices = new List<Device>();
        public List<PhysicalMachine> Machines = new List<PhysicalMachine>();
        public List<Link> Links = new List<Link>();
        public TaskGenerator Generator;
        Random rnd = new Random();

        public enum Option
        {
            Speed,
            Memory
        }

        public void ShowLoads()
        {
            foreach(PhysicalMachine el in Machines)
            {
                //show memory and speed load
            }
        }

        public void CancelTest()
        {
            Controller.getInstance().GlobalTimer.Stop();

            foreach (PhysicalMachine el in Machines)
            {
                el.TaskQueue.Clear();
                foreach(VirtualMachine el1 in el.VirtualMachines)
                {
                    el1.CurrentTask = null;
                }
            }
        }

        public Link FindLink(Device A, Device B)
        {
            Link result = null;

            foreach (Link el in Links)
            {
                if (el.Devices.Contains(A) && el.Devices.Contains(B))
                {
                    result = el;
                }
            }

            return result;
        }

        public void ConnectDevices(Device A, Device B, int linkBandwidth, LineConnect linkFigure) //for creating links
        {
            Device[] devices = { A, B };
            Link NewLink = new Link(devices, linkBandwidth, linkFigure);
            Links.Add(NewLink);
            A.Ports.Add(NewLink);
            B.Ports.Add(NewLink);
        }

        /*
        public bool IsSystemCoherent()
        {
            List<Device> devices = new List<Device>();
            devices.Add(Devices[0]);

            for (int i = 0; i < devices.Count; i++)
            {
                for (int j = 0; j < devices[i].AvailableDevices(Device.AvailableDevicesSearchingMode.AllDevicesAsNodes).Count; j++)
                {
                    if (!devices.Contains(devices[i].AvailableDevices(Device.AvailableDevicesSearchingMode.AllDevicesAsNodes)[j]))
                    {
                        devices.Add(devices[i].AvailableDevices(Device.AvailableDevicesSearchingMode.AllDevicesAsNodes)[j]);
                    }
                }
            }

            if(devices.Intersect(Devices) == Devices)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        */


        public void BalanceLoad(Option arg, PhysicalMachine root) //reassigns 1 task from random nearest machine to root machine
        {
            foreach(PhysicalMachine el in root.AvailableDevices(Device.AvailableDevicesSearchingMode.AllNearestMachines))
            {
                int ELload;

                switch (arg)
                {
                    case Option.Speed:
                        ELload = ((PhysicalMachine)el).GetLoadSpeed();
                        if (ELload > root.GetLoadSpeed())
                        {
                            int index = rnd.Next(0, el.VirtualMachines.Count);
                            root.AssignTask(el.VirtualMachines[index].CurrentTask, el);
                            el.VirtualMachines[index].CurrentTask = null;
                        }
                        break;
                    case Option.Memory:
                        ELload = ((PhysicalMachine)el).GetLoadMemory();
                        if(ELload > root.GetLoadMemory())
                        {
                            root.AssignTask(el.TaskQueue.Last(), el);
                        }
                        break;
                }
            }
        }

        public void DoOperations() //method that will be executed every tick
        {
            Generator.CreateTask();

            foreach(PhysicalMachine el in Machines)
            {
                BalanceLoad(Option.Memory, el);
            }

            foreach(PhysicalMachine el in Machines)
            {
                BalanceLoad(Option.Speed, el);
            }

            foreach(PhysicalMachine el in Machines)
            {
                el.DoTasks();
            }
        }

        public SortedList<int, PhysicalMachine> SortMachines(Option arg)
        {
            if (Machines.Count > 0)
            {
                SortedList<int, PhysicalMachine> result = new SortedList<int, PhysicalMachine>();

                switch (arg)
                {
                    case Option.Speed:
                        foreach(PhysicalMachine el in Machines)
                        {
                            result.Add(el.GetLoadSpeed(), el);
                        }
                        break;
                    case Option.Memory:
                        foreach (PhysicalMachine el in Machines)
                        {
                            result.Add(el.GetLoadMemory(), el);
                        }
                        break;
                }

                return result;
            }
            else
            {
                throw new Exception("No machines");
            }
        }
    }
}