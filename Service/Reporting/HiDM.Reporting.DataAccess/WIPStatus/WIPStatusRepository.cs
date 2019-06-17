using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public class WIPStatusRepository : ReportingRepository, IWIPStatusRepository
    {

        public Task<PagedResults> WIPStatus1(Models.WIPStatusInput input)
        {
            return base.PagingQueryAsyncDataTable(WIPStatusQL, input);
        }

        public Task<DataTable> GetExtraStatus(Models.WIPStatusInput input)
        {
            return base.QueryAsyncDataTable(ExtraStatusQL, "Summary", input.GetManualParams());
        }
       


        private string WIPStatusQL = @"select t.appid,
       t.componentqty,
       t.productname,
       t.productrevision,
       b.stepname,
       b.stepseq,
       b.steprevision,
       b.processoperationID,
       B.SUBPLANID,
@rowNumber, @recordCount
  from fwlot t
  left join fwwipstep b on t.sysid = b.lotobject
 WHERE T.PROCESSINGSTATUS IN ('Active', 'Hold')
   AND T.PRODUCTNAME=:ProductName";


        private string ExtraStatusQL = "SELECT COUNT(*) \"value\",EXTRASTATUS \"name\"" +
  @"FROM fwlot t
  LEFT JOIN FABLOTEXT B ON T.SYSID = B.PARENT
 WHERE T.PROCESSINGSTATUS IN ('Active', 'Hold')
   AND T.PRODUCTNAME = :ProductName
 GROUP BY B.EXTRASTATUS ";












}
}



    

