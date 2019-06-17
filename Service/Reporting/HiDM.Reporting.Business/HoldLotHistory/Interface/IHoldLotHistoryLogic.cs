using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Business
{
    public interface IHoldLotHistoryLogic
    {
        Task<PagedResults> QueryHoldLotHistoryListAsync(Models.HoldLotHistoryInput input);
        PagedResults QueryHoldLotHistoryListSync(Models.HoldLotHistoryInput input);


    }
}
