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
        public DTTask CurrentTask { get; set; }

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
    }
}
