using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;
using System.IO;

namespace HiDM.Reporting.DataAccess
{
    public class WIPWaferInOutRptRepository : ReportingRepository, IWIPWaferInOutRptRepository
    {
        public DataTable QueryMonInWaferInfo(Models.WIPWaferInOutInput InfoInput)
        {
            //string sStart = "'"+ InfoInput.sMonthStart + "01 000001'";
            //string sEnd = "'" + DateTime.ParseExact(InfoInput.sMonthEnd, "yyyyMM", System.Globalization.CultureInfo.CurrentCulture).AddMonths(1).AddDays(-1).ToString("yyyyMMdd") + " 235959'";

            string sStart = "'" + InfoInput.sMonthStart + "'";
            string sEnd = "'" + InfoInput.sMonthEnd + "'";

            string sql = string.Format(sMonIn, sStart, sEnd);
            return base.QueryDataTable(sql, "Summary", InfoInput.GetManualParams());
        }


        public DataTable QueryMonOutWaferInfo(Models.WIPWaferInOutInput InfoInput)
        {
            string sStart = "'" + InfoInput.sMonthStart + "'";
            string sEnd = "'" + InfoInput.sMonthEnd + "'";

            string sql = string.Format(sMonOut, sStart, sEnd);
            return base.QueryDataTable(sql, "Summary", InfoInput.GetManualParams());
        }


        public DataTable QueryMTDInWaferInfo(Models.WIPWaferInOutInput InfoInput)
        {
            string sMTD = "'" + InfoInput.sMTD + "'";
            string sql = string.Format(sMTDIn, sMTD, sMTD, sMTD);
            return base.QueryDataTable(sql, "Summary", InfoInput.GetManualParams());
        }


        public DataTable QueryMTDOutWaferInfo(Models.WIPWaferInOutInput InfoInput)
        {
            string sMTD = "'" + InfoInput.sMTD + "'";
            string sql = string.Format(sMTDOut, sMTD, sMTD, sMTD);
            return base.QueryDataTable(sql, "Summary", InfoInput.GetManualParams());
        }


        public PagedResults GetQueryInfoList(Models.WaferInOutDetailsInput InfoInput)
        {
            string sDate = "'" + InfoInput.RECORD_DATE + "%'";
            string sType = "'" + InfoInput.INOUTTYPE + "'";
            string sql = string.Format(listSQL, sDate, sType);
            return base.PagingQueryDataTable(sql, InfoInput);
        }

        private string listSQL = @"SELECT HIS.LASTTRACKOUTTIME,ACTIVITY,HIS.WIPID,USERID,LOTQTYOUT,HIS.PRODUCTID ,
STEP.SUBPLANID,STEP.STEPID,STEP.STAGENAME,STEP.RESOURCETYPE, @rowNumber, @recordCount
FROM FWWIPTRANSACTION ACT  
JOIN FWWIPHISTORY HIS 
ON ACT.SYSID = HIS.WIPTXN 
LEFT JOIN FWWIPSTEPHISTORY STEP
 ON STEP.SYSID = ACT.WIPSTEPREF
WHERE ACT.TXNTIMESTAMP LIKE {0} 
AND ACT.ACTIVITY = DECODE(TRIM({1}),'Fab In', 'LotStart','Fab Out', 'Ship')";


        private string sMonIn = @"with x as(select  to_char(add_months(to_date({0},'yyyymm'),+ level-1),'yyyymm') AS mon
        from dual connect by level <= months_between(to_date({1},'yyyymm'),to_date({0},'yyyymm')) +1)
        SELECT 'Fab In' Series, mon name, nvl(SUM(LOTQTYOUT), 0) value
          FROM x
          left join FWWIPTRANSACTION on x.mon = SUBSTR(TXNTIMESTAMP, 1, 6)
                                    and ACTIVITY in ('LotStart')
         GROUP BY x.mon, ACTIVITY
         order by name asc";

        private string sMonOut = @"with x as(select to_char(add_months(to_date({0},'yyyymm'),+ level-1),'yyyymm') AS mon
        from dual connect by level <= months_between(to_date({1},'yyyymm'),to_date({0},'yyyymm')) +1)
        SELECT 'Fab Out' Series, mon name, nvl(SUM(LOTQTYOUT), 0) value
          FROM x
          left join FWWIPTRANSACTION on x.mon = SUBSTR(TXNTIMESTAMP, 1, 6)
                                    and ACTIVITY in ('Ship')
         GROUP BY x.mon, ACTIVITY
         order by name asc";

        private string sMTDIn = @"with tt as(
select to_char(to_date( {0} ,'yyyymm')+(rownum-1),'yyyymmdd') s_date 
from dual  
connect by rownum<=last_day(to_date( {1} ,'yyyymm')) - to_date( {2} ,'yyyymm')+1
) 
select 'Fab In' Series,to_char(to_date(tt.s_date,'yyyy/mm/dd'),'yyyy/mm/dd') name,
nvl((select SUM(act.LOTQTYOUT) from FWWIPTRANSACTION act
where  SUBSTR(act.TXNTIMESTAMP,1,8) = tt.s_date
and  act.ACTIVITY = 'LotStart'),0) value
from tt ";


        private string sMTDOut = @"with tt as(
select to_char(to_date( {0} ,'yyyymm')+(rownum-1),'yyyymmdd') s_date 
from dual  
connect by rownum<=last_day(to_date( {1} ,'yyyymm')) - to_date( {2} ,'yyyymm')+1
) 
select 'Fab Out' Series ,to_char(to_date(tt.s_date,'yyyy/mm/dd'),'yyyy/mm/dd') name,
nvl((select SUM(act.LOTQTYOUT) from FWWIPTRANSACTION act
where  SUBSTR(act.TXNTIMESTAMP,1,8) = tt.s_date
and  act.ACTIVITY = 'Ship'),0) value
from tt ";


    }
}

