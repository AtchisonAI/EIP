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
    public class ProductIndicesLogic : IProductIndicesLogic
    {
        private IProductIndicesRepository _HoldLotInfoRepository;

        public ProductIndicesLogic(IProductIndicesRepository holdLotInfoRepository)
        {
            _HoldLotInfoRepository = holdLotInfoRepository;
        }

        
        public PagedResults QueryInfo(ProductIndicesInput InfoInput)
        {
          
            var pageResults = _HoldLotInfoRepository.GetQueryInfoList(InfoInput);
            return pageResults;

        }

        public PagedResults QueryInfo1(ProductIndicesInput InfoInput)
        {
            var pageResults = _HoldLotInfoRepository.GetQueryInfoList1(InfoInput);
            return pageResults;
        }

        public PagedResults QueryInfo2(ProductIndicesInput InfoInput)
        {
            var pageResults = _HoldLotInfoRepository.GetQueryInfoList2(InfoInput);
            return pageResults;
        }

        public PagedResults QueryInfo3(ProductIndicesInput InfoInput)
        {
            var pageResults = _HoldLotInfoRepository.GetQueryInfoList3(InfoInput);
            return pageResults;
        }

        public PagedResults QueryInfo4(ProductIndicesInput InfoInput)
        {
            var pageResults = _HoldLotInfoRepository.GetQueryInfoList4(InfoInput);
            return pageResults;
        }

        public PagedResults SubPageDetails(SubPageInput InfoInput)
        {
           
            var pageResults = _HoldLotInfoRepository.GetDetails(InfoInput);
            return pageResults;

        }


    }
}
