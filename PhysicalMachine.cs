using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class PhysicalMachine : ComputingDevice
    {
        public enum SortOption
        {
            Speed,
            Memory,
            ShareableSpeed,
            ShareableMemory
        }
        public List<VirtualMachine> VirtualMachines = new List<VirtualMachine>();

        public PhysicalMachine(int speed, int memory)
        {
            if (speed > 0 && memory > 0)
            {
                Speed = speed;
                Memory = memory;
                AvailableSpeed = Speed;
                AvailableMemory = Memory;
                Ports = new List<Link>();
                DeviceType = "PhysicalMachine";
            }
            else
            {
                throw new Exception("Wrong arguments, must be > 0");
            }
        }

        public int AvailableSpeed { get; set; }
        public int AvailableMemory { get; set; }

        public void CreateVirtualMachine(int speed)
        {
            if(speed <= AvailableSpeed)
            {
                VirtualMachines.Add(new VirtualMachine(this, speed));
            }
            else
            {
                throw new Exception("Not enough resources for new VM");
            }
        }

        public int GetLoadSpeed() //returns % of busy speed resource of the physical machine
        {
            int result = -1;

            int BusySpeed = 0;
            foreach (VirtualMachine el in VirtualMachines)
            {
                if (el.IsBusy)
                {
                    BusySpeed += el.Speed;
                }
            }

            result = (BusySpeed / Speed * 100);
            return result;
        }

        public int GetLoadMemory() //returns % of busy memory resource of the physical machine
        {
            return ((Memory - AvailableMemory) / Memory * 100);
        }

        public override void AssignTask(DTTask dTTask)
        {
            if (AvailableMemory >= dTTask.MemoryConsumption)
            {
                TaskQueue.Add(dTTask);
                AvailableMemory -= dTTask.MemoryConsumption;
            }
            else
            {
                throw new Exception("Not enough resources for new task");
            }
        }

        public override void AssignTasks(List<DTTask> dTTasks)
        {
            int TotalMemoryConsumption = 0;

            foreach(DTTask el in dTTasks)
            {
                TotalMemoryConsumption += el.MemoryConsumption;
            }

            if (AvailableMemory >= TotalMemoryConsumption)
            {
                TaskQueue.AddRange(dTTasks);
                AvailableMemory -= TotalMemoryConsumption;
            }
            else
            {
                throw new Exception("Not enough resources for new tasks");
            }
        }

        public SortedList<int, PhysicalMachine> SortAvailableMachines(SortOption arg)
        {
            if (AvailableDevices != null)
            {
                SortedList<int, PhysicalMachine> machines = new SortedList<int, PhysicalMachine>();
                switch (arg)
                {
                    case SortOption.Speed:
                        foreach (PhysicalMachine el in AvailableDevices)
                        {
                            machines.Add(el.GetLoadSpeed(), el);
                        }
                        break;
                    case SortOption.Memory:
                        foreach(PhysicalMachine el in AvailableDevices)
                        {
                            machines.Add(el.GetLoadMemory(), el);
                        }
                        break;
                }
                return machines;
            }
            else
            {
                throw new Exception("No connected devices");
            }
        }

        public void TakeTask()
        {
            
        }
    }
}
