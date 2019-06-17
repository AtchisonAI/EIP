using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;
using System.Data;

namespace HiDM.Reporting.DataAccess.Demo
{
    public class ProductNameRepository : ReportingRepository, IProductNameRepository
    {
        private string listSQL = @"SELECT LOT.APPID LOTID,
                                   PLANNAME,
                                   PRODUCTNAME,
                                   FWS.CURRENTQTY QTY,
                                   STAGENAME,
                                   LOT.TRANSPORTID CARRIERID,
                                   STEPNAME,
                                   PROCESSINGSTATUS,
                                   EXTRASTATUS,       
                                   @rowNumber, @recordCount
                              FROM FWLOT LOT
                              LEFT JOIN FABLOTEXT LOTEXT ON LOT.SYSID = LOTEXT.PARENT
                              LEFT JOIN FWWIPSTEP FWS
                              ON LOT.SYSID = FWS.LOTOBJECT
                             @where AND LOT.LOTTYPE <> 'CAR'
                               AND LOT.LOTTYPE <> 'Material'
                               AND PLANNAME IS NOT NULL
                               AND PROCESSINGSTATUS <> 'Terminated'
                                AND PRODUCTNAME = decode(NVL(:PRODUCTNAME,' '),' ',PRODUCTNAME,:PRODUCTNAME)
";
        
     
        private string summaySQL = "SELECT COUNT(*) \"value\",EXTRASTATUS \"name\""+
                                @"  FROM FWLOT LOT
                                  LEFT JOIN FABLOTEXT LOTEXT ON LOT.SYSID = LOTEXT.PARENT
                                  LEFT JOIN FWWIPSTEP FWS
                                  ON LOT.SYSID = FWS.LOTOBJECT
                                WHERE LOT.LOTTYPE <> 'CAR'
                                   AND LOT.LOTTYPE <> 'Material'
                                   AND PLANNAME IS NOT NULL
                                   AND PROCESSINGSTATUS <> 'Terminated'
                                    AND PRODUCTNAME =  decode(NVL(:PRODUCTNAME,' '),' ',PRODUCTNAME,:PRODUCTNAME)
                                   GROUP BY EXTRASTATUS
";

        public Task<PagedResults> GetProductList(Models.ProductNameInput ProductInput)
        {
           return base.PagingQueryAsyncDataTable(listSQL,ProductInput);
        }

        public Task<DataTable> GetProductSummary(Models.ProductNameInput ProductInput)
        {
            return base.QueryAsyncDataTable(summaySQL, "Summary", ProductInput.GetManualParams());
        }
    }
}
