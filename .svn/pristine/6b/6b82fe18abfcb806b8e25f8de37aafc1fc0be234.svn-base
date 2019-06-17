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
    public interface IWIPStatusRepository
    {
        Task<PagedResults> WIPStatus1(Models.WIPStatusInput input);

        Task<DataTable> GetExtraStatus(Models.WIPStatusInput input);

    }
}
