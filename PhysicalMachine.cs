using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class PhysicalMachine : Device
    {
        List<VirtualMachine> VirtualMachines;
        public int Speed { get; set; }
        public int Memory { get; set; }
        List<DTTask> TaskQueue;

        public PhysicalMachine(int speed, int memory)
        {
            Speed = speed;
            Memory = memory;
            DeviceType = "PhysicalMachine";
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

        void GiveTask()
        {
            //
        }
    }
}
