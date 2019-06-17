using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public class ScrapRepository:ReportingRepository, IScrapRepository
    {
        public PagedResults SummaryScrap(Models.ScrapInput InfoInput)
        {
            

           
            if (InfoInput.Bydate != null && InfoInput.Bydate.Length > 0)
            {
                if (InfoInput.Bydate == "q")
                {
                    listSQL = listSQLByQuarterly;
                }
                if (InfoInput.Bydate == "M")
                {
                    listSQL = listSQLByMonthly;
                }
                if (InfoInput.Bydate == "W")
                {
                    listSQL = listSQLByWeekly;
                }
               
            }

             //string sql = string.Format(listSQL, filter);
            return base.PagingQueryDataTable(listSQL, InfoInput);
        }

        private string listSQL = @"";
        private string listSQLByMonthly = @"SELECT 
       to_char(to_date(SUBSTR(fsl.txntimestamp, 1, 15),'yyyy/mm/dd hh24:mi:ss'),'YYYY'||' '||'MM') QueryType,
       fsl.wipid lot_id,
       fs.scrapqty scrap_qty,
       fsp.keytype scrap_code,
       fc.detaileddescription scrap_comment,
       fl.productname,
       fl.productrevision,
       substr(fs.occursinstep, 1, instr(fs.occursinstep, '.') - 1) stepname,
       substr(fs.occursinstep, instr(fs.occursinstep, '.') + 1, 1) stepid,
       fsl.userid,
       to_char(to_date(substr(fsl.txntimestamp,0,15),'yyyy-mm-dd hh24:mi:ss'),'yyyy-mm-dd hh24:mi:ss')as time,
       fwsh.location,
@rowNumber, @recordCount
  FROM fwscraplot fsl
  LEFT JOIN fwlot fl ON fsl.lotobject = fl.sysid
  LEFT JOIN fwscraplot_n2m fsln ON fsln.fromid = fsl.sysid
                               AND fsln.linkname = 'scrapCollection'
  LEFT JOIN fwscrap fs ON fs.sysid = fsln.toid
  LEFT JOIN fwcomment fc ON fsl.txncomment = fc.sysid
  LEFT JOIN fwscrap_pn2m fsp ON fs.sysid = fsp.fromid
                            AND fsp.linkname = 'reasons'
  left join fwwiptransaction fwt on fwt.sysid = fsl.sysid
  left join fwwipstephistory fwsh on fwsh.sysid = fwt.wipstepref
 where TO_NUMBER(to_char(to_date(SUBSTR(fsl.txntimestamp, 1, 15),'yyyy/mm/dd hh24:mi:ss'),'YYYY'||'MM')) BETWEEN
       TO_NUMBER(TO_CHAR(to_date(:StartTime, 'yyyy/mm/dd hh24:mi:ss'),
                         'YYYY' || 'MM')) and
       TO_NUMBER(TO_CHAR(to_date(:EndTime, 'yyyy/mm/dd hh24:mi:ss'),
                         'YYYY' || 'MM')) ";


        private string listSQLByWeekly = @"SELECT 
       to_char(to_date(SUBSTR(fsl.txntimestamp, 1, 15),'yyyy/mm/dd hh24:mi:ss'),'YYYY'||'@ '||'WW') QueryType,
       fsl.wipid lot_id,
       fs.scrapqty scrap_qty,
       fsp.keytype scrap_code,
       fc.detaileddescription scrap_comment,
       fl.productname,
       fl.productrevision,
       substr(fs.occursinstep, 1, instr(fs.occursinstep, '.') - 1) stepname,
       substr(fs.occursinstep, instr(fs.occursinstep, '.') + 1, 1) stepid,
       fsl.userid,
       to_char(to_date(substr(fsl.txntimestamp,0,15),'yyyy-mm-dd hh24:mi:ss'),'yyyy-mm-dd hh24:mi:ss')as time,
       fwsh.location,
       @rowNumber, @recordCount
  FROM fwscraplot fsl
  LEFT JOIN fwlot fl ON fsl.lotobject = fl.sysid
  LEFT JOIN fwscraplot_n2m fsln ON fsln.fromid = fsl.sysid
                               AND fsln.linkname = 'scrapCollection'
  LEFT JOIN fwscrap fs ON fs.sysid = fsln.toid
  LEFT JOIN fwcomment fc ON fsl.txncomment = fc.sysid
  LEFT JOIN fwscrap_pn2m fsp ON fs.sysid = fsp.fromid
                            AND fsp.linkname = 'reasons'
  left join fwwiptransaction fwt on fwt.sysid = fsl.sysid
  left join fwwipstephistory fwsh on fwsh.sysid = fwt.wipstepref
 where TO_NUMBER(to_char(to_date(SUBSTR(fsl.txntimestamp, 1, 15),'yyyy/mm/dd hh24:mi:ss'),'YYYY'||'WW')) BETWEEN
       TO_NUMBER(TO_CHAR(to_date(:StartTime, 'yyyy/mm/dd hh24:mi:ss'),
                         'YYYY' || 'WW')) and
       TO_NUMBER(TO_CHAR(to_date(:EndTime, 'yyyy/mm/dd hh24:mi:ss'),
                         'YYYY' || 'WW'))";
        private string listSQLByQuarterly = @"SELECT 
       to_char(to_date(SUBSTR(fsl.txntimestamp, 1, 15),'yyyy/mm/dd hh24:mi:ss'),'YYYY'||' '||'q') QueryType,
       fsl.wipid lot_id,
       fs.scrapqty scrap_qty,
       fsp.keytype scrap_code,
       fc.detaileddescription scrap_comment,
       fl.productname,
       fl.productrevision,
       substr(fs.occursinstep, 1, instr(fs.occursinstep, '.') - 1) stepname,
       substr(fs.occursinstep, instr(fs.occursinstep, '.') + 1, 1) stepid,
       fsl.userid,
       to_char(to_date(substr(fsl.txntimestamp,0,15),'yyyy-mm-dd hh24:mi:ss'),'yyyy-mm-dd hh24:mi:ss')as time,
       fwsh.location,
    @rowNumber, @recordCount   
  FROM fwscraplot fsl
  LEFT JOIN fwlot fl ON fsl.lotobject = fl.sysid
  LEFT JOIN fwscraplot_n2m fsln ON fsln.fromid = fsl.sysid
                               AND fsln.linkname = 'scrapCollection'
  LEFT JOIN fwscrap fs ON fs.sysid = fsln.toid
  LEFT JOIN fwcomment fc ON fsl.txncomment = fc.sysid
  LEFT JOIN fwscrap_pn2m fsp ON fs.sysid = fsp.fromid
                            AND fsp.linkname = 'reasons'
  left join fwwiptransaction fwt on fwt.sysid = fsl.sysid
  left join fwwipstephistory fwsh on fwsh.sysid = fwt.wipstepref
 where TO_NUMBER(to_char(to_date(SUBSTR(fsl.txntimestamp, 1, 15),'yyyy/mm/dd hh24:mi:ss'),'YYYY'||'MM')) BETWEEN
       TO_NUMBER(TO_CHAR(to_date(:StartTime, 'yyyy/mm/dd hh24:mi:ss'),
                         'YYYY' || 'MM')) and
       TO_NUMBER(TO_CHAR(to_date(:EndTime, 'yyyy/mm/dd hh24:mi:ss'),
                         'YYYY' || 'MM'))";
       
    }
}
