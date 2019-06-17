﻿using System;
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
    public class XuTaoLogic:IXuTaoLogic
    {
        private IXuTaoRepository _XuTaoRepository;

        public XuTaoLogic(IXuTaoRepository repository)
        {
            _XuTaoRepository = repository;
        }

        public PagedResults QueryLotInfo(Models.XuTaoInput input)
        {
            if (input.ProductName.IsNullOrEmpty())
            {
                throw new ParameterRequiredException("ProductName");
            }
            var pageResults = _XuTaoRepository.GetLotInfoList(input);
            var summaryData = _XuTaoRepository.GetLotStatusSummary(input);
            ChartOption option = summaryData.ToChartOption(ChartType.Bar, "", "", "Status", "Series", "CNT", "asd", ChartDirection.Vertical);
            pageResults.ExtraDatas.Add("Summary", option);
            option = summaryData.ToChartOption(ChartType.Line, "", "", "Status", "Series", "CNT", "asd", ChartDirection.Vertical);
            pageResults.ExtraDatas.Add("Summary1", option);
            return pageResults;
        }

        public PagedResults QueryLotHistory(Models.LotHistoryInput input)
        {
            var pageResults = _XuTaoRepository.GetLotHistory(input);
            return pageResults;
        }

    }
}
