using System;
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
    public interface IEQPStatusMonitorRepository:IReportingRepository
    {
        DataTable QueryEQPStatusMonitorData(EQPStatusMonitorInput input);
        PagedResults GetProcessLotList(EQPStatusProcessLotInput input);
    }
}
