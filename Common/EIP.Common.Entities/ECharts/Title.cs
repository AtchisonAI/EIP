using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class Title
    {
        public Title()
        {
            x = "center";
        }
        public string x { get; set; }
        public string text { get; set; }
        public string subtext { get; set; }
    }
}
