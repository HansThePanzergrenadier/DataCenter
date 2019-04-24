using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class TaskGenerator : ComputingDevice
    {
        public override void AssignTask(DTTask dTTask)
        {
            TaskQueue.Add(dTTask);
        }

        public override void AssignTasks(List<DTTask> dTTasks)
        {
            TaskQueue.AddRange(dTTasks);
        }

        public void CreateTask(int taskVolume, int taskMemoryConsumption)
        {
            TaskQueue.Add(new DTTask(taskVolume, taskMemoryConsumption));
        }
    }
}
