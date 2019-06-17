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
//using HiDM.Reporting.Models.EQPGroupPerformance;

namespace EIP.Web.Areas.Reporting.Controllers
{
    public class EQPGroupPerformanceController : BaseController
    {

        private IEQPGroupPerformanceLogic _Logic;
        public EQPGroupPerformanceController(IEQPGroupPerformanceLogic logic)
        {
            _Logic = logic;
        }
        // GET: Reporting/EQPGroupPerformance
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEQPGroupPerformance(EQPGroupPerformanceInput input)
        {
            return JsonForGridPaging(_Logic.GetEQPGroupPerformance(input));
        }


        public JsonResult GetEQPGroupWipDetail(EQPGroupPerformanceSubPageInput input)
        {
            return JsonForGridPaging(_Logic.GetEQPGroupWipDetail(input));
        }

        public JsonResult GetEQPGroupMoveDetail(EQPGroupPerformanceSubPageInput input)
        {
            return JsonForGridPaging(_Logic.GetEQPGroupMoveDetail(input));
        }

        public JsonResult GetEQPGroupWipMoveDetail(EQPGroupPerformanceSubPageInput input)
        {
            return JsonForGridPaging(_Logic.GetEQPGroupWipMoveDetail(input));
        }

        public JsonResult GetEQPGroupWipMoveData(EQPGroupPerformanceSubPageInput input)
        {
            return Json(_Logic.GetEQPGroupWipMoveChart(input));
        }

        public ViewResultBase WipDetail(string DATE, string AREA, string CAPABILITY, string EQPTYPE)
        {
            ViewBag.DATE = DATE;
            ViewBag.AREA = AREA;
            ViewBag.CAPABILITY = CAPABILITY;
            ViewBag.EQPTYPE = EQPTYPE;
            return View();
        }

        public ViewResultBase MoveDetail(string DATE, string AREA, string CAPABILITY, string EQPTYPE)
        {
            ViewBag.DATE = DATE;
            ViewBag.AREA = AREA;
            ViewBag.CAPABILITY = CAPABILITY;
            ViewBag.EQPTYPE = EQPTYPE;
            return View();
        }


        public ViewResultBase WipMoveDetail(string DATE, string AREA, string CAPABILITY, string EQPTYPE ,string StartTime, string EndTime)
        {
            ViewBag.DATE = DATE;
            ViewBag.AREA = AREA;
            ViewBag.CAPABILITY = CAPABILITY;
            ViewBag.EQPTYPE = EQPTYPE;
            ViewBag.StartTime = StartTime;
            ViewBag.EndTime = EndTime;
            return View();
        }

    }
}