using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.DataAccess;
using HiDM.Reporting.Models;

namespace HiDM.Reporting.Business
{
    class EQPDaliyReportLogic : IEQPDaliyReportLogic
    {
        private IEQPDaliyReportRepository iEQPDaliyReportRepository;

        public EQPDaliyReportLogic(IEQPDaliyReportRepository input)
        {
            iEQPDaliyReportRepository = input;
        }

        public PagedResults GetEQPDailyReportSync(EQPDailyReportInput input)
        {
            return iEQPDaliyReportRepository.GetEQPDaliyReportSync(input);
        }
    }
}
