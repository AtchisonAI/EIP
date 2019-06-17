using System.Web.Mvc;
using EIP.Common.Core.Attributes;
using System.EnterpriseServices;
using HiDM.Reporting.Models;
using EIP.Common.Web;
using HiDM.Reporting.Business;

namespace EIP.Web.Areas.Reporting.Controllers
{
    public class EQPDaliyReportController : BaseController
    {
        private IEQPDaliyReportLogic iEQPDailyReportLogic;

        public EQPDaliyReportController(IEQPDaliyReportLogic iLogic)
        {
            iEQPDailyReportLogic = iLogic;
        }
        // GET: Reporting/EQPDaliyReport
        public ActionResult GetEQPDaliyReport()
        {
            return View();
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("coder")]
        [Description("Reporting-view-getdata")]
        public JsonResult GetEQPDaliyReport(EQPDailyReportInput input)
        {
            return JsonForGridPaging(iEQPDailyReportLogic.GetEQPDailyReportSync(input));
        }
    }
}