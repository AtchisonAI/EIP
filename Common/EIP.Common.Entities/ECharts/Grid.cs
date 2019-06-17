using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.ECharts
{
    public class Grid
    {
        private string _left = "3%";
        public string left { get { return _left; } set { _left = value; } }
        private string _right = "4%";
        public string right { get { return _right; } set { _right = value; } }
        private string _bottom = "3%";
        public string bottom { get { return _bottom; } set { _bottom = value; } }
        public string top { get; set; }
        private bool _containLabel = true;
        public bool containLabel { get { return _containLabel; } set { _containLabel = value; } }
    }
}
