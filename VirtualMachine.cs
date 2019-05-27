using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class VirtualMachine
    {
        public int Speed { get; set; }

        public VirtualMachine(PhysicalMachine host, int speed)
        {
            Host = host;
            Speed = speed;
            CurrentTask = null;
        }

        public PhysicalMachine Host { set; get; }

        public DTTask CurrentTask { set; get; }


        //public bool IsBusy 
        //{
        //    get
        //    {
        //        if (CurrentTask != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public void DoTask()
        {
            if(CurrentTask == null || CurrentTask.Volume <= 0)
            {
                if (Host.TaskQueue.Count > 0)
                {
                    CurrentTask = Host.TaskQueue[0];
                    Host.TaskQueue.RemoveAt(0);
                }
                else
                {
                    CurrentTask = null;
                }
            }
            else if (CurrentTask.Volume > 0)
            {
                CurrentTask.Volume -= Speed;
            }
        }
    }
}
