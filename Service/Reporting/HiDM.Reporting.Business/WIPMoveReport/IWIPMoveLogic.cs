using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Business
{
    public interface IWIPMoveLogic
    {
        PagedResults QueryInfo(QueryInfoInput input);
        PagedResults QueryInfo1(QueryInfoInput input);
        //   Task<IList<BaseHoldInfo>> ReleaseLots(ReleaseLotInput input);

    }
}
