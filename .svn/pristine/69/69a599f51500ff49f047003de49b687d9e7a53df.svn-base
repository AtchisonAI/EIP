using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.DataAccess;
using EIP.Common.Entities.Paging;
using HiDM.FactoryWorks.TibcoRV;
using HiDM.Reporting.Models;
using HiDM.FactoryWorks.Messages;
using EIP.Common.Entities.ECharts;
using EIP.Common.Entities;

namespace HiDM.Reporting.Business
{
    public class HoldWIPLogic : IHoldWIPLogic
    {
        private IWIPHoldInfoRepository _HoldWIPInfoRepository;

        public HoldWIPLogic(IWIPHoldInfoRepository holdLotInfoRepository)
        {
            _HoldWIPInfoRepository = holdLotInfoRepository;
        }

        public PagedResults QueryWIPInfo(Models.WIPHoldInfoInput input)
        {

            var pageResults = _HoldWIPInfoRepository.GetWIPInfoList(input);
            return pageResults;
        }

        public PagedResults QueryLotDetail(Models.DetailInput input)
        {
            var pageResults = _HoldWIPInfoRepository.GetHoldDetail(input);
            return pageResults;
        }

    }
}
