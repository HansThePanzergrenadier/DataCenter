using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class TaskGenerator : ComputingDevice
    {
        public enum GenerationMode
        {
            Manual,
            Random,
            Defined
        }

        public GenerationMode Mode { get; set; }
        public int VolumeMinGenerationBound { get; set; }
        public int VolumeMaxGenerationBound { get; set; }
        public int MemConsumptionMinGenerationBound { get; set; }
        public int MemConsumptionMaxGenerationBound { get; set; }
        public int TaskVolume { get; set; }
        public int TaskMemoryConsumption { get; set; }
        public Random rnd = new Random();


        
        public override void AssignTask(DTTask dTTask, PhysicalMachine Donor)
        {
            throw new NotSupportedException("This class doesn`t support this method");
        }


        /*
        public override void AssignTasks(List<DTTask> dTTasks, PhysicalMachine Donor)
        {
            throw new NotSupportedException("This class doesn`t support this method");
        }
        */


        public void CreateTask() //creates task and give it to a random nearest machine
        {
            int TargetIndex = rnd.Next(0, AvailableDevices(AvailableDevicesSearchingMode.AllNearestMachines).Count);
            PhysicalMachine TargetMachine = (PhysicalMachine)AvailableDevices(AvailableDevicesSearchingMode.AllNearestMachines)[TargetIndex];
            DTTask task;
            switch (Mode)
            {
                case GenerationMode.Random:

                    task = new DTTask(rnd.Next(VolumeMinGenerationBound, VolumeMaxGenerationBound), rnd.Next(MemConsumptionMinGenerationBound, MemConsumptionMaxGenerationBound));

                    if (task.MemoryConsumption <= TargetMachine.AvailableMemory)
                    {
                        TargetMachine.TaskQueue.Add(task);
                        TargetMachine.AvailableMemory -= task.MemoryConsumption;
                    }

                    break;

                case GenerationMode.Defined:

                    task = new DTTask(TaskVolume, TaskMemoryConsumption);

                    if (task.MemoryConsumption <= TargetMachine.AvailableMemory)
                    {
                        TargetMachine.TaskQueue.Add(task);
                        TargetMachine.AvailableMemory -= task.MemoryConsumption;
                    }

                    break;

                case GenerationMode.Manual:

                    break;
            }
            
        }

        public TaskGenerator(GenerationMode mode, int tvolume, int tcons, Figure figure)
        {
            if (Controller.getInstance().Generator == null)
            {
                Figure = figure;
                figure.Owner = this;
                DeviceType = DeviceTypes.TaskGenerator;
                Mode = mode;
                TaskVolume = tvolume;
                TaskMemoryConsumption = tcons;
                Controller.getInstance().Generator = this;
            }
            else
            {
                throw new Exception("Generator alredy exists");
            }
        }

        public TaskGenerator(GenerationMode mode, int volmin, int volmax, int memmin, int memmax, Figure figure)
        {
            if (Controller.getInstance().Generator == null)
            {
                Figure = figure;
                figure.Owner = this;
                DeviceType = DeviceTypes.TaskGenerator;
                Mode = mode;
                VolumeMinGenerationBound = volmin;
                VolumeMaxGenerationBound = volmax;
                MemConsumptionMinGenerationBound = memmin;
                MemConsumptionMaxGenerationBound = memmax;
                Controller.getInstance().Generator = this;
            }
            else
            {
                throw new Exception("Generator alredy exists");
            }
        }
    }
}
