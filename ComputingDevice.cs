using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    abstract class ComputingDevice : Device
    {
        public List<DTTask> TaskQueue = new List<DTTask>();
        public int Speed { get; set; } //speed - what volume of a task will be done for 1 tick
        public int Memory { get; set; } //memory - how much tasks it can store
        
        abstract public void AssignTask(DTTask dTTask, PhysicalMachine Donor);
        //abstract public void AssignTasks(List<DTTask> dTTasks, PhysicalMachine Donor);
    }
}
