using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter
{
    public class Figure
    {
        public Device Owner { get; set; }

        public int Xpos;
        public int Ypos;
        public int width;
        public int height;

        public Figure(int Xpos, int Ypos, int width, int height)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.width = width;
            this.height = height;
        }
    }
}
