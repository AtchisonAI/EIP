using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Models
{
    public class EQPGroupPerformanceInput: QueryParam
    {
       
        public string Area { get; set; }

       
        public string EQPCap { get; set; }

       
        public string EQPType { get; set; }

        [Param]
        public string StartTime { get; set; }

        [Param]
        public string EndTime { get; set; }

    }
}

