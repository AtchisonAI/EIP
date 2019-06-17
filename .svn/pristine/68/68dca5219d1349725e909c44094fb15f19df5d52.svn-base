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

namespace EIP.Web.Areas.Reporting.Controllers
{
    public class EmployInfoController : BaseController
    {
        private IEmployInfoLogic iEmployInfoLogic;

        public EmployInfoController(IEmployInfoLogic employInfoLogic)
        {
            iEmployInfoLogic = employInfoLogic;
        }

        // GET: Reporting/EmployInfo
        public ActionResult EmplyInfo()
        {
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
<<<<<<< .mine
            return JsonForGridPaging(await iEmployInfoLogic.QueryEmployListAsync(Input));
        }*/

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("coder")]
        [Description("Reporting-view-getdata")]
        public JsonResult QueryEmployInfo(QueryEmployInfoInput Input)
        {
            return JsonForGridPaging(iEmployInfoLogic.QueryEmployListSync(Input));
        }
    }
}