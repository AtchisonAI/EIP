using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Models
{
    public class QueryEmployInfoInput: QueryParam
    {
        [Param]
        public string DepetCode { get; set; }

        [Param]
        public string EmployId { get; set; }
    }
}
