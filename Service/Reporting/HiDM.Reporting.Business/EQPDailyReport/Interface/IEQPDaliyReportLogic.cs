using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Business
{
    public interface IEQPDaliyReportLogic
    {
        PagedResults GetEQPDailyReportSync(Models.EQPDailyReportInput input);
    }
}
