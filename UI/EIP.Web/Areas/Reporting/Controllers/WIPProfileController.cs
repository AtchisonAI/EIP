﻿using System.Collections.Generic;
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
    public class WIPProfileController : BaseController
    {

        private readonly IWIPProfileLogic _WIPProfileLogicLogic;

        public WIPProfileController(IWIPProfileLogic WIPProfileLogicLogic)
        {
            _WIPProfileLogicLogic = WIPProfileLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("Wuqi")]
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
        [CreateBy("Wuqi")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryWIPData(WIPProfileInput input)
        {
            return JsonForGridPaging(_WIPProfileLogicLogic.QueryWIPData(input));
        }



        public JsonResult QueryChartData(WIPProfileInput input)
        {
            return Json(_WIPProfileLogicLogic.GetCHART(input));
        }
        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("Wuqi")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryLotForecast(LotForecastInput input)
        {
            return JsonForGridPaging(_WIPProfileLogicLogic.QueryLotForecast(input));
        }




        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("Wuqi")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase LotForecast()
        {
            return View();
        }

    }
}