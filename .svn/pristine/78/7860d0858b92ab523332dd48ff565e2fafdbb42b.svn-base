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
    public class HoldWIPReportController : BaseController
    {

        private readonly IHoldWIPLogic _HoldWIPLogicLogic;

        public HoldWIPReportController(IHoldWIPLogic HoldWIPLogicLogic)
        {
            _HoldWIPLogicLogic = HoldWIPLogicLogic;
        }

        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("吴奇")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase Index()
        {
            return View();
        }

        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("吴奇")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase Detail(string lotID)
        {
            ViewBag.LotID = lotID;
            
            return View();
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("吴奇")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryWIPInfo(WIPHoldInfoInput input)
        {
            return JsonForGridPaging(_HoldWIPLogicLogic.QueryWIPInfo(input));
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("吴奇")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryLotDetail(DetailInput input)
        {
            return JsonForGridPaging(_HoldWIPLogicLogic.QueryLotDetail(input));
        }




    }
}