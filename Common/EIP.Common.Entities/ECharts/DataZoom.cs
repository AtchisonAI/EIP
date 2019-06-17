using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class DataZoom
    {
        public string type { get; set; }
        public int start { get; set; }
        public int end { get; set; }
    }

    public class OutSideDataZoom : DataZoom
    {
        public string handleIcon { get; set; }
        public string handleSize { get; set; }

        public HandleStype handleStype { get; set; }
    }

    public class HandleStype
    {
        public string color { get; set; }
        public int shadowBlur { get; set; }

        public string shadowColor { get; set; }
        public int shadowOffsetX { get; set; }
        public int shadowOffsetY { get; set; }
    }
}
