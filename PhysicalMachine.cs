using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class PhysicalMachine : ComputingDevice
    {        
        public List<VirtualMachine> VirtualMachines = new List<VirtualMachine>();

        public PhysicalMachine(int speed, int memory, int VMcount, Figure figure)
        {
            if (speed > 0 && memory > 0)
            {
                Figure = figure;
                figure.Owner = this;
                Speed = speed;
                Memory = memory;
                AvailableSpeed = Speed;
                AvailableMemory = Memory;
                DeviceType = DeviceTypes.PhysicalMachine;

                for(int i = 0; i < VMcount; i++) //creating VM`s
                {
                    VirtualMachines.Add(new VirtualMachine(this, (int)(Speed / VMcount)));
                }

                Controller.getInstance().Machines.Add(this);
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
                AvailableSpeed -= speed;
            }
            else
            {
                throw new Exception("Not enough resources for new VM");
            }
        }

        public int GetLoadSpeed() //returns % of busy speed resource of the physical machine
        {
            if (VirtualMachines.LongCount() > 0)
            {
                int result = -1;
                int BusySpeed = 0;
                foreach (VirtualMachine el in VirtualMachines)
                {
                    if (el.CurrentTask != null)
                    {
                        BusySpeed += el.Speed;
                    }
                }

                result = (BusySpeed / Speed * 100);
                return result;
            }
            else
            {
                throw new Exception("No virtual machines");
            }
        }

        public int GetLoadMemory() //returns % of busy memory resource of the physical machine
        {
            return ((Memory - AvailableMemory) / Memory * 100);
        }

        public override void AssignTask(DTTask dTTask, PhysicalMachine Donor)
        {
            if (AvailableMemory >= dTTask.MemoryConsumption)
            {
                TaskQueue.Add(dTTask);
                AvailableMemory -= dTTask.MemoryConsumption;
                Donor.TaskQueue.Remove(dTTask);
            }
            //else
            //{
            //    throw new Exception("Not enough memory for new task");
            //}
        }


        /*
        public override void AssignTasks(List<DTTask> dTTasks, PhysicalMachine Donor)
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
            //else
            //{
            //    throw new Exception("Not enough memory for new tasks");
            //}
        }
        */


        /*
        public SortedList<int, PhysicalMachine> SortAvailableMachines(SortOption arg1) 
        {
            if (AvailableDevices(AvailableDevicesSearchingMode.AllNearestMachines) != null)
            {
                SortedList<int, PhysicalMachine> machines = new SortedList<int, PhysicalMachine>();
                switch (arg1)
                {
                    case SortOption.Speed:
                        foreach (PhysicalMachine el in AvailableDevices(AvailableDevicesSearchingMode.AllNearestMachines))
                        {
                            machines.Add(el.GetLoadSpeed(), el);
                        }
                        break;
                    case SortOption.Memory:
                        foreach(PhysicalMachine el in AvailableDevices(AvailableDevicesSearchingMode.AllNearestMachines))
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
        */       

        public void DoTasks()
        {
            foreach(VirtualMachine el in VirtualMachines)
            {
                el.DoTask();
            }
        }
    }
}
