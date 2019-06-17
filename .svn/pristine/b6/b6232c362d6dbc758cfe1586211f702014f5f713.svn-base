using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;
using System.Globalization;


namespace HiDM.Reporting.DataAccess
{
    public class ProductIndicesRepository : ReportingRepository, IProductIndicesRepository
    {
        public PagedResults GetQueryInfoList(Models.ProductIndicesInput InfoInput)
        {
            return base.PagingQueryDataTable(listSQL, InfoInput);
        }
        public PagedResults GetQueryInfoList1(Models.ProductIndicesInput InfoInput)
        {
            return base.PagingQueryDataTable(listSQL1, InfoInput);
        }
        public PagedResults GetQueryInfoList2(Models.ProductIndicesInput InfoInput)
        {
            return base.PagingQueryDataTable(listSQL2, InfoInput);
        }

        public PagedResults GetQueryInfoList3(Models.ProductIndicesInput InfoInput)
        {
            return base.PagingQueryDataTable(listSQL3, InfoInput);
        }

        public PagedResults GetQueryInfoList4(Models.ProductIndicesInput InfoInput)
        {
            return base.PagingQueryDataTable(listSQL4, InfoInput);
        }

        private string listSQL = @"SELECT t.*,  @rowNumber, @recordCount
                                      FROM (SELECT rtpi.record_date,
                                                   rtpi.lottype,
                                                   rtpi.boh,
                                                   rtpi2.boh eoh,
                                                   SUM(rtpi.movelotqty) movelotqty,
                                                   SUM(rtpi.movewaferqty) movewaferqty,
                                                   SUM(rtpi.waferstartqty) waferstartqty,
                                                   SUM(rtpi.shipqty) shipqty,
                                                   SUM(rtpi.unshipqty) unshipqty,
                                                   SUM(rtpi.bankinqty) bankinqty,
                                                   SUM(rtpi.bankoutqty) bankoutqty,
                                                   SUM(rtpi.scrapqty) scrapqty,
                                                   SUM(rtpi.unscrapqty) unscrapqty,
                                                   rtpi.yield,
                                                   SUM(rtpi.holdqty) holdqty,
                                                   SUM(rtpi.reworkqty) reworkqty
                                              FROM rpt_tbl_part_info rtpi
                                              LEFT JOIN rpt_tbl_part_info rtpi2 ON to_date(rtpi.record_date,
                                                                                           'yyyymmdd') =
                                                                                   to_date(rtpi2.record_date,
                                                                                           'yyyymmdd') + 1
                                                                               AND rtpi.lottype = rtpi2.lottype
                                             WHERE to_date(rtpi.record_date, 'yyyymmdd') BETWEEN
                                                   to_date(:starttime, 'yyyymmdd') AND
                                                   to_date(:endtime, 'yyyymmdd')
                                               AND rtpi.lottype = 'P'
                                             GROUP BY rtpi.record_date,
                                                      rtpi.lottype,
                                                      rtpi.boh,
                                                      rtpi2.boh,
                                                      rtpi.yield) t";

        private string listSQL1 = @"SELECT t.*,  @rowNumber, @recordCount
                                          FROM (SELECT rtpi.record_date,
                                                       rtpi.lottype,
                                                       rtpi.boh,
                                                       rtpi2.boh eoh,
                                                       SUM(rtpi.movelotqty) movelotqty,
                                                       SUM(rtpi.movewaferqty) movewaferqty,
                                                       SUM(rtpi.waferstartqty) waferstartqty,
                                                       SUM(rtpi.shipqty) shipqty,
                                                       SUM(rtpi.unshipqty) unshipqty,
                                                       SUM(rtpi.bankinqty) bankinqty,
                                                       SUM(rtpi.bankoutqty) bankoutqty,
                                                       SUM(rtpi.scrapqty) scrapqty,
                                                       SUM(rtpi.unscrapqty) unscrapqty,
                                                       rtpi.yield,
                                                       SUM(rtpi.holdqty) holdqty,
                                                       SUM(rtpi.reworkqty) reworkqty
                                                  FROM rpt_tbl_part_info rtpi
                                                  LEFT JOIN rpt_tbl_part_info rtpi2 ON to_date(rtpi.record_date,
                                                                                               'yyyymmdd') =
                                                                                       to_date(rtpi2.record_date,
                                                                                               'yyyymmdd') + 1
                                                                                   AND rtpi.lottype = rtpi2.lottype
                                                 WHERE to_date(rtpi.record_date, 'yyyymmdd') BETWEEN
                                                       to_date(:starttime, 'yyyymmdd') AND
                                                       to_date(:endtime, 'yyyymmdd')
                                                   AND rtpi.lottype = 'EP'
                                                 GROUP BY rtpi.record_date,
                                                          rtpi.lottype,
                                                          rtpi.boh,
                                                          rtpi2.boh,
                                                          rtpi.yield) t";

