using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    abstract class ComputingDevice : Device
    {
        public List<DTTask> TaskQueue { get; set; }
        public int Speed { get; set; }
        public int Memory { get; set; }
        
        abstract public void AssignTask(DTTask dTTask);
        abstract public void AssignTasks(List<DTTask> dTTasks);
    }
}
