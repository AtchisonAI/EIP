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
    public class URD_DueDateLogic : IURD_DueDateLogic
    {
        private IURD_DueDateRepository _HoldLotInfoRepository;

        public URD_DueDateLogic(IURD_DueDateRepository holdLotInfoRepository)
        {
            _HoldLotInfoRepository = holdLotInfoRepository;
        }

        //  public async Task<PagedResults> QueryInfo(Models.QueryInfoInput input)
        // {
        //  var pageResults = await _HoldLotInfoRepository.GetQueryInfoList(input);
        //   pageResults.ExtraDatas.Add("Summary",await _HoldLotInfoRepository.GetHoldSummary(input));
        // return pageResults;
        //}
        public PagedResults QueryInfo(QueryInfoInputForDueDate input)
        {
          //  if (input.TechID.IsNullOrEmpty())
           // {
            //    throw new ParameterRequiredException("TechID");
            //}
            var pageResults = _HoldLotInfoRepository.GetQueryInfoList(input);
            return pageResults;

        }

      

    }
}
