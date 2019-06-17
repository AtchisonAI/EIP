using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public interface IXuTaoRepository
    {
        PagedResults GetLotInfoList(XuTaoInput input);

        DataTable GetLotStatusSummary(XuTaoInput input);

        PagedResults GetLotHistory(Models.LotHistoryInput input);
    }
}
