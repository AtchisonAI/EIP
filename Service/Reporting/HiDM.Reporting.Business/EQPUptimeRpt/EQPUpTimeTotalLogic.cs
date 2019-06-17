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
    public class EQPUpTimeTotalLogic : IEQPUpTimeTotalLogic
    {
        private IEQPUpTimeTotalRepository _EQPUpTimeTotalRepository;

        public EQPUpTimeTotalLogic(IEQPUpTimeTotalRepository EQPUpTimeTotalRepository)
        {
            _EQPUpTimeTotalRepository = EQPUpTimeTotalRepository;
        }


        public PagedResults QueryMonthTotalInfo(QueryTotalInput input)
        {

            var pageResults = _EQPUpTimeTotalRepository.QueryMonthTotalInfo(input);
            return pageResults;

        }

        public PagedResults QueryYearTotalInfo(QueryTotalInput input)
        {
            
            var pageResults = _EQPUpTimeTotalRepository.QueryYearTotalInfo(input);
            return pageResults;

        }

        public PagedResults QuerySingleInfo(QueryTotalInput input)
        {

            var pageResults = _EQPUpTimeTotalRepository.QuerySingleInfo(input);
            return pageResults;

        }

        public PagedResults QueryToolInfo(QueryTotalInput input)
        {

            var pageResults = _EQPUpTimeTotalRepository.QueryToolInfo(input);
            return pageResults;

        }

    }
}
