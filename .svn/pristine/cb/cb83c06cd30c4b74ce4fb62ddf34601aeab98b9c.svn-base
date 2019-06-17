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
using HiDM.FactoryWorks.TibcoRV;

namespace HiDM.Reporting.Business.Demo
{
    public class ProductLogic : IProductLogic
    {
        private IProductNameRepository _ProductRepository;

        public ProductLogic(IProductNameRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<PagedResults> QueryProduct(Models.ProductNameInput input)
        {
          var pageResults = await _ProductRepository.GetProductList(input);
          pageResults.ExtraDatas.Add("Summary",await _ProductRepository.GetProductSummary(input));
          return pageResults;
        }
    }
}