        private string listSQL2 = @"SELECT t.*,  @rowNumber, @recordCount
                                          FROM (SELECT rtpi.record_date,
                                                       rtpi.lottype,
                                                       rtpi.boh,
                                                       rtpi2.boh eoh,
                                                       SUM(rtpi.movelotqty) movelotqty,
                                                       SUM(rtpi.movewaferqty) movewaferqty,
                                                       SUM(rtpi.waferstartqty) waferstartqty,
                                                       SUM(rtpi.shipqty) shipqty,
                                                       SUM(rtpi.unshipqty) unshipqty,
                                                       SUM(rtpi.bankinqty) bankinqty,
                                                       SUM(rtpi.bankoutqty) bankoutqty,
                                                       SUM(rtpi.scrapqty) scrapqty,
                                                       SUM(rtpi.unscrapqty) unscrapqty,
                                                       rtpi.yield,
                                                       SUM(rtpi.holdqty) holdqty,
                                                       SUM(rtpi.reworkqty) reworkqty
                                                  FROM rpt_tbl_part_info rtpi
                                                  LEFT JOIN rpt_tbl_part_info rtpi2 ON to_date(rtpi.record_date,
                                                                                               'yyyymmdd') =
                                                                                       to_date(rtpi2.record_date,
                                                                                               'yyyymmdd') + 1
                                                                                   AND rtpi.lottype = rtpi2.lottype
                                                 WHERE to_date(rtpi.record_date, 'yyyymmdd') BETWEEN
                                                       to_date(:starttime, 'yyyymmdd') AND
                                                       to_date(:endtime, 'yyyymmdd')
                                                   AND rtpi.lottype = 'ET'
                                                 GROUP BY rtpi.record_date,
                                                          rtpi.lottype,
                                                          rtpi.boh,
                                                          rtpi2.boh,
                                                          rtpi.yield) t";

        private string listSQL3 = @"SELECT t.*,  @rowNumber, @recordCount
                                          FROM (SELECT rtpi.record_date,
                                                       rtpi.lottype,
                                                       rtpi.boh,
                                                       rtpi2.boh eoh,
                                                       SUM(rtpi.movelotqty) movelotqty,
                                                       SUM(rtpi.movewaferqty) movewaferqty,
                                                       SUM(rtpi.waferstartqty) waferstartqty,
                                                       SUM(rtpi.shipqty) shipqty,
                                                       SUM(rtpi.unshipqty) unshipqty,
                                                       SUM(rtpi.bankinqty) bankinqty,
                                                       SUM(rtpi.bankoutqty) bankoutqty,
                                                       SUM(rtpi.scrapqty) scrapqty,
                                                       SUM(rtpi.unscrapqty) unscrapqty,
                                                       rtpi.yield,
                                                       SUM(rtpi.holdqty) holdqty,
                                                       SUM(rtpi.reworkqty) reworkqty
                                                  FROM rpt_tbl_part_info rtpi
                                                  LEFT JOIN rpt_tbl_part_info rtpi2 ON to_date(rtpi.record_date,
                                                                                               'yyyymmdd') =
                                                                                       to_date(rtpi2.record_date,
                                                                                               'yyyymmdd') + 1
                                                                                   AND rtpi.lottype = rtpi2.lottype
                                                 WHERE to_date(rtpi.record_date, 'yyyymmdd') BETWEEN
                                                       to_date(:starttime, 'yyyymmdd') AND
                                                       to_date(:endtime, 'yyyymmdd')
                                                   AND rtpi.lottype = 'CC'
                                                 GROUP BY rtpi.record_date,
                                                          rtpi.lottype,
                                                          rtpi.boh,
                                                          rtpi2.boh,
                                                          rtpi.yield) t";

