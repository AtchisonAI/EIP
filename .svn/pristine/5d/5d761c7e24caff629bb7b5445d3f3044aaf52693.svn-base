using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models;
using HiDM.Reporting.Models.EQPStatusMonitor;

namespace HiDM.Reporting.DataAccess
{
    public class EQPStatusMonitorRepository : ReportingRepository, IEQPStatusMonitorRepository
    {
        public DataTable QueryEQPStatusMonitorData(EQPStatusMonitorInput input)
        {
            string sql = string.Empty;
            if(input.IsIncludeChamber == false)
            {
                sql = string.Format(StatusMonitorSQL, input.EQPList, "/*", "*/");
            }
            else
            {
                sql = string.Format(StatusMonitorSQL, input.EQPList, " ", " ");
            }

            DataTable dtData = base.QueryDataTable(sql, input, "Result");

            return dtData;
        }

        public PagedResults GetProcessLotList(EQPStatusProcessLotInput input)
        {
            return base.PagingQueryDataTable(processLotsSQL, input);
        }

        public string StatusMonitorSQL = @"
WITH EQP AS
(SELECT SYSID, CURRENTSTATE,NAME PNAME
                      FROM FWEQPEQUIPMENT
                     WHERE NAME IN ('{0}')
                    {1}UNION
                    SELECT VALDATA, CEQP.CURRENTSTATE,EQP.NAME PNAME
                      FROM FWEQPEQUIPMENT_PN2M EN2M
                      JOIN FWEQPEQUIPMENT EQP
                        ON EQP.SYSID = EN2M.FROMID
                      JOIN FWEQPEQUIPMENT CEQP
                        ON CEQP.SYSID = EN2M.VALDATA
                       AND EN2M.LINKNAME = 'children'
                     WHERE EQP.NAME IN ('{0}'){2})

SELECT T.*, round((END_time - START_TIME) * 1440, 2) duration_mi,round((END_time - START_TIME) * 86400000, 2) duration_ms
  FROM (SELECT 
                CASE WHEN eqphis.previousstatetime > :StartTime THEN  
                  TO_DATE(substr(eqphis.previousstatetime, 0, 15),'yyyymmdd hh24miss') 
                ELSE 
                  TO_DATE(substr(:StartTime, 0, 15),'yyyymmdd hh24miss')
                END  start_time,
                CASE WHEN eqphis.time < :EndTime THEN
                    TO_DATE(substr(eqphis.time, 0, 15), 'yyyymmdd hh24miss')
                  ELSE 
                    TO_DATE(substr(:EndTime, 0, 15), 'yyyymmdd hh24miss')
                END END_time,
               eqphis.equipmentname,
               eqphis.status,
               eqphis.previousstate state,
               eqphis.EQUIPMENTID,
               STTEXT.COLOR,
                EQP.PNAME
          FROM FWEQPHISTORY eqphis
         INNER JOIN EQP
            ON EQPHIS.EQUIPMENTID = EQP.Sysid
         INNER join fabeqpequipmentext EQPEXT
            ON EQP.SYSID = EQPEXT.PARENT
         LEFT JOIN FWEQPSTATE STT
         ON eqphis.previousstate = STT.NAME
         LEFT JOIN FABEQPSTATEEXT STTEXT
         ON STT.SYSID = STTEXT.PARENT
         where EQPEXT.CONSTRUCTTYPE not in ('Port') 
         AND  ((eqphis.previousstatetime  >= :StartTime AND eqphis.previousstatetime< :EndTime)
         OR (eqphis.time  >= :StartTime AND eqphis.time< :EndTime))
        UNION ALL
        SELECT 
            CASE WHEN state.time > :StartTime THEN  
                  TO_DATE(substr(state.time, 0, 15),'yyyymmddhh24miss') 
                ELSE 
                  TO_DATE(substr(:StartTime, 0, 15),'yyyymmdd hh24miss')
                END  start_time,
               CASE WHEN SYSDATE > TO_DATE(substr(:EndTime, 0, 15), 'yyyymmdd hh24miss') THEN TO_DATE(substr(:EndTime, 0, 15), 'yyyymmdd hh24miss')
                 ELSE SYSDATE END  END_time,
               STATE.EQUIPMENTNAME,
               STATE.STATUS,
               STATE.STATE,
               EQP.SYSID EQUIPMENTID,
               STTEXT.COLOR,
                EQP.PNAME
          FROM FwEqpCurrentState STATE
         INNER JOIN EQP
            ON EQP.CURRENTSTATE = STATE.SYSID
         INNER join fabeqpequipmentext EQPEXT
            ON EQP.SYSID = EQPEXT.PARENT
         LEFT JOIN FWEQPSTATE STT
         ON STATE.STATE = STT.NAME
         LEFT JOIN FABEQPSTATEEXT STTEXT
         ON STT.SYSID = STTEXT.PARENT
         WHERE EQPEXT.CONSTRUCTTYPE not in ('Port') 
         AND state.time < :EndTime ) T
 ORDER BY PNAME ASC,EQUIPMENTNAME DESC, START_TIME
 
";


        private string processLotsSQL = @"select fto.wipid,
       fwsh.stepqty,
       lot.priority,
       fwh.Productid,
       fwh.Planid,
       fwte.subplanid,
       fwsh.stagename,
       fwsh.STEPID STEPNAME,
       fwsh.processoperationid processoperation,
       fwte.recipeid,       
       @rowNumber, @recordCount
  from fwtrackout fto
 inner join fwwipstephistory fwsh
    on fto.wipstepref = fwsh.sysid
 inner join fwwiphistory fwh
    on fto.sysid = fwh.wiptxn
  left join fwlot lot
    on fwsh.lotobject = lot.sysid
  left join fabwiptransactionext fwte
    on fto.sysid = fwte.parent
 where fwsh.location = :EQPName
   and fto.txntimestamp >= :StartTime
   and fto.txntimestamp < :EndTime";
    }
}
