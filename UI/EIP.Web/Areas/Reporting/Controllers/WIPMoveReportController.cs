using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using EIP.Common.Core.Attributes;
using EIP.Common.Core.Extensions;
using EIP.Common.Entities.Dtos;
using EIP.Common.Web;
using HiDM.Reporting.Business;
using HiDM.Reporting.Models;

namespace EIP.Web.Areas.Reporting.Controllers
{
    public class WIPMoveReportController : BaseController
    {

        private readonly IWIPMoveLogic _WIPMoveLogicLogic;

        public WIPMoveReportController(IWIPMoveLogic WIPMoveLogicLogic)
        {
            _WIPMoveLogicLogic = WIPMoveLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("Carol")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase Index()
        {
            return View();
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("Carol")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryInfo(QueryInfoInput input)
        {
            return JsonForGridPaging(_WIPMoveLogicLogic.QueryInfo(input));
        }



        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("Carol")]
        [Description("Reporting-视图-获取数据")]

        public JsonResult QueryInfo1(QueryInfoInput input)
        {
            return JsonForGridPaging(_WIPMoveLogicLogic.QueryInfo1(input));
        }

    }
}