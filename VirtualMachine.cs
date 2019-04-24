using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class VirtualMachine
    {
        public List<DTTask> TaskQueue { get; set; }
        public int Speed { get; set; }

        public VirtualMachine(PhysicalMachine host, int speed)
        {
            Host = host;
            Speed = speed;
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

        public void AssignTask(DTTask dTTask)
        {
            TaskQueue.Add(dTTask);
        }

        public void AssignTasks(List<DTTask> dTTasks)
        {
            TaskQueue.AddRange(dTTasks);
        }

    }
}
