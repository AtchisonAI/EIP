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
    public class LotHistoryController : BaseController
    {

        private readonly IZhangLuLogic _ZhangLuLogicLogic;

        public LotHistoryController(IZhangLuLogic ZhangLuLogicLogic)
        {
            _ZhangLuLogicLogic = ZhangLuLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("张露")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase Index()
        {
            return View();
        }

        public ViewResultBase HoldIndex(string HOLDRELEASE)
        {
            ViewBag.HOLDRELEASE = HOLDRELEASE;
            return View();
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("张露")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryLotHistoryInfo(ZhangLuInput input)
        {
            return JsonForGridPaging(_ZhangLuLogicLogic.QueryLotHistory(input));
        }


        public JsonResult QueryLotHoldHistoryInfo(HoldReleaseInput input)
        {
            return JsonForGridPaging(_ZhangLuLogicLogic.QueryLotHoldHistory(input));
        }

    }
}