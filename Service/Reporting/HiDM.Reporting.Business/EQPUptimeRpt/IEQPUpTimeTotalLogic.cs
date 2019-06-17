using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Business
{
    public interface IEQPUpTimeTotalLogic
    {
        PagedResults QueryMonthTotalInfo(QueryTotalInput input);
        PagedResults QueryYearTotalInfo(QueryTotalInput input);
        PagedResults QuerySingleInfo(QueryTotalInput input);
        PagedResults QueryToolInfo(QueryTotalInput input);


    }
}
