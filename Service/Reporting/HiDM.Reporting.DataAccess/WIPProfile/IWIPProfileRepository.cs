﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models;
using HiDM.Reporting.Models.EQPStatusMonitor;

namespace HiDM.Reporting.DataAccess
{
    public interface IWIPProfileRepository : IReportingRepository
    {
        PagedResults GetWIPData(WIPProfileInput input);
        PagedResults GetLotForecast(LotForecastInput input);

        DataTable QueryCWIP(WIPProfileInput input);
        DataTable QueryMOVE(WIPProfileInput input);
        DataTable QueryHoldWIP(WIPProfileInput input);

        DataTable QueryRunWIP(WIPProfileInput input);

        DataTable QueryQueueWIP(WIPProfileInput input);

    }
}
