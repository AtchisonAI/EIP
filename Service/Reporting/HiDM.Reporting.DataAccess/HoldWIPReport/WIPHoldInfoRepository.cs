﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess
{
    public class WIPHoldInfoRepository:ReportingRepository, IWIPHoldInfoRepository
    {
        public PagedResults GetHoldDetail(Models.DetailInput input)
        {
            return base.PagingQueryDataTable(lotHistorySQL, input);
        }

        public PagedResults GetWIPInfoList(Models.WIPHoldInfoInput input)
        {
            if (input.Location == "ALL")
            {
                return base.PagingQueryDataTable(listSQL1, input);
            }
            else {
                return base.PagingQueryDataTable(listSQL, input);
            }  
        }


        private string lotHistorySQL = @"
  SELECT lot.appid LOTID,
                       lot.currentsite,
                       lot.productname,
                       HS.Location,
                       lot.priority,
                       hd.lotqtyin,
                       lot.lottype,
                       hr.userid hold_user,
                       hr.reason holdcode,
                       hr.briefdescription,
                       nvl(to_date(substr(r.holdtime, 0, 15),
                                   'yyyymmdd hh24miss'),
                           sysdate) releasetime,
                       to_date(substr(hr.holdtime, 0, 15),
                               'yyyymmdd hh24miss') startholdtime,                  
       round((nvl(to_date(substr(r.holdtime, 0, 15), 'yyyy-mm-dd hh24:mi:ss'),sysdate) - to_date(substr(hr.holdtime, 0, 15), 'yyyy-mm-dd hh24:mi:ss'))*1440,2) holdtime,
@rowNumber, @recordCount
                  FROM fwwipstep ws
                  left join fwlot lot
                    on ws.lotobject = lot.sysid
                  LEFT JOIN FWWIPSTEPHISTORY HS
                    ON HS.WIPSTEPREF = WS.SYSID
                  left join fwwiptransaction hd
                    on hd.wipstepref = hs.sysid and (hd.sysid like '00003106.%' or hd.sysid like '00000e2b.%')
                  left join fwholdrelease hr
                    on hd.holdrelease = hr.sysid
                  left join fwholdrelease r
                    on hr.holdsysid = r.holdsysid
                   and hr.sysid != r.sysid
                 where lot.processingstatus = 'Hold' and lot.appid = :LotID
";

        
        private string listSQL = @"SELECT LOTID,
       AREA,
       PRODUCTNAME,
       STAGENAME,
       PRIORITY,
       QTY,
       ROUND(sum((releasetime - holdtime) * 24),2) holdtime,
       MAX(lastholdreason) lastholdreason,
       MAX(lastholduser) lastholduser,
       ROUND((MAX(lastreleasetime) - MAX(lastholdtime)) * 24,2) laststepholdtime,
       MAX(lastholdtime) lastholdtime,
@rowNumber, @recordCount
  FROM (SELECT LOTID,
               CURRENTSITE AREA,
               PRODUCTNAME,
               STAGENAME,
               PRIORITY,
               CURRENTQTY QTY,
               lottype,
               DECODE(maxholdtime, holdtimestring, holdreason, '') lastholdreason,
               DECODE(maxholdtime, holdtimestring, holduser, '') lastholduser,
               DECODE(maxholdtime, holdtimestring, releasetime, sysdate) lastreleasetime,
               DECODE(maxholdtime, holdtimestring, holdtime, null) lastholdtime,
               releasetime,
               holdtime
          FROM (SELECT lot.appid LOTID,
                       lot.currentsite,
                       lot.productname,
                       ws.stagename,
                       lot.priority,
                       ws.currentqty,
                       lot.lottype,
                       max(hr.holdtime) over(partition by lot.appid) maxholdtime,
                       hr.userid holduser,
                       hr.reason holdreason,
                       nvl(to_date(substr(r.holdtime, 0, 15),
                                   'yyyymmdd hh24miss'),
                           sysdate) releasetime,
                       to_date(substr(hr.holdtime, 0, 15),
                               'yyyymmdd hh24miss') holdtime,
                       hr.holdtime holdtimestring
                  FROM fwwipstep ws
                  left join fwlot lot
                    on ws.lotobject = lot.sysid
                  LEFT JOIN FWWIPSTEPHISTORY HS
                    ON HS.WIPSTEPREF = WS.SYSID
                  left join fwwiptransaction hd
                    on hd.wipstepref = hs.sysid and (hd.sysid like '00003106.%' or hd.sysid like '00000e2b.%')
                  left join fwholdrelease hr
                    on hd.holdrelease = hr.sysid
                  left join fwholdrelease r
                    on hr.holdsysid = r.holdsysid
                   and hr.sysid != r.sysid
                 where lot.processingstatus = 'Hold')) t
where t.area=:LOCATION and  t.lottype=:LOTTYPE
GROUP BY LOTID, AREA, PRODUCTNAME, STAGENAME, PRIORITY, QTY
";

        private string listSQL1 = @"SELECT LOTID,
       AREA,
       PRODUCTNAME,
       STAGENAME,
       PRIORITY,
       QTY,
       ROUND(sum((releasetime - holdtime) * 24),2) holdtime,
       MAX(lastholdreason) lastholdreason,
       MAX(lastholduser) lastholduser,
       ROUND((MAX(lastreleasetime) - MAX(lastholdtime)) * 24,2) laststepholdtime,
       MAX(lastholdtime) lastholdtime,
@rowNumber, @recordCount
  FROM (SELECT LOTID,
               CURRENTSITE AREA,
               PRODUCTNAME,
               STAGENAME,
               PRIORITY,
               CURRENTQTY QTY,
               lottype,
               DECODE(maxholdtime, holdtimestring, holdreason, '') lastholdreason,
               DECODE(maxholdtime, holdtimestring, holduser, '') lastholduser,
               DECODE(maxholdtime, holdtimestring, releasetime, sysdate) lastreleasetime,
               DECODE(maxholdtime, holdtimestring, holdtime, null) lastholdtime,
               releasetime,
               holdtime
          FROM (SELECT lot.appid LOTID,
                       lot.currentsite,
                       lot.productname,
                       ws.stagename,
                       lot.priority,
                       ws.currentqty,
                       lot.lottype,
                       max(hr.holdtime) over(partition by lot.appid) maxholdtime,
                       hr.userid holduser,
                       hr.reason holdreason,
                       nvl(to_date(substr(r.holdtime, 0, 15),
                                   'yyyymmdd hh24miss'),
                           sysdate) releasetime,
                       to_date(substr(hr.holdtime, 0, 15),
                               'yyyymmdd hh24miss') holdtime,
                       hr.holdtime holdtimestring
                  FROM fwwipstep ws
                  left join fwlot lot
                    on ws.lotobject = lot.sysid
                  LEFT JOIN FWWIPSTEPHISTORY HS
                    ON HS.WIPSTEPREF = WS.SYSID
                  left join fwwiptransaction hd
                    on hd.wipstepref = hs.sysid and (hd.sysid like '00003106.%' or hd.sysid like '00000e2b.%')
                  left join fwholdrelease hr
                    on hd.holdrelease = hr.sysid
                  left join fwholdrelease r
                    on hr.holdsysid = r.holdsysid
                   and hr.sysid != r.sysid
                 where lot.processingstatus = 'Hold')) t
where  t.lottype=:LOTTYPE and  t.area=decode(:LOCATION,'ALL', t.area,:LOCATION)
GROUP BY LOTID, AREA, PRODUCTNAME, STAGENAME, PRIORITY, QTY
";
    }
}
