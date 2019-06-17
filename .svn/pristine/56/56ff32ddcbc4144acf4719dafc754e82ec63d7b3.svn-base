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
    public class XuTaoController : BaseController
    {

        private readonly IXuTaoLogic _XuTaoLogicLogic;

        public XuTaoController(IXuTaoLogic XuTaoLogicLogic)
        {
            _XuTaoLogicLogic = XuTaoLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("徐涛")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase Index()
        {
            return View();
        }

        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("徐涛")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase LotHistory(string lotID)
        {
            ViewBag.LotID = lotID;
            return View();
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("徐涛")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryLotInfo(XuTaoInput input)
        {
            return JsonForGridPaging(_XuTaoLogicLogic.QueryLotInfo(input));
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("徐涛")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryLotHistory(LotHistoryInput input)
        {
            return JsonForGridPaging(_XuTaoLogicLogic.QueryLotHistory(input));
        }

    }
}