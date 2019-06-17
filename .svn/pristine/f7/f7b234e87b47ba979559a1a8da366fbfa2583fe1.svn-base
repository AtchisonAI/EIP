using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public class QueryInfoRepository:ReportingRepository, IQueryInfoRepository
    {
        public PagedResults GetQueryInfoList(Models.QueryInfoInput InfoInput)
        {
            string filter2 = string.Empty;
            if (InfoInput.ProductID != null && InfoInput.ProductID.Length > 0)
            {
                filter2 = string.Format("AND ProductName IN ('{0}') ", InfoInput.ProductID);
            }
            string filter3 = string.Empty;
            if (InfoInput.Priority != null && InfoInput.Priority.Length > 0)
            {
                filter3 = string.Format("AND Priority IN ('{0}') ", InfoInput.Priority);
            }
            string filter4 = string.Empty;
            if (InfoInput.InternalPriority != null && InfoInput.InternalPriority.Length > 0)
            {
                filter4 = string.Format("AND InternalPriority IN ('{0}') ", InfoInput.InternalPriority);
            }
            string filter = string.Empty;
            //  filter = filter2 + filter3 + filter4;
            filter = filter2 + filter3;


            string filter1 = string.Empty;
            string filter5 = string.Empty;
            if (InfoInput.Bydate != null && InfoInput.Bydate.Length > 0)
            {
                if (InfoInput.Bydate == "M")
                {
                    listSQL = listSQLByMonthly;
                }
                if (InfoInput.Bydate == "W")
                {
                    listSQL = listSQLByWeekly;
                }
                if (InfoInput.Bydate == "D")
                {
                    listSQL =  listSQLByDalily;
                }
            }

             string sql = string.Format(listSQL, filter);
            return base.PagingQueryDataTable(sql, InfoInput);
        }


        public PagedResults GetQueryInfoList1(Models.QueryInfoInput InfoInput)
        {
            string filter2 = string.Empty;
            if (InfoInput.ProductID != null && InfoInput.ProductID.Length > 0)
            {
                filter2 = string.Format("AND ProductNAME IN ('{0}') ", InfoInput.ProductID);
            }
            string filter3 = string.Empty;
            if (InfoInput.Priority != null && InfoInput.Priority.Length > 0)
            {
                filter3 = string.Format("AND Priority IN ('{0}') ", InfoInput.Priority);
            }
            string filter4 = string.Empty;
            if (InfoInput.InternalPriority != null && InfoInput.InternalPriority.Length > 0)
            {
                filter4 = string.Format("AND InternalPriority IN ('{0}') ", InfoInput.InternalPriority);
            }
            string filter = string.Empty;
            //  filter = filter2 + filter3 + filter4;
            filter = filter2 + filter3;


            string filter1 = string.Empty;
            string filter5 = string.Empty;

            if (InfoInput.Bydate != null && InfoInput.Bydate.Length > 0)
            {
                if (InfoInput.Bydate == "M")
                {
                    listSQL1 = listSQLByMonthly1;
                }
                if (InfoInput.Bydate == "W")
                {
                    listSQL1 = listSQLByWeekly1;
                }
                if (InfoInput.Bydate == "D")
                {
                    listSQL1 = listSQLByDalily1;
                }
            }

            //listSQL = filter1 + listSQL + filter5;
            string sql = string.Format(listSQL1, filter);
            return base.PagingQueryDataTable(sql, InfoInput);
        }

        private string listSQL = @"";
        private string listSQL1 = @"";
        private string listSQLByMonthly = @"SELECT T3.V_DATE,
                                                   T3.BOH,
                                                   T3.EOH,
                                                   T3.STAGEMOVE,
                                                   DECODE(T3.EOH, 0, 0, ROUND(T3.STAGEMOVE / T3.EOH, 2)) AS TR,
                                                   @rowNumber, @recordCount
                                              FROM (select t1.lotwiptime AS V_DATE,
                                                           t1.boh,
                                                           lead(t1.boh, 1, 0) over(order by t1.lotwiptime) AS EOH,
                                                           NVL(T2.STAGEMOVE, 0) as STAGEMOVE
        
                                                      from (select t.lotwiptime, sum(t.wip_lot_qty) as boh
                                                              from RPT_PROC_WIP_INFO_MONTHLY t
                                                             WHERE T.LOTTYPE = 'P' {0}
                                                               and to_NUMBER(t.lotwiptime) between
                                                                   TO_NUMBER(TO_CHAR(to_date(:StartTime,
                                                                                             'yyyy/mm/dd hh24:mi:ss'),
                                                                                     'YYYY' || 'MM')) and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,
                                                                                             'yyyy/mm/dd hh24:mi:ss'),
                                                                                     'YYYY' || 'MM'))
                                                             group by t.lotwiptime
                                                             order by t.lotwiptime desc) t1
                                                      LEFT JOIN (SELECT SUBSTR(X.RECORD_DATE, 1, 6) AS RECORD_DATE,
                                                                       SUM(X.MOVELOTQTY) AS STAGEMOVE
                                                                  FROM RPT_TBL_PART_INFO X
                                                                 WHERE X.LOTTYPE = 'P'{0}
                                                                   and TO_NUMBER(SUBSTR(X.RECORD_DATE, 1, 6)) BETWEEN
                                                                       TO_NUMBER(TO_CHAR(to_date(:StartTime,
                                                                                                 'yyyy/mm/dd hh24:mi:ss'),
                                                                                         'YYYY' || 'MM')) and
                                                                       TO_NUMBER(TO_CHAR(to_date(:EndTime,
                                                                                                 'yyyy/mm/dd hh24:mi:ss'),
                                                                                         'YYYY' || 'MM'))
                                                                 GROUP BY SUBSTR(X.RECORD_DATE, 1, 6)) T2 ON T1.LOTWIPTIME =
                                                                                                             T2.RECORD_DATE) T3";


        private string listSQLByWeekly = @"SELECT T3.V_DATE,
                                                   T3.BOH,
                                                   T3.EOH,
                                                   T3.STAGEMOVE,
                                                   DECODE(T3.EOH, 0, 0, ROUND(T3.STAGEMOVE / T3.EOH, 2)) AS TR,
                                                   @rowNumber, @recordCount
                                              FROM (select t1.lotwiptime AS V_DATE,
                                                           t1.boh,
                                                           lead(t1.boh, 1, 0) over(order by t1.lotwiptime) AS EOH,
                                                           NVL(T2.STAGEMOVE, 0) as STAGEMOVE
        
                                                      from (select t.lotwiptime, sum(t.wip_lot_qty) as boh
                                                              from RPT_PROC_WIP_INFO_Weekly t
                                                             WHERE T.LOTTYPE = 'P' {0}
                                                               and to_NUMBER(t.lotwiptime) between
                                                                  TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW')) and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW'))
                                                             group by t.lotwiptime
                                                             order by t.lotwiptime desc) t1
                                                      LEFT JOIN (SELECT SUBSTR(X.RECORD_DATE, 1, 6) AS RECORD_DATE,
                                                                       SUM(X.MOVELOTQTY) AS STAGEMOVE
                                                                  FROM RPT_TBL_PART_INFO X
                                                                 WHERE X.LOTTYPE = 'P' {0}
                                                                   and TO_NUMBER(TO_CHAR(TO_DATE(X.RECORD_DATE,'YYYYMMDD'),'yy'||'ww')) BETWEEN
                                                                       TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW')) and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW'))                   
                                                                 GROUP BY SUBSTR(X.RECORD_DATE, 1, 6)) T2 ON T1.LOTWIPTIME =
                                                                                                             T2.RECORD_DATE) T3";
        private string listSQLByDalily = @"SELECT T3.V_DATE,
                                                   T3.BOH,
                                                   T3.EOH,
                                                   T3.STAGEMOVE,
                                                   DECODE(T3.EOH, 0, 0, ROUND(T3.STAGEMOVE / T3.EOH, 2)) AS TR,
                                                   @rowNumber, @recordCount
                                              FROM (select t1.RECORD_DATE AS V_DATE,
                                                           t1.boh,
                                                           lead(t1.boh, 1, 0) over(order by t1.RECORD_DATE) AS EOH,
                                                           NVL(T2.STAGEMOVE, 0) as STAGEMOVE
        
                                                      from (select t.RECORD_DATE, sum(t.wip_lot) as boh
                                                              from RPT_TBL_WIP_INFO_8AM t
                                                             WHERE T.LOTTYPE = 'P' {0}
                                                               and to_NUMBER(t.RECORD_DATE) between
                                                                  TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))
                                                             group by t.RECORD_DATE
                                                             order by t.RECORD_DATE desc) t1
                                                      LEFT JOIN (SELECT SUBSTR(X.RECORD_DATE, 1, 6) AS RECORD_DATE,
                                                                       SUM(X.MOVELOTQTY) AS STAGEMOVE
                                                                  FROM RPT_TBL_PART_INFO X
                                                                 WHERE X.LOTTYPE = 'P' {0}
                                                                   and TO_NUMBER(TO_CHAR(TO_DATE(X.RECORD_DATE,'YYYYMMDD'),'yy'||'ww')) BETWEEN
                                                                       TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))                  
                                                                 GROUP BY SUBSTR(X.RECORD_DATE, 1, 6)) T2 ON T1.RECORD_DATE =
                                                                                                             T2.RECORD_DATE) T3";
        private string listSQLByMonthly1 = @"SELECT T3.V_DATE,
                                                   T3.BOH,
                                                   T3.EOH,
                                                   T3.STAGEMOVE,
                                                   DECODE(T3.EOH, 0, 0, ROUND(T3.STAGEMOVE / T3.EOH, 2)) AS TR,
                                                   @rowNumber, @recordCount
                                              FROM (select t1.lotwiptime AS V_DATE,
                                                           t1.boh,
                                                           lead(t1.boh, 1, 0) over(order by t1.lotwiptime) AS EOH,
                                                           NVL(T2.STAGEMOVE, 0) as STAGEMOVE
        
                                                      from (select t.lotwiptime, sum(t.wip_lot_qty) as boh
                                                              from RPT_PROC_WIP_INFO_MONTHLY t
                                                             WHERE T.LOTTYPE <> 'P' {0}
                                                               and to_NUMBER(t.lotwiptime) between
                                                                   TO_NUMBER(TO_CHAR(to_date(:StartTime,
                                                                                             'yyyy/mm/dd hh24:mi:ss'),
                                                                                     'YYYY' || 'MM')) and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,
                                                                                             'yyyy/mm/dd hh24:mi:ss'),
                                                                                     'YYYY' || 'MM'))
                                                             group by t.lotwiptime
                                                             order by t.lotwiptime desc) t1
                                                      LEFT JOIN (SELECT SUBSTR(X.RECORD_DATE, 1, 6) AS RECORD_DATE,
                                                                       SUM(X.MOVELOTQTY) AS STAGEMOVE
                                                                  FROM RPT_TBL_PART_INFO X
                                                                 WHERE X.LOTTYPE <> 'P'{0}
                                                                   and TO_NUMBER(SUBSTR(X.RECORD_DATE, 1, 6)) BETWEEN
                                                                       TO_NUMBER(TO_CHAR(to_date(:StartTime,
                                                                                                 'yyyy/mm/dd hh24:mi:ss'),
                                                                                         'YYYY' || 'MM')) and
                                                                       TO_NUMBER(TO_CHAR(to_date(:EndTime,
                                                                                                 'yyyy/mm/dd hh24:mi:ss'),
                                                                                         'YYYY' || 'MM'))
                                                                 GROUP BY SUBSTR(X.RECORD_DATE, 1, 6)) T2 ON T1.LOTWIPTIME =
                                                                                                             T2.RECORD_DATE) T3";


        private string listSQLByWeekly1 = @"SELECT T3.V_DATE,
                                                   T3.BOH,
                                                   T3.EOH,
                                                   T3.STAGEMOVE,
                                                   DECODE(T3.EOH, 0, 0, ROUND(T3.STAGEMOVE / T3.EOH, 2)) AS TR,
                                                   @rowNumber, @recordCount
                                              FROM (select t1.lotwiptime AS V_DATE,
                                                           t1.boh,
                                                           lead(t1.boh, 1, 0) over(order by t1.lotwiptime) AS EOH,
                                                           NVL(T2.STAGEMOVE, 0) as STAGEMOVE
        
                                                      from (select t.lotwiptime, sum(t.wip_lot_qty) as boh
                                                              from RPT_PROC_WIP_INFO_Weekly t
                                                             WHERE T.LOTTYPE <> 'P' {0}
                                                               and to_NUMBER(t.lotwiptime) between
                                                                  TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW')) and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW'))
                                                             group by t.lotwiptime
                                                             order by t.lotwiptime desc) t1
                                                      LEFT JOIN (SELECT SUBSTR(X.RECORD_DATE, 1, 6) AS RECORD_DATE,
                                                                       SUM(X.MOVELOTQTY) AS STAGEMOVE
                                                                  FROM RPT_TBL_PART_INFO X
                                                                 WHERE X.LOTTYPE <> 'P' {0}
                                                                   and TO_NUMBER(TO_CHAR(TO_DATE(X.RECORD_DATE,'YYYYMMDD'),'yy'||'ww')) BETWEEN
                                                                       TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW')) and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YY' || 'WW'))                   
                                                                 GROUP BY SUBSTR(X.RECORD_DATE, 1, 6)) T2 ON T1.LOTWIPTIME =
                                                                                                             T2.RECORD_DATE) T3";
        private string listSQLByDalily1 = @"SELECT T3.V_DATE,
                                                   T3.BOH,
                                                   T3.EOH,
                                                   T3.STAGEMOVE,
                                                   DECODE(T3.EOH, 0, 0, ROUND(T3.STAGEMOVE / T3.EOH, 2)) AS TR,
                                                   @rowNumber, @recordCount
                                              FROM (select t1.RECORD_DATE AS V_DATE,
                                                           t1.boh,
                                                           lead(t1.boh, 1, 0) over(order by t1.RECORD_DATE) AS EOH,
                                                           NVL(T2.STAGEMOVE, 0) as STAGEMOVE
        
                                                      from (select t.RECORD_DATE, sum(t.wip_lot) as boh
                                                              from RPT_TBL_WIP_INFO_8AM t
                                                             WHERE T.LOTTYPE <> 'P' {0}
                                                               and to_NUMBER(t.RECORD_DATE) between
                                                                  TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))
                                                             group by t.RECORD_DATE
                                                             order by t.RECORD_DATE desc) t1
                                                      LEFT JOIN (SELECT SUBSTR(X.RECORD_DATE, 1, 6) AS RECORD_DATE,
                                                                       SUM(X.MOVELOTQTY) AS STAGEMOVE
                                                                  FROM RPT_TBL_PART_INFO X
                                                                 WHERE X.LOTTYPE <> 'P' {0}
                                                                   and TO_NUMBER(TO_CHAR(TO_DATE(X.RECORD_DATE,'YYYYMMDD'),'yy'||'ww')) BETWEEN
                                                                       TO_NUMBER(TO_CHAR(to_date(:StartTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))and
                                                                   TO_NUMBER(TO_CHAR(to_date(:EndTime,'yyyy/mm/dd hh24:mi:ss'),'YYYYMMDD'))                  
                                                                 GROUP BY SUBSTR(X.RECORD_DATE, 1, 6)) T2 ON T1.RECORD_DATE =
                                                                                                             T2.RECORD_DATE) T3";
    }
}
