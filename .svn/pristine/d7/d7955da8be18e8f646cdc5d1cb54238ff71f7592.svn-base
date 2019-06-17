using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public class LotStepHistoryRepository : ReportingRepository, ILotStepHistoryRepository
    {

        public PagedResults GetLotStepHistory(Models.LotStepHistoryInput input)
        {
            return base.PagingQueryDataTable(lotHistorySQL, input);
        }

        //public PagedResults GetLotInfoList(Models.XuTaoInput input)
        //{
        //    string filter = string.Empty;
        //    if (input.ProductName !=null && input.ProductName.Length > 0)
        //    {
        //        filter = string.Format("AND ProductName IN ('{0}') ", input.ProductName);
        //    }

        //    string sql = string.Format(listSQL, filter);
        //    return base.PagingQueryDataTable(sql, input);
        //}

        //public DataTable GetLotStatusSummary(Models.XuTaoInput input)
        //{
        //    string filter = string.Empty;
        //    if (input.ProductName != null && input.ProductName.Length > 0)
        //    {
        //        filter = string.Format("AND ProductName IN ('{0}') ",input.ProductName);
        //    }

        //    string sql = string.Format(summaySQL, filter);

        //    return base.QueryDataTable(sql, "Summary");
        //}

        private string lotHistorySQL = @"SELECT FWh.Productid,
       fwh.lottype,
       hd.lotqtyin Qty,
       lot.priority,
       hs.stagename Stage,
       hs.stepid Step,
       hs.stepseq,
       fwte.capability EQ_Capability,
       hs.location EQ_ID,
       hs.timeheresince arrivetime,
       hs.trackintime,
       hs.trackouttime,
        round((to_date(substr(hs.trackouttime, 0, 15), 'yyyymmdd hh24miss') -
             to_date(substr(hs.trackintime, 0, 15), 'yyyymmdd hh24miss')) * 1440,
             2) runtime,
       round((to_date(substr(hs.trackintime, 0, 15), 'yyyymmdd hh24miss') -
             to_date(substr(hs.timeheresince, 0, 15), 'yyyymmdd hh24miss')) * 1440,
             2) queuetime,
       sum(round((nvl(to_date(substr(r.holdtime, 0, 15),
                              'yyyymmdd hh24miss'),
                      sysdate) - nvl(to_date(substr(hr.holdtime, 0, 15),
                                              'yyyyMMdd HH24miss'),
                                      sysdate)) * 1440,
                 2)) HoldTime
  FROM fwwipstephistory hs
  join fwlot lot on hs.lotobject = lot.sysid
  left join fwhold hd on hd.wipstepref = hs.sysid
  left join fwholdrelease hr on hd.holdrelease = hr.sysid
  left join fwholdrelease r on hr.holdsysid = r.holdsysid
                           and hr.sysid != r.sysid   --release time
  left join FwWipHistory FWH on hd.sysid = FWH.wipTxn
  left join FabWipTransactionExt FWTE on hd.sysid = fwte.parent
where lot.appid = :LOTID
group by hs.stepid,
          hs.stepseq,
          hs.location,
          hs.stagename,
          hs.location,
          FWh.Productid,
          fwh.lottype,
          fwte.capability,
          hd.lotqtyin,
          lot.priority,
          hs.timeheresince,
          hs.trackintime,
          hs.trackouttime
order by timeheresince desc
";


//        private string listSQL = @"SELECT LOT.APPID LOTID,
//       PLANNAME,
//       PRODUCTNAME,
//       FWS.CURRENTQTY QTY,
//       STAGENAME,
//       LOT.TRANSPORTID CARRIERID,
//       STEPNAME,
//       PROCESSINGSTATUS,
//       EXTRASTATUS,       
//       @rowNumber, @recordCount
//  FROM FWLOT LOT
//  LEFT JOIN FABLOTEXT LOTEXT ON LOT.SYSID = LOTEXT.PARENT
//  LEFT JOIN FWWIPSTEP FWS
//  ON LOT.SYSID = FWS.LOTOBJECT
// @where AND LOT.LOTTYPE <> 'CAR'
//   AND LOT.LOTTYPE <> 'Material'
//   AND PLANNAME IS NOT NULL
//   AND PROCESSINGSTATUS <> 'Terminated'
//   {0}";

//        private string summaySQL = @"SELECT PRODUCTNAME Series,COUNT(*) CNT,EXTRASTATUS STATUS
//            FROM FWLOT LOT
//  LEFT JOIN FABLOTEXT LOTEXT ON LOT.SYSID = LOTEXT.PARENT
//  LEFT JOIN FWWIPSTEP FWS
//  ON LOT.SYSID = FWS.LOTOBJECT
//WHERE LOT.LOTTYPE <> 'CAR'
//   AND LOT.LOTTYPE <> 'Material'
//   AND PLANNAME IS NOT NULL
//   AND PROCESSINGSTATUS <> 'Terminated'
//   {0}
//   GROUP BY EXTRASTATUS,PRODUCTNAME";

    }
}
