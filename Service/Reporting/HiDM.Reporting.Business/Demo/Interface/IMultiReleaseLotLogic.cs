using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Business
{
    public interface IMultiReleaseLotLogic
    {
        Task<PagedResults> QueryLotHoldInfo(LotHoldInfoInput input);
        Task<IList<BaseHoldInfo>> ReleaseLots(ReleaseLotInput input);

    }
}
