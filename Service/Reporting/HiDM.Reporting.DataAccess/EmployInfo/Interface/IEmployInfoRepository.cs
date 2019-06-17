using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public interface IEmployInfoRepository
    {
        Task<PagedResults> GetEmployListAsync(Models.QueryEmployInfoInput input);
        Task<DataTable> GetEmploySummaryAsync(Models.QueryEmployInfoInput input);

        PagedResults GetEmployListSync(Models.QueryEmployInfoInput input);
        DataTable GetEmploySummarySync(Models.QueryEmployInfoInput input);

        DataTable[] GetEmploySummaryListSync(Models.QueryEmployInfoInput input);
    }
}
