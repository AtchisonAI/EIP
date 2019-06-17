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
    public interface ILotHoldInfoRepository
    {
        Task<PagedResults> GetHoldInfoList(LotHoldInfoInput holdInfoInput);
        
      

       Task<DataTable> GetHoldSummary(Models.LotHoldInfoInput holdInfoInput);
    }
}