        private string listSQL4 = @"SELECT t.*,  @rowNumber, @recordCount
                                          FROM (SELECT rtpi.record_date,
                                                       rtpi.lottype,
                                                       rtpi.boh,
                                                       rtpi2.boh eoh,
                                                       SUM(rtpi.movelotqty) movelotqty,
                                                       SUM(rtpi.movewaferqty) movewaferqty,
                                                       SUM(rtpi.waferstartqty) waferstartqty,
                                                       SUM(rtpi.shipqty) shipqty,
                                                       SUM(rtpi.unshipqty) unshipqty,
                                                       SUM(rtpi.bankinqty) bankinqty,
                                                       SUM(rtpi.bankoutqty) bankoutqty,
                                                       SUM(rtpi.scrapqty) scrapqty,
                                                       SUM(rtpi.unscrapqty) unscrapqty,
                                                       rtpi.yield,
                                                       SUM(rtpi.holdqty) holdqty,
                                                       SUM(rtpi.reworkqty) reworkqty
                                                  FROM rpt_tbl_part_info rtpi
                                                  LEFT JOIN rpt_tbl_part_info rtpi2 ON to_date(rtpi.record_date,
                                                                                               'yyyymmdd') =
                                                                                       to_date(rtpi2.record_date,
                                                                                               'yyyymmdd') + 1
                                                                                   AND rtpi.lottype = rtpi2.lottype
                                                 WHERE to_date(rtpi.record_date, 'yyyymmdd') BETWEEN
                                                       to_date(:starttime, 'yyyymmdd') AND
                                                       to_date(:endtime, 'yyyymmdd')
                                                 GROUP BY rtpi.record_date,
                                                          rtpi.lottype,
                                                          rtpi.boh,
                                                          rtpi2.boh,
                                                          rtpi.yield) t";

        public PagedResults GetDetails(Models.SubPageInput InfoInput)
        {
            string filter0 = string.Empty;
            if (InfoInput.PART == "P")
            {
                filter0 = "AND fl.lottype = 'P'";
            }
            else if (InfoInput.PART == "EP")
            {
                filter0 = "AND fl.lottype = 'EP'";
            }
            else if (InfoInput.PART == "ET")
            {
                filter0 = "AND fl.lottype = 'ET'";
            }
            else if (InfoInput.PART == "CC")
            {
                filter0 = "AND fl.lottype = 'CC'";
            }
            else if (InfoInput.PART == "Total")
            {
                filter0 = "AND 1=1";
            }

            DateTime dt;
            string filter1 = string.Empty;
            string filter2 = string.Empty;
            string filter = string.Empty;
            string sql = string.Empty;

            filter1 = InfoInput.RECORD_DATE;
            

            filter2 = DateTime.ParseExact(filter1, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).AddDays(1).ToString("yyyyMMdd");


            //filter2 = filter1 + 1;
            filter1 = filter1 + "080000";
            filter2 = filter2 + "080000";

            if (InfoInput.ACTIVITY == "LotStart")
            {

                filter = "And replace(SUBSTR(HS.TXNTIMESTAMP, 0, 15),' ','') between " + "\'" + filter1 + "\'" + " and " + "\'" + filter2 + "\'" + filter0;

                 sql = string.Format(StartDetailsSQL, filter);
            }
            else if (InfoInput.ACTIVITY == "Scrap")
            {
                filter = "and replace(SUBSTR(FSL.TXNTIMESTAMP, 0, 15),' ','') between " + "\'" + filter1 + "\'" + " and " + "\'" + filter2 + "\'" + filter0;

                sql = string.Format(ScrapDetailsSQL, filter);
            }
            else if (InfoInput.ACTIVITY == "Unscrap")
            {
                filter = "and replace(SUBSTR(FUSL.TXNTIMESTAMP, 0, 15),' ','') between " + "\'" + filter1 + "\'" + " and " + "\'" + filter2 + "\'" + filter0;

                sql = string.Format(UnscrapDetailsSQL, filter);
            }
            else if (InfoInput.ACTIVITY == "Hold")
            {
                filter = "and replace(SUBSTR(HR.HOLDTIME, 0, 15),' ','') between " + "\'" + filter1 + "\'" + " and " + "\'" + filter2 + "\'" + filter0;

                sql = string.Format(HoldDetailsSQL, filter);
            }
            else if (InfoInput.ACTIVITY == "Rework")
            {
                filter = "and replace(SUBSTR(HS.TXNTIMESTAMP, 0, 15),' ','') between " + "\'" + filter1 + "\'" + " and " + "\'" + filter2 + "\'" + filter0;

                sql = string.Format(ReworkDetailsSQL, filter);
            }

            return base.PagingQueryDataTable(sql, InfoInput);

        }

        private string StartDetailsSQL = @"SELECT hs.wipid lot_id,
                                                  fl.lottype lottype,
                                                  fl.priority priority,
                                                  '0' parent_id,
                                                  fl.productname || '.' || productrevision part_id,
                                                  hs.userid event_user,
                                                  hs.txntimestamp,
                                                  hs.lotqtyout start_qty,
                                                  @rowNumber, @recordCount
                                         FROM fwwiptransaction hs
                                         LEFT JOIN fwlot fl ON hs.lotobject = fl.sysid
                                         LEFT JOIN fwwipstephistory ws ON fl.sysid = ws.lotobject
                                                                      AND ws.sysid = hs.wipstepref
                                         LEFT JOIN fwscraplot sl ON fl.sysid = sl.lotobject
                                                                AND sl.sysid = hs.wipstepref
                                        @where AND fl.lottype != 'CAR'
                                          AND fl.lottype != 'Material'
                                          AND hs.activity = 'LotStart' {0} ";



