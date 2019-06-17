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
    public interface IEQPUpTimeTotalRepository
    {

        PagedResults QueryMonthTotalInfo(QueryTotalInput InfoInput);
        PagedResults QueryYearTotalInfo(QueryTotalInput InfoInput);
        PagedResults QuerySingleInfo(QueryTotalInput InfoInput);
        PagedResults QueryToolInfo(QueryTotalInput InfoInput);
    }
}
