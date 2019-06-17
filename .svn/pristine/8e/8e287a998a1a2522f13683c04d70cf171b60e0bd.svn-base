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
    public class MultiReleaseLotController : BaseController
    {

        private readonly IMultiReleaseLotLogic _MultiReleaseLotLogicLogic;

        public MultiReleaseLotController(IMultiReleaseLotLogic multiReleaseLotLogicLogic)
        {
            _MultiReleaseLotLogicLogic = multiReleaseLotLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("徐涛")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase List()
        {
            return View();
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("徐涛")]
        [Description("Reporting-视图-获取数据")]
        public async Task<JsonResult> QueryLotHoldInfo(LotHoldInfoInput input)
        {
            return JsonForGridPaging(await _MultiReleaseLotLogicLogic.QueryLotHoldInfo(input));
        }

        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("徐涛")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase ReleaseLotsView()
        {
            return View();
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("徐涛")]
        [Description("Reporting-视图-ReleaseLot")]
        public async Task<JsonResult> ReleaseLots(ReleaseLotInput input)
        {
            input.UserID = CurrentUser.Code;
            return Json(await _MultiReleaseLotLogicLogic.ReleaseLots(input));
        }
    }
}