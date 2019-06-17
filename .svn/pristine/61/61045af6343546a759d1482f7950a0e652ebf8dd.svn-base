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
    public class ScrapLogic : IScrapLogic
    {
        private IScrapRepository _HoldLotInfoRepository;

        public ScrapLogic(IScrapRepository holdLotInfoRepository)
        {
            _HoldLotInfoRepository = holdLotInfoRepository;
        }
        public PagedResults Summaryscrap(ScrapInput input)
        {
            var pageResults = _HoldLotInfoRepository.SummaryScrap(input);
            return pageResults;

        }

    }
}
