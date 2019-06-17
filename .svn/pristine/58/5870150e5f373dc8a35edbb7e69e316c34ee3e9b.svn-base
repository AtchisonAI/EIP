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


namespace HiDM.Reporting.Business
{
    public class WIPStatusLogic : IWIPStatusLogic
    {
        private IWIPStatusRepository _WIPStatusRepository;

        public WIPStatusLogic(IWIPStatusRepository repository)
        {
            _WIPStatusRepository = repository;
        }


        public async Task<PagedResults> QueryWIPStatus(Models.WIPStatusInput input)
        {
            var pageResults = await _WIPStatusRepository.WIPStatus1(input);
            pageResults.ExtraDatas.Add("Summary", await _WIPStatusRepository.GetExtraStatus(input));
            return pageResults;
        }
     


    }
}
