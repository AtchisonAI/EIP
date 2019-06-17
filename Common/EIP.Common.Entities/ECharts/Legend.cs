using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class Legend
    {
        public Legend()
        {
            x = "center";
        }

        public string type { get; set; }
        public List<string> data { get; set; }
        public string orient { get; set; }
        public string x { get; set; }
        public int? right { get; set; }
        public int? left { get; set; }
        public int? top { get; set; }
        public int? buttom { get; set; }
    }
}
