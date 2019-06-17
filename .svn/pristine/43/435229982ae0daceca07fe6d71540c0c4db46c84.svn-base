using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiDM.Reporting.Business.EmployInfo;
using EIP.Common.Core.Attributes;
using System.EnterpriseServices;
using System.Threading.Tasks;
using HiDM.Reporting.Models;
using EIP.Common.Web;
using HiDM.Reporting.Business;
using HiDM.Reporting.Models.EQPStatusMonitor;

namespace EIP.Web.Areas.Reporting.Controllers
{
    public class WIPWaferInOutController : BaseController
    {

        private IWIPWaferInOutRptLogic _Logic;
        public WIPWaferInOutController(IWIPWaferInOutRptLogic logic)
        {
            _Logic = logic;
        }
        // GET: Reporting/EQPStatusMonitor
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        public JsonResult QueryMonInOutInfoData(WIPWaferInOutInput input)
        {
            return Json(_Logic.GetMonInOutInfo(input));
        }

        public ViewResultBase WaferInOutDetails(string Date, string type)
        {
            ViewBag.date = Date.Replace("/","");
            ViewBag.type = type;

            return View();
        }

        public JsonResult QueryDetails(WaferInOutDetailsInput input)
        {
            return JsonForGridPaging(_Logic.QueryInfo(input));
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        public JsonResult QueryMTDInOutInfoData(WIPWaferInOutInput input)
        {
            return Json(_Logic.GetMTDInOutInfo(input));
        }
        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        //public JsonResult GetProcessLotList(WIPWaferInOutInput input)
        //{
        //    return JsonForGridPaging(_Logic.GetProcessLotList(input));
        //}
    }
}