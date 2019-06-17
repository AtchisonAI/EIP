﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;
using EIP.Common.Entities.ECharts;

namespace HiDM.Reporting.Business
{
    public interface IEQPGroupPerformanceLogic
    {
        PagedResults GetEQPGroupPerformance(EQPGroupPerformanceInput input);
        PagedResults GetEQPGroupWipDetail(EQPGroupPerformanceSubPageInput input);

        PagedResults GetEQPGroupMoveDetail(EQPGroupPerformanceSubPageInput input);

        PagedResults GetEQPGroupWipMoveDetail(EQPGroupPerformanceSubPageInput input);

        ChartOption GetEQPGroupWipMoveChart(EQPGroupPerformanceSubPageInput input);


    }
}
