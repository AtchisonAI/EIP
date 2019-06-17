using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Business
{
    public interface IEmployInfoLogic
    {
        Task<PagedResults> QueryEmployListAsync(Models.QueryEmployInfoInput input);
        PagedResults QueryEmployListSync(Models.QueryEmployInfoInput input);
    }
}
