using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models;

namespace HiDM.Reporting.DataAccess
{
    public class EQPGroupPerformanceRepository : ReportingRepository, IEQPGroupPerformanceRepository
    {

        string filter = string.Empty;
        string filter1 = string.Empty;
        string filter2 = string.Empty;
        string filter3 = string.Empty;
        string filter4 = string.Empty;
        string sql = string.Empty;
        public PagedResults GetEQPGroupPerformance(EQPGroupPerformanceInput Input)
        {
            if (Input.Area != null && Input.Area.Length > 0)
            {
                filter1 = string.Format("And area in ('{0}') ", Input.Area);
            }

            if (Input.EQPCap != null && Input.EQPCap.Length > 0)
            {
                filter2 = string.Format("And capability in ('{0}') ", Input.EQPCap);
            }

            if (Input.EQPType != null && Input.EQPType.Length > 0)
            {
                filter3 = string.Format("And eqptype in ('{0}') ", Input.EQPType);
            }
      
            filter = filter1+ filter2+ filter3;         

            sql = string.Format(MainPageSQL, filter);
        
            return base.PagingQueryDataTable(sql, Input);
        }


        public PagedResults GetEQPGroupWipDetail(EQPGroupPerformanceSubPageInput Input)
        {

            if (Input.AREA != null && Input.AREA.Length > 0)
            {
                filter2 = string.Format("And svp.valdata = '{0}' ", Input.AREA);
            }

            if (Input.CAPABILITY != null && Input.CAPABILITY.Length > 0)
            {
                filter3 = string.Format("And svn.requiredcapability = '{0}' ", Input.CAPABILITY);
            }

            if (Input.EQPTYPE != null && Input.EQPTYPE.Length > 0)
            {
                filter4 = string.Format("And sv.resourcetype = '{0}' ", Input.EQPTYPE);
            }

            filter = filter1 + filter2 + filter3 + filter4;

            sql = string.Format(WipDetailSQL, filter);

            return base.PagingQueryDataTable(sql, Input);
        }



