﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models.EQPStatusMonitor;

namespace HiDM.Reporting.Business
{
    public interface IEQPStatusMonitorLogic
    {
        EQPStatusMonitorOutput QueryEQPStatusMonitorData(EQPStatusMonitorInput input);

        PagedResults GetProcessLotList(EQPStatusProcessLotInput input);

    }
}
