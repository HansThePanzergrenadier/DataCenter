using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    class DTTask
    {
        public int Volume { get; set; }
        public int MemoryConsumption { get; set; }

        public DTTask(int volume, int consumption)
        {
            Volume = volume;
            MemoryConsumption = consumption;
        }
    }
}
