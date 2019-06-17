using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class ToolTip
    {
        private string _trigger = "axis";
        public string trigger { get { return _trigger; } set { _trigger = value; } }

        public ToolTipAxisPointer axisPointer { get; set; }

        private string _formatter = "{a} <br/>{b} : {c} ({d}%)";
        public string formatter { get { return _formatter; } set { _formatter = value; } }
    }


    public class ToolTipAxisPointer
    {
        private string _type ="shadow";
        public string type { get { return _type; } set { _type = value; } }

        public string ToolTipAxisPointerLabel { get; set; }
    }

    public class ToolTipAxisPointerLabel
    {
        private string _backgroudColor = "#3398DB";
        public string backgroundColor { get { return _backgroudColor; } set { _backgroudColor = value; } }
    }
}
