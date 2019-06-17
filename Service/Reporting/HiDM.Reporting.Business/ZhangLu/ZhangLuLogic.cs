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
    public class ZhangLuLogic : IZhangLuLogic
    {
        private IZhangLuRepository _ZhangLuRepository;

        public ZhangLuLogic(IZhangLuRepository repository)
        {
            _ZhangLuRepository = repository;
        }

        public PagedResults QueryLotHistory(Models.ZhangLuInput input)
        {

            var pageResults = _ZhangLuRepository.GetLotHistory(input);

            return pageResults;
        }

        public PagedResults QueryLotHoldHistory(Models.HoldReleaseInput input)
        {

            var pageResults = _ZhangLuRepository.GetLotHoldHistory(input);

            return pageResults;
        }


    }
}
