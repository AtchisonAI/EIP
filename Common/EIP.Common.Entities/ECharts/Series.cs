using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class Series
    {
        public string name { get; set; }
        public string type { get; set; }
        public string stack { get; set; }
        public List<object> data { get; set; }
        public AreaStyle areaStyle { get; set; }
        public SeriesLabel label { get; set; }
        
    }

    public class LineSeries : Series
    {
        public LineSeries()
        {
            type = "line";
        }
        public bool smooth { get; set; }
        public int yAxisIndex { get; set; }
        public int xAxisIndex { get; set; }
    }

    public class BarSeries : Series
    {
        public BarSeries()
        {
            type = "bar";
        }

        public int yAxisIndex { get; set; }
        public int xAxisIndex { get; set; }

        public int barWidth { get; set; }
    }

    public class PieSeries : Series
    {
        public PieSeries()
        {
            type = "pie";
        }
    }

    public class SeriesLabel
    {
        public SeriesLabelNormal normal { get; set; }
    }

    public class SeriesLabelNormal
    {
        public bool show { get; set; }
        public string position { get; set; }
    }

    public class AreaStyle
    {
        public AreaStyleNormal normal { get; set; }
    }

    public class AreaStyleNormal
    {

    }

    
}
