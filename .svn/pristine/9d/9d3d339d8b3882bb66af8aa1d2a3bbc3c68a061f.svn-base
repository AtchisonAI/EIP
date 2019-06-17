using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class HoldLotHistoryInput : QueryParam
    {

        public HoldLotHistoryInput()
        {
        }

        public HoldLotHistoryInput(HoldLotHistoryInput input)
        {
            moduleCode = input.moduleCode;
            analysisUnit = input.analysisUnit;
            beginDate = input.beginDate;
            endDate = input.endDate;
        }

        [Param]
        public string moduleCode { get; set; }

        public string analysisUnit { get; set; }

        [Param]
        public string beginDate { get; set; }

        [Param]
        public string endDate { get; set; }
    }
}