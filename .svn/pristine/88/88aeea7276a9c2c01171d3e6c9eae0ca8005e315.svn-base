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
    public class EQPStatusMonitorController : BaseController
    {

        private IEQPStatusMonitorLogic _Logic;
        public EQPStatusMonitorController(IEQPStatusMonitorLogic logic)
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
        public JsonResult QueryEQPStatusMonitorData(EQPStatusMonitorInput input)
        {
            return Json(_Logic.QueryEQPStatusMonitorData(input));
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProcessLotList(EQPStatusProcessLotInput input)
        {
            return JsonForGridPaging(_Logic.GetProcessLotList(input));
        }
    }
}