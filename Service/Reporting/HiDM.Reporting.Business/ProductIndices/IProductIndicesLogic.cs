using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Business
{
    public interface IProductIndicesLogic
    {
        PagedResults QueryInfo(ProductIndicesInput input);
        PagedResults QueryInfo1(ProductIndicesInput input);
        PagedResults QueryInfo2(ProductIndicesInput input);
        PagedResults QueryInfo3(ProductIndicesInput input);
        PagedResults QueryInfo4(ProductIndicesInput input);



        PagedResults SubPageDetails(SubPageInput input);

    }
}
