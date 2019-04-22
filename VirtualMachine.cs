using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class VirtualMachine : ComputingDevice
    {
        public VirtualMachine(PhysicalMachine host, int speed, int memory)
        {
            Host = host;
            Speed = speed;
            Memory = memory;
            CurrentTask = null;
        }

        public PhysicalMachine Host
        {
            get
            {
                return Host;
            }

            private set
            {
                Host = value;
            }
        }

        public DTTask CurrentTask
        {
            get
            {
                return CurrentTask;
            }

            private set
            {
                CurrentTask = value;
            }
        }
        
        public bool IsBusy
        {
            get
            {
                if(CurrentTask != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