        private string ScrapDetailsSQL = @"SELECT fsl.wipid lot_id,
                                                   fl.lottype lottype,
                                                   fs.scrapqty scrap_qty,
                                                   fsp.keytype scrap_code,
                                                   fc.detaileddescription scrap_comment,
                                                   fl.priority,
                                                   fl.productname || '.' || fl.productrevision part_id,
                                                   fs.occursinstep stepid,
                                                   fsl.userid,
                                                   fsl.txntimestamp,
                                                   @rowNumber, @recordCount
                                              FROM fwscraplot fsl
                                              LEFT JOIN fwlot fl ON fsl.lotobject = fl.sysid
                                              LEFT JOIN fwscraplot_n2m fsln ON fsln.fromid = fsl.sysid
                                                                           AND fsln.linkname = 'scrapCollection'
                                              LEFT JOIN fwscrap fs ON fs.sysid = fsln.toid
                                              LEFT JOIN fwcomment fc ON fsl.txncomment = fc.sysid
                                              LEFT JOIN fwscrap_pn2m fsp ON fs.sysid = fsp.fromid
                                                                        AND fsp.linkname = 'reasons'
                                            @where {0} ";

 

        private string UnscrapDetailsSQL = @"SELECT fusl.wipid lot_id,
                                                      fl.lottype lottype,
                                                      fs.scrapqty unscrap_qty,
                                                      fsp.keytype unscrap_code,
                                                      fc.detaileddescription unscrap_comment,
                                                      fl.priority,
                                                      fl.productname || '.' || fl.productrevision part_id,
                                                      fs.occursinstep stepid,
                                                      fusl.userid,
                                                      fusl.txntimestamp, 
                                                      @rowNumber, @recordCount
                                                 FROM fwunscraplot fusl
                                                 LEFT JOIN fwlot fl ON fl.sysid = fusl.lotobject
                                                 LEFT JOIN fwunscraplot_n2m fusln ON fusln.fromid = fusl.sysid
                                                                                 AND fusln.linkname = 'scrapCollection'
                                                 LEFT JOIN fwscrap fs ON fs.sysid = fusln.toid
                                                 LEFT JOIN fwcomment fc ON fusl.txncomment = fc.sysid
                                                 LEFT JOIN fwscrap_pn2m fsp ON fs.sysid = fsp.fromid
                                                                           AND fsp.linkname = 'reasons'
                                               @where {0} ";



        private string HoldDetailsSQL = @"SELECT h.wipid lot_id,
                                                 fl.lottype lottype,
                                                 fl.priority,
                                                 fl.productname || '.' || fl.productrevision part_id,
                                                 h.lotqtyout hold_qty,
                                                 hr.reason hold_code,
                                                 hr.briefdescription hold_comment,
                                                 h.userid,
                                                 hr.holdtime txntimestamp,
                                                 @rowNumber, @recordCount
                                            FROM fwhold h
                                            LEFT JOIN fwlot fl ON fl.sysid = h.lotobject
                                            LEFT JOIN fwholdrelease hr ON h.holdrelease = hr.sysid  
                                          @where {0} ";



        private string ReworkDetailsSQL = @"SELECT hs.wipid lotid,
                                                   fl.lottype lottype,
                                                   fl.priority,
                                                   fl.productname || '.' || productrevision partid,
                                                   fwsh.stagename stage,
                                                   fwsh.handle,
                                                   fwsh.processoperationseq,
                                                   fwsh.processoperationid,
                                                   fwsh.stepseq,
                                                   fwsh.stepid stepid,
                                                   hs.lotqtyout reworkqty,
                                                   hs.txntimestamp txntimestamp, 
                                                   @rowNumber, @recordCount
                                              FROM fwwiptransaction hs
                                              LEFT JOIN fwlot fl ON hs.lotobject = fl.sysid
                                              LEFT JOIN fwwipstephistory fwsh ON fl.sysid = fwsh.lotobject
                                                                           AND fwsh.sysid = hs.wipstepref
                                             @where AND fl.lottype != 'CAR'
                                                    AND fl.lottype != 'Material'
                                                    AND hs.activity = 'Rework' {0} ";


    }

}
