﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class Axis
    {
        private string _type = "category";
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public SplitLine splitLine { get; set; }
        public dynamic boundaryGap { get; set; }
        public List<object> data { get; set; }

        public string name { get; set; }

        public AxisLabel axisLabel { get; set; }
    }

    public class SplitLine
    {
        public bool show { get; set; }
    }
}
