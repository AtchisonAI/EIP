using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public class URD_DueDateRepository : ReportingRepository, IURD_DueDateRepository
    {
        public PagedResults GetQueryInfoList(Models.QueryInfoInputForDueDate InfoInput)
        {
            string filter2 = string.Empty;
            if (InfoInput.selProductID != null && InfoInput.selProductID.Length > 0)
            {
                filter2 = string.Format("AND ProductName IN ('{0}') ", InfoInput.selProductID);
            }
            string filter3 = string.Empty;
            if (InfoInput.LotType != null && InfoInput.LotType.Length > 0)
            {
                filter3 = string.Format("AND LotType IN ('{0}') ", InfoInput.LotType);
            }

            string filter4 = string.Empty;
            if (InfoInput.StartTime != null && InfoInput.StartTime.Length > 0 && InfoInput.EndTime != null && InfoInput.EndTime.Length > 0)
            {
                filter4 = string.Format(" AND to_date(substr(FWWS.TRACKINTIME, 1, 15), 'yyyy-mm-dd hh24:mi:ss') BETWEEN (TO_DATE('{0}','yyyy-mm-dd hh24:mi:ss')) AND (TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss'))   ", InfoInput.StartTime,InfoInput.EndTime);
            }

            string filter = string.Empty;
            filter = filter2 + filter3 +filter4;


            string filter1 = string.Empty;
            string filter5 = string.Empty;
            if (InfoInput.Bydate != null && InfoInput.Bydate.Length > 0)
            {
                if (InfoInput.Bydate == "M")
                {
                    filter5 = "select to_char(to_date(substr(FWWS.TRACKINTIME, 1, 8),'yyyymmdd'),'yyyy||mm') as v_date ";
                }
                if (InfoInput.Bydate == "W")
                {
                    filter5 = "select to_char(to_date(substr(FWWS.TRACKINTIME, 1, 8),'yyyymmdd'),'yyyy||ww') as v_date";
                }
                if (InfoInput.Bydate == "D")
                {
                    filter5 = "select substr(FWWS.TRACKINTIME, 1, 8) as v_date";
                }
            }

             string sql = string.Format(listSQL, filter5, filter);
            return base.PagingQueryDataTable(sql, InfoInput);
        }



        

        private string listSQL = @"{0} ,FWL.appid,
                                               FWL.LOTTYPE,
                                               FWL.PRODUCTNAME || '.' || FWL.PRODUCTREVISION AS PARTID,
                                               FWL.PRIORITY,
                                               fwws.stagename,
                                               fwws.stepname,
                                               fwws.stepseq,
                                               fwws.location,
                                               fwws.processingstate,
                                               svn.requiredcapability,
                                               sv.resourcetype,
                                               pp1.ppid,
                                               fwws.handle,
                                               round((nvl(to_date(substr(FWWS.TRACKINTIME, 1, 15),
                                                                  'yyyymmdd hh24:mi:ss'),
                                                          sysdate) -
                                                     to_date(substr(FWWS.TIMEHERESINCE, 1, 15),
                                                              'yyyymmdd hh24:mi:ss')),
                                                     2)*24 AS CURQTIME,
                                              GETLOTHTIMEBYSTEP(FWWS.lotobject,FWWS.lasthistory) AS CURHOLDTIME,
                                              round( nvl(to_date(substr(FWWS.TRACKOUTTIME, 1, 15),'yyyymmdd hh24:mi:ss'),sysdate) - to_date(substr(FWWS.TRACKINTIME, 1, 15), 'yyyymmdd hh24:mi:ss') ,2)*24 AS CurRTime,
                                               MAX(PP1.Seq_No) over(partition by pp1.partid) totalstep,
                                               (MAX(PP1.Seq_No) over(partition by pp1.partid) - PP1.Seq_No) as Remainingstep,
                                               t.totalstage ,
                                            ( t.totalstage - rank () over (partition by pp1.partid,pp1.stage order by pp1.partid,pp1.seq_no)) as remainingstage,
                                            @rowNumber, @recordCount
                                          from fwwipstep FWWS
                                          left join fwlot FWL on FWL.SYSID = FWWS.LOTOBJECT
                                          left join prom_prod1 PP1 on PP1.PINS = FWWS.STEPSEQ
                                                                  AND PP1.PLAN_STEPSEQ = FWWS.PROCESSOPERATIONSEQ
                                                                  AND PP1.PARTID = FWL.PRODUCTNAME
                                          LEFT JOIN fwstepversion sv ON fwws.stepname = sv.stepname
                                                                    AND fwws.steprevision = sv.revision
                                          LEFT JOIN fabstepversionext svn ON sv.sysid = svn.PARENT
                                          left join (select count(distinct x.stage) as totalstage,x.partid from prom_prod1 x group by x.partid) t on t.partid = FWL.PRODUCTNAME
                                          @where {1} ";


      
    
    }
}
