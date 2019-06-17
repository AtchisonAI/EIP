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
    public interface IWIPHoldInfoRepository
    {
        PagedResults GetWIPInfoList(WIPHoldInfoInput input);


        PagedResults GetHoldDetail(Models.DetailInput input);
    }
}