        public PagedResults GetEQPGroupMoveDetail(EQPGroupPerformanceSubPageInput Input)
        {
            if (Input.RECORD_DATE != null && Input.RECORD_DATE.Length > 0)
            {
                string startTime = string.Empty;
                string endTime = string.Empty;
                startTime = Input.RECORD_DATE + " 080000000";
                endTime = DateTime.ParseExact(Input.RECORD_DATE, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddDays(1).ToString("yyyyMMdd");
                endTime = endTime + " 080000000";
                filter1 = string.Format("And hs.txntimestamp >= '{0}'  AND hs.txntimestamp < '{1}'", startTime, endTime);
            }

            if (Input.AREA != null && Input.AREA.Length > 0)
            {
                filter2 = string.Format("And svp.valdata = '{0}' ", Input.AREA);
            }

            if (Input.CAPABILITY != null && Input.CAPABILITY.Length > 0)
            {
                filter3 = string.Format("And svn.requiredcapability = '{0}' ", Input.CAPABILITY);
            }

            if (Input.EQPTYPE != null && Input.EQPTYPE.Length > 0)
            {
                filter4 = string.Format("And sv.resourcetype = '{0}' ", Input.EQPTYPE);
            }

            filter = filter1 + filter2 + filter3 + filter4;

            sql = string.Format(MoveDetailSQL, filter);

            return base.PagingQueryDataTable(sql, Input);
        }


        public PagedResults GetEQPGroupWipMoveDetail(EQPGroupPerformanceSubPageInput Input)
        {
            if (Input.RECORD_DATE != null && Input.RECORD_DATE.Length > 0)
            {
                string startTime = string.Empty;
                string endTime = string.Empty;
                startTime = Input.RECORD_DATE + " 080000000";
                endTime = DateTime.ParseExact(Input.RECORD_DATE, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddDays(1).ToString("yyyyMMdd");
                endTime = endTime + " 080000000";
                filter1 = string.Format("And m.txntimestamp >= '{0}'  AND m.txntimestamp < '{1}'", startTime, endTime);
            }

            if (Input.AREA != null && Input.AREA.Length > 0)
            {
                filter2 = string.Format("And m.area = '{0}' ", Input.AREA);
            }

            if (Input.CAPABILITY != null && Input.CAPABILITY.Length > 0)
            {
                filter3 = string.Format("And m.capability = '{0}' ", Input.CAPABILITY);
            }

            if (Input.EQPTYPE != null && Input.EQPTYPE.Length > 0)
            {
                filter4 = string.Format("And m.eqptype = '{0}' ", Input.EQPTYPE);
            }

            filter = filter1 + filter2 + filter3 + filter4;

            sql = string.Format(WipMoveDetailSQL, filter);

            return base.PagingQueryDataTable(sql, Input);
        }


        public DataTable QueryEQPGroupWipInfo(EQPGroupPerformanceSubPageInput Input)
        {
            if (Input.StartTime != null && Input.StartTime.Length > 0)
            {
                filter1 = string.Format("AND m.txntimestamp >  '{0}' AND m.txntimestamp < '{1}' ", Input.StartTime, Input.EndTime);
            }

            if (Input.AREA != null && Input.AREA.Length > 0)
            {
                filter2 = string.Format("And m.area = '{0}' ", Input.AREA);
            }

            if (Input.CAPABILITY != null && Input.CAPABILITY.Length > 0)
            {
                filter3 = string.Format("And m.capability = '{0}' ", Input.CAPABILITY);
            }

            if (Input.EQPTYPE != null && Input.EQPTYPE.Length > 0)
            {
                filter4 = string.Format("And m.eqptype = '{0}' ", Input.EQPTYPE);
            }

            filter = filter1 + filter2 + filter3 + filter4;

            sql = string.Format(WipInfoSQL, filter);

            return base.QueryDataTable(sql,"Summary", Input);
        }

        public DataTable QueryEQPGroupMoveInfo(EQPGroupPerformanceSubPageInput Input)
        {

           


            if (Input.StartTime != null && Input.StartTime.Length > 0)
            {
                filter1 = string.Format("AND m.txntimestamp >  '{0}' AND m.txntimestamp < '{1}' ", Input.StartTime,Input.EndTime);
            }
            if (Input.AREA != null && Input.AREA.Length > 0)
            {
                filter2 = string.Format("And m.area = '{0}' ", Input.AREA);
            }

            if (Input.CAPABILITY != null && Input.CAPABILITY.Length > 0)
            {
                filter3 = string.Format("And m.capability = '{0}' ", Input.CAPABILITY);
            }

            if (Input.EQPTYPE != null && Input.EQPTYPE.Length > 0)
            {
                filter4 = string.Format("And m.eqptype = '{0}' ", Input.EQPTYPE);
            }

            filter = filter1 + filter2 + filter3 + filter4;

            sql = string.Format(MoveInfoSQL, filter);

            return base.QueryDataTable(sql, "Summary", Input);
        }


        public DataTable QueryEQPGroupAvailInfo(EQPGroupPerformanceSubPageInput Input)
        {




            if (Input.StartTime != null && Input.StartTime.Length > 0)
            {


                filter1 = string.Format("AND sum_list.run_day||' 080000000' >  '{0}' AND  sum_list.run_day||' 080000000' < '{1}' ", Input.StartTime, Input.EndTime);
            }
            if (Input.AREA != null && Input.AREA.Length > 0)
            {
                filter2 = string.Format("And eqpext.area = '{0}' ", Input.AREA);
            }

            if (Input.CAPABILITY != null && Input.CAPABILITY.Length > 0)
            {
                filter3 = string.Format("And cap.capabilityname = '{0}' ", Input.CAPABILITY);
            }

            if (Input.EQPTYPE != null && Input.EQPTYPE.Length > 0)
            {
                filter4 = string.Format("And tp.name = '{0}' ", Input.EQPTYPE);
            }

            filter = filter1 + filter2 + filter3 + filter4;

            sql = string.Format(AvailInfoSQL, filter);

            return base.QueryDataTable(sql, "Summary", Input);
        }

      

        private string MainPageSQL = @"SELECT   t.record_date,
                                                   nvl(t.area, 'NULL') area,
                                                   nvl(t.capability, 'NULL') capability,
                                                   t.eqptype,
                                                   t.movelotqty,
                                                   t.maxmove,
                                                   t.avgmove,
                                                   round(decode(t.maxmove, 0, 0, t.movelotqty / t.maxmove), 2) mrate,
                                                   nvl(wip.wip, 0) wip,
                                                   wip.htime,
                                                   wip.qtime,
                                                   @rowNumber,
                                                   @recordCount
                                              FROM (SELECT record_date,
                                                           area,
                                                           capability,
                                                           eqptype,
                                                           movelotqty,
                                                           MAX(movelotqty) over(PARTITION BY area, capability, eqptype) maxmove,
                                                           round(AVG(movelotqty)
                                                                 over(PARTITION BY area, capability, eqptype),
                                                                 2) avgmove
                                                      FROM (SELECT m.record_date,
                                                                   m.area,
                                                                   m.capability,
                                                                   m.eqptype,
                                                                   SUM(m.movelotqty) movelotqty
                                                              FROM rpt_tbl_part_move m @where {0} AND m.txntimestamp > :starttime AND m.txntimestamp < :endtime 
                                                                                                  AND m.activity ='JobOut'
                                                             GROUP BY m.record_date, m.area, m.capability, m.eqptype)) t
                                              LEFT JOIN (SELECT t.area area1,
                                                                t.capability capability1,
                                                                t.eqptype eqptype1,
                                                                SUM(t.waferqty) wip,
                                                                round(SUM(t.htime) / COUNT(t.lotid), 2) htime,
                                                                round(SUM(t.qtime) / COUNT(t.lotid), 2) qtime
                                                           FROM (SELECT l.trackouttime txntimestamp,
                                                                        svp.valdata area,
                                                                        svn.requiredcapability capability,
                                                                        sv.resourcetype eqptype,
                                                                        s.location,
                                                                        l.appid lotid,
                            
                                                                        l.componentqty waferqty,
                            
                                                                        l.processingstatus status,
                                                                        fwh.holdtime,
                                                                        fwr.holdtime rlstime,
                                                                        round((nvl(to_date(substr(fwr.holdtime, 1, 15),
                                                                                           'yyyy-mm-dd hh24:mi:ss'),
                                                                                   SYSDATE) -
                                                                              to_date(substr(fwh.holdtime, 1, 15),
                                                                                       'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                                              2) htime,
                                                                        fwh.sysid,
                                                                        s.timeheresince arrivetime,
                                                                        s.trackintime jobintime,
                                                                        round((nvl(to_date(substr(s.trackintime, 1, 15),
                                                                                           'yyyy-mm-dd hh24:mi:ss'),
                                                                                   SYSDATE) -
                                                                              to_date(substr(s.timeheresince, 1, 15),
                                                                                       'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                                              2) qtime,
                                                                        s.trackouttime jobouttime,
                                                                        round((nvl(to_date(substr(s.trackouttime, 1, 15),
                                                                                           'yyyy-mm-dd hh24:mi:ss'),
                                                                                   SYSDATE) -
                                                                              to_date(substr(s.trackintime, 1, 15),
                                                                                       'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                                              2) rtime,
                                                                        fle.recipename
                                                                   FROM fwlot l
                                                                   JOIN fablotext fle ON l.extendedproperties = fle.sysid
                                                                   JOIN fwwipstep s ON l.sysid = s.lotobject
                                                                   LEFT JOIN fwstepversion sv ON s.stepname = sv.stepname
                                                                                             AND s.steprevision =
                                                                                                 sv.revision
                                                                   LEFT JOIN fwstepversion_pn2m svp ON sv.sysid =
                                                                                                       svp.fromid
                                                                                                   AND svp.keydata =
                                                                                                       'Module'
                                                                   LEFT JOIN fabstepversionext svn ON sv.sysid =
                                                                                                      svn.PARENT
                                                                   LEFT JOIN (SELECT h2.*
                                                                               FROM fwhold h2,
                                                                                    (SELECT MAX(h1.txntimestamp) txntimestamp,
                                                                                            h1.wipid
                                                                                       FROM fwhold h1
                                                                                      GROUP BY h1.wipid) t
                                                                              WHERE h2.txntimestamp = t.txntimestamp
                                                                                AND h2.wipid = t.wipid) h ON h.lotobject =
                                                                                                             l.sysid
                                                                   LEFT JOIN fwholdrelease fwh ON h.holdrelease =
                                                                                                  fwh.sysid
                                                                   LEFT JOIN fwholdrelease fwr ON fwh.holdsysid =
                                                                                                  fwr.holdsysid
                                                                                              AND fwh.sysid != fwr.sysid
                                                                                              AND fwh.holdtime !=
                                                                                                  fwr.holdtime
                                                                  WHERE l.lottype != 'CAR'
                                                                    AND l.lottype != 'Material'
                                                                    AND l.processingstatus IN
                                                                        ('Created', 'Active', 'Hold')) t
                                                          GROUP BY t.area, t.capability, t.eqptype) wip ON t.area =
                                                                                                           wip.area1
                                                                                                       AND t.capability =
                                                                                                           wip.capability1
                                                                                                       AND t.eqptype =
                                                                                                           wip.eqptype1
                                             ORDER BY t.record_date, t.area, t.capability, t.eqptype";



        private string WipDetailSQL = @"SELECT T.*, @rowNumber, @recordCount
                                              FROM (SELECT l.productname || '.' || l.productrevision productid,
                                                           l.appid lotid,
                                                           l.lottype,
                                                           sv.stagename,
                                                           l.priority,
                                                           l.componentqty waferqty,
                                                           l.processingstatus status,
                                                           svp.valdata area,
                                                           svn.requiredcapability capability,
                                                           sv.resourcetype eqptype,
                                                           s.location eqpid,
                                                           round((nvl(to_date(substr(s.trackouttime, 1, 15),
                                                                              'yyyy-mm-dd hh24:mi:ss'),
                                                                      SYSDATE) -
                                                                 to_date(substr(s.trackintime, 1, 15),
                                                                          'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                                 2) rtime,
                                                           round((nvl(to_date(substr(fwr.holdtime, 1, 15),
                                                                              'yyyy-mm-dd hh24:mi:ss'),
                                                                      SYSDATE) -
                                                                 to_date(substr(fwh.holdtime, 1, 15),
                                                                          'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                                 2) htime,
               
                                                           round((nvl(to_date(substr(s.trackintime, 1, 15),
                                                                              'yyyy-mm-dd hh24:mi:ss'),
                                                                      SYSDATE) -
                                                                 to_date(substr(s.timeheresince, 1, 15),
                                                                          'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                                 2) qtime,
                                                           fwh.briefdescription holdcomment,
                                                           fwh.reasondescription holdreason,
                                                           fle.recipename
                                                      FROM fwlot l
                                                      JOIN fablotext fle ON l.extendedproperties = fle.sysid
                                                      JOIN fwwipstep s ON l.sysid = s.lotobject
                                                      LEFT JOIN fwstepversion sv ON s.stepname = sv.stepname
                                                                                AND s.steprevision = sv.revision
                                                      LEFT JOIN fwstepversion_pn2m svp ON sv.sysid = svp.fromid
                                                                                      AND svp.keydata = 'Module'
                                                      LEFT JOIN fabstepversionext svn ON sv.sysid = svn.PARENT
                                                      LEFT JOIN (SELECT h2.*
                                                                  FROM fwhold h2,
                                                                       (SELECT MAX(h1.txntimestamp) txntimestamp,
                                                                               h1.wipid
                                                                          FROM fwhold h1
                                                                         GROUP BY h1.wipid) t
                                                                 WHERE h2.txntimestamp = t.txntimestamp
                                                                   AND h2.wipid = t.wipid) h ON h.lotobject = l.sysid
                                                      LEFT JOIN fwholdrelease fwh ON h.holdrelease = fwh.sysid
                                                      LEFT JOIN fwholdrelease fwr ON fwh.holdsysid = fwr.holdsysid
                                                                                 AND fwh.sysid != fwr.sysid
                                                                                 AND fwh.holdtime != fwr.holdtime
                                                     @where {0} AND l.lottype != 'CAR'
                                                                AND l.lottype != 'Material'
                                                                AND l.processingstatus IN
                                                                    ('Created', 'Active', 'Hold')) T
                                             ORDER BY productid, lotid
";


        private string MoveDetailSQL = @"SELECT hs.txntimestamp,
                                                   hs.wipid lotid,
                                                   l.productname || '.' || l.productrevision productid,
                                                   l.priority,
                                                   decode(hs.activity, 'JobOut', 1, 0) movelotqty,
                                                   decode(hs.activity, 'JobOut', hs.lotqtyout, 0) movewaferqty,
                                                   l.lottype,     
                                                   ws.stagename,
                                                   svp.valdata area,
                                                   svn.requiredcapability capability,
                                                   sv.resourcetype eqptype,
                                                   ws.location eqpid,
                                                   fle.recipename,
                                                   ws.timeheresince arrivetime,
                                                   ws.trackintime,
                                                   ws.trackouttime,
                                                   ws.trackinuser,
                                                   ws.trackoutuser,
                                                   round((nvl(to_date(substr(fwr.holdtime, 1, 15),
                                                                      'yyyy-mm-dd hh24:mi:ss'),
                                                              SYSDATE) -
                                                         to_date(substr(fwh.holdtime, 1, 15), 'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                         2) htime,
                                                   round((nvl(to_date(substr(s.trackintime, 1, 15),
                                                                      'yyyy-mm-dd hh24:mi:ss'),
                                                              SYSDATE) -
                                                         to_date(substr(s.timeheresince, 1, 15),
                                                                  'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                         2) qtime,
                                                   round((nvl(to_date(substr(s.trackouttime, 1, 15),
                                                                      'yyyy-mm-dd hh24:mi:ss'),
                                                              SYSDATE) -
                                                         to_date(substr(s.trackintime, 1, 15), 'yyyy-mm-dd hh24:mi:ss')) * 1440,
                                                         2) rtime,
                                                   hs.activity,
                                                   @rowNumber,
                                                   @recordCount
                                              FROM fwwiptransaction hs
                                              LEFT JOIN fwlot l ON hs.lotobject = l.sysid
                                              LEFT JOIN fablotext fle ON l.extendedproperties = fle.sysid
                                              LEFT JOIN fwwipstep s ON hs.lotobject = s.lotobject
                                              LEFT JOIN fwstepversion sv ON s.stepname = sv.stepname
                                                                        AND s.steprevision = sv.revision
                                              LEFT JOIN fwstepversion_pn2m svp ON sv.sysid = svp.fromid
                                                                              AND svp.keydata = 'Module'
                                              LEFT JOIN fabstepversionext svn ON sv.sysid = svn.PARENT
                                              LEFT JOIN (SELECT h2.*
                                                           FROM fwhold h2,
                                                                (SELECT MAX(h1.txntimestamp) txntimestamp, h1.wipid
                                                                   FROM fwhold h1
                                                                  GROUP BY h1.wipid) t
                                                          WHERE h2.txntimestamp = t.txntimestamp
                                                            AND h2.wipid = t.wipid) h ON h.lotobject = hs.lotobject
                                              LEFT JOIN fwholdrelease fwh ON h.holdrelease = fwh.sysid
                                              LEFT JOIN fwholdrelease fwr ON fwh.holdsysid = fwr.holdsysid
                                                                         AND fwh.sysid != fwr.sysid
                                                                         AND fwh.holdtime != fwr.holdtime
                                              LEFT JOIN fwwipstephistory ws ON hs.lotobject = ws.lotobject
                                                                           AND hs.wipstepref = ws.sysid
                                             @where {0} AND l.lottype != 'CAR'
                                                    AND l.lottype != 'Material'
                                                    AND l.processingstatus IN ('Created', 'Active', 'Hold')
                                                    AND hs.activity='JobOut'";







        private string WipMoveDetailSQL = @"SELECT t.record_date,
                                                   t.area,
                                                   t.capability,
                                                   t.eqptype,
                                                   t.movewaferqty,
                                                   wip.wip,
                                                   @rowNumber,
                                                   @recordCount
                                              FROM (SELECT m.record_date,
                                                           nvl(m.area, 'NULL') area,
                                                           nvl(m.capability, 'NULL') capability,
                                                           m.eqptype,
                                                           SUM(m.movewaferqty) movewaferqty
                                                      FROM rpt_tbl_part_move m
                                                     WHERE 1=1 AND m.activity = 'JobOut' {0}
                                                     GROUP BY m.record_date, m.area, m.capability, m.eqptype) t
                                              LEFT JOIN (SELECT t.area area1,
                                                                t.capability capability1,
                                                                t.eqptype eqptype1,
                                                                nvl(SUM(t.waferqty),0) wip
                                                           FROM (SELECT l.trackouttime txntimestamp,
                                                                        svp.valdata area,
                                                                        svn.requiredcapability capability,
                                                                        sv.resourcetype eqptype,
                                                                        s.location,
                                                                        l.appid lotid,
                                                                        l.componentqty waferqty,
                                                                        l.processingstatus status
                                                                   FROM fwlot l
                                                                   JOIN fwwipstep s ON l.sysid = s.lotobject
                                                                   LEFT JOIN fwstepversion sv ON s.stepname = sv.stepname
                                                                                             AND s.steprevision =
                                                                                                 sv.revision
                                                                   LEFT JOIN fwstepversion_pn2m svp ON sv.sysid =
                                                                                                       svp.fromid
                                                                                                   AND svp.keydata =
                                                                                                       'Module'
                                                                   LEFT JOIN fabstepversionext svn ON sv.sysid =
                                                                                                      svn.PARENT
                                                                  WHERE l.lottype != 'CAR'
                                                                    AND l.lottype != 'Material'
                                                                    AND l.processingstatus IN
                                                                        ('Created', 'Active', 'Hold')) t
                                                          GROUP BY t.area, t.capability, t.eqptype) wip ON t.area =
                                                                                                           wip.area1
                                                                                                       AND t.capability =
                                                                                                           wip.capability1
                                                                                                       AND t.eqptype =
                                                                                                           wip.eqptype1
                                             ORDER BY t.record_date, t.area, t.capability, t.eqptype";






    private string WipInfoSQL = @"SELECT (t.record_date||'_'||t.eqptype) NAME,
                                           nvl(wip.wip, 0) value,
                                           'WIP' Series
                                      FROM (SELECT m.record_date,
                                                   m.area,
                                                   m.capability,
                                                   m.eqptype,
                                                   SUM(m.movewaferqty) movewaferqty
                                              FROM rpt_tbl_part_move m
                                             WHERE 1=1 AND m.activity = 'JobOut' {0}
                                             GROUP BY m.record_date, m.area, m.capability, m.eqptype) t
                                      LEFT JOIN (SELECT t.area area1,
                                                        t.capability capability1,
                                                        t.eqptype eqptype1,
                                                        SUM(t.waferqty) wip
                                                   FROM (SELECT l.trackouttime txntimestamp,
                                                                svp.valdata area,
                                                                svn.requiredcapability capability,
                                                                sv.resourcetype eqptype,
                                                                s.location,
                                                                l.appid lotid,
                                                                l.componentqty waferqty,
                                                                l.processingstatus status
                                                           FROM fwlot l
                                                           JOIN fwwipstep s ON l.sysid = s.lotobject
                                                           LEFT JOIN fwstepversion sv ON s.stepname = sv.stepname
                                                                                     AND s.steprevision =
                                                                                         sv.revision
                                                           LEFT JOIN fwstepversion_pn2m svp ON sv.sysid =
                                                                                               svp.fromid
                                                                                           AND svp.keydata =
                                                                                               'Module'
                                                           LEFT JOIN fabstepversionext svn ON sv.sysid =
                                                                                              svn.PARENT
                                                          WHERE l.lottype != 'CAR'
                                                            AND l.lottype != 'Material'
                                                            AND l.processingstatus IN
                                                                ('Created', 'Active', 'Hold')) t
                                                  GROUP BY t.area, t.capability, t.eqptype) wip ON t.area =
                                                                                                   wip.area1
                                                                                               AND t.capability =
                                                                                                   wip.capability1
                                                                                               AND t.eqptype =
                                                                                                   wip.eqptype1
                                     ORDER BY t.record_date, t.area, t.capability, t.eqptype";




        private string MoveInfoSQL = @"SELECT (t.record_date||'_'||t.eqptype) NAME,
                                           t.movewaferqty value,
                                           'MOVE' Series
                                      FROM (SELECT m.record_date,
                                                   m.area,
                                                   m.capability,
                                                   m.eqptype,
                                                   SUM(m.movewaferqty) movewaferqty
                                              FROM rpt_tbl_part_move m
                                             WHERE 1=1 AND m.activity = 'JobOut' {0} 
                                             GROUP BY m.record_date, m.area, m.capability, m.eqptype) t  ";



        private string AvailInfoSQL = @"SELECT (t.run_day||'_'||t.eqptype) NAME,
                                                   (t.run + t.idle) / (decode((t.up + t.down),0,t.eqpcount*24,(t.up + t.down)))  value,
                                                   eqptype,'AVAIL' Series
                                              FROM (SELECT wm.run_day,
                                                           wm.eqpstategroup,
                                                           wm.status,
                                                           wm.eqptype,
                                                           wm.area,
                                                           wm.capabilityname,
                                                           SUM(wm.hour) hour,
                                                           nvl(decode(wm.eqpstategroup, 'RUN', SUM(wm.hour)), 0) run,
                                                           nvl(decode(wm.eqpstategroup, 'IDLE', SUM(wm.hour)), 0) idle,
                                                           nvl(decode(wm.eqpstategroup, 'LEND', SUM(wm.hour)), 0) lend,
                                                           nvl(decode(wm.eqpstategroup, 'PM', SUM(wm.hour)), 0) pm,
                                                           nvl(decode(wm.eqpstategroup, 'HOLD', SUM(wm.hour)), 0) hold,
                                                           nvl(decode(wm.eqpstategroup, 'DOWN', SUM(wm.hour)), 0) statedown,
                                                           nvl(decode(wm.status, 'T', SUM(wm.hour)), 0) up,
                                                           nvl(decode(wm.status, 'F', SUM(wm.hour)), 0) down,
                                                           COUNT(wm.equipmentname) eqpcount
                                                      FROM (SELECT sum_list.*,
                                                                   a.eqpstategroup,
                                                                   tp.name eqptype,
                                                                   eqpext.area,
                                                                   cap.capabilityname
                                                              FROM rpteqp_runtime_sum_byday sum_list
                                                              LEFT JOIN (SELECT state.name, ext.eqpstategroup
                                                                          FROM fabeqpstateext ext
                                                                          LEFT JOIN fweqpstate state ON state.sysid =
                                                                                                        ext.parent) a ON a.name =
                                                                                                                         sum_list.state
                
                                                             INNER JOIN fweqpequipment eqp ON sum_list.equipmentname =
                                                                                              eqp.name
                                                             INNER JOIN fweqptype tp ON eqp.eqptype = tp.sysid
                                                             INNER JOIN fabeqpequipmentext eqpext ON eqp.sysid =
                                                                                                     eqpext.parent
                                                             LEFT JOIN fabeqpcapability cap ON cap.parent = eqp.sysid
                                                             WHERE 1=1 {0} AND sum_list.status IS NOT NULL
                                                               AND eqpext.constructtype NOT IN ('Port', 'Chamber')) wm
                                                     GROUP BY wm.run_day,
                                                              wm.status,
                                                              wm.eqpstategroup,
                                                              wm.eqptype,
                                                              wm.area,
                                                              wm.capabilityname)t  ";
    }
}



