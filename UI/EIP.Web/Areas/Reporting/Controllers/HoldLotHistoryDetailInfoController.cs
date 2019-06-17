using System.Web.Mvc;
using EIP.Common.Core.Attributes;
using System.EnterpriseServices;
using HiDM.Reporting.Models;
using EIP.Common.Web;
using HiDM.Reporting.Business;

namespace EIP.Web.Areas.Reporting.Controllers
{
    public class HoldLotHistoryDetailInfoController : BaseController
    {
        private IHoldLotHistoryLogic iHoldLotHistoryLogic;

        public HoldLotHistoryDetailInfoController(IHoldLotHistoryLogic holdLotHistoryLogic)
        {
            iHoldLotHistoryLogic = holdLotHistoryLogic;
        }

        // GET: Reporting/HoldLotHistory
        public ActionResult HoldLotHistoryDetail(string moduleCode,string beginDate,string endDate,string analysisUnit)
        {
            ViewBag.ModuleCode = moduleCode;
            ViewBag.beginDate = beginDate;
            ViewBag.endDate = endDate;
            ViewBag.analysisUnit = analysisUnit;
            return View();
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        /*        [HttpPost]
                [CreateBy("coder")]
                [Description("Reporting-view-getdata")]
                public async Task<JsonResult> QueryEmployInfo(QueryEmployInfoInput Input)
                {
                    return JsonForGridPaging(await iEmployInfoLogic.QueryEmployListAsync(Input));
                }*/

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("coder")]
        [Description("Reporting-view-getdata")]
        public JsonResult QueryHoldLotHistoryDetailInfo(HoldLotHistoryInput Input)
        {
            return JsonForGridPaging(iHoldLotHistoryLogic.QueryHoldLotHistoryListSync(Input));
        }
    }
}