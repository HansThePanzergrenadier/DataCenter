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

        public PhysicalMachine(int speed, int memory, int bandwidth)
        {
            Speed = speed;
            Memory = memory;
            AvailableSpeed = Speed;
            AvailableMemory = Memory;
            Ports = new List<Link>();            
            Bandwidth = bandwidth;
            DeviceType = "PhysicalMachine";
        }

        public int AvailableSpeed { get; set; }
        public int AvailableMemory { get; set; }

        public void CreateVirtualMachine(int speed, int memory)
        {
            if(speed <= AvailableSpeed && memory <= AvailableMemory)
            {
                VirtualMachines.Add(new VirtualMachine(this, speed, memory));
            }
            else
            {
                throw new Exception("Not enough resources for new VM");
            }
        }

        public int GetLoad
        {
            get
            {
                int result = -1;

                int busy_machines = 0;
                foreach(VirtualMachine el in VirtualMachines)
                {
                    if (el.IsBusy)
                    {
                        busy_machines++;
                    }
                }

                result =  (int)(busy_machines / VirtualMachines.LongCount() * 100);
                return result;
            }
        }

        public override void AssignTask(DTTask dTTask)
        {
            TaskQueue.Add(dTTask);
        }

        public override void AssignTasks(List<DTTask> dTTasks)
        {
            TaskQueue.AddRange(dTTasks);
        }

    }
}
