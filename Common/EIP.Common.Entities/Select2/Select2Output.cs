using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities.Select2
{
    public class Select2Output
    {
        public bool isSuccess { get; set; }

        public string errorMsg { get; set; }

        public List<Select2OutputItem> data { get; set; }

        public double totalCount { get; set; }
    }

    public class Select2OutputItem
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}
