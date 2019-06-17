using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class ToolBox
    {
        public ToolBox()
        {
            show = true;
            feature = new Feature();
        }
        public bool show { get; set; }
        public Feature feature { get; set; }
    }

    public class Feature
    {
        public Feature()
        {
            saveAsImage = new FeatureItem() { show = true };
        }
        public FeatureItem saveAsImage { get; set; }
        public FeatureItem dataView { get; set; }
    }

    public class FeatureItem
    {
        public bool show { get; set; }
    }
}
