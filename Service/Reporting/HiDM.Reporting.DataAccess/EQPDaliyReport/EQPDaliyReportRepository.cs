using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models;

namespace HiDM.Reporting.DataAccess
{
    public class EQPDaliyReportRepository : ReportingRepository, IEQPDaliyReportRepository
    {
        public PagedResults GetEQPDaliyReportSync(EQPDailyReportInput input)
        {
            return base.PagingQueryDataTable(getEqpDailyReportSql, input);
        }

        private string getEqpDailyReportSql= @"select eds.* , @rowNumber, @recordCount from RPT_EQP_DALIY_SUMMARY eds @where 
                                         AND eds.EQUIPMENTNAME = DECODE(NVL(:EQPID,' '),' ',eds.EQUIPMENTNAME,:EQPID)
                                         AND eds.Area = DECODE(NVL(:Area,' '),' ',eds.Area,:Area)
                                         AND eds.EQPTYPE = DECODE(NVL(:EQPType,' '),' ',eds.EQPTYPE,:EQPType)
                                         AND eds.snapdate = DECODE(NVL(:queryDate,' '),' ',eds.snapdate,:queryDate)
                                         order by eds.EQUIPMENTNAME";
    }
}
