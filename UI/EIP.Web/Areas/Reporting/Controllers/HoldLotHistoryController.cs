﻿using System;
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
    public class HoldLotHistoryController : BaseController
    {
        private IHoldLotHistoryLogic iHoldLotHistoryLogic;

        public HoldLotHistoryController(IHoldLotHistoryLogic holdLotHistoryLogic)
        {
            iHoldLotHistoryLogic = holdLotHistoryLogic;
        }

        // GET: Reporting/HoldLotHistory
        public ActionResult HoldLotHistory(string beginDate, string endDate)
        {
            ViewBag.beginDate = beginDate;
            ViewBag.endDate = endDate;
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
                    return JsonForGridPaging(await iEmployInfoLogic.QueryEmployListAsync(Input));
                }*/

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("coder")]
        [Description("Reporting-view-getdata")]
        public JsonResult QueryHoldLotHistory(HoldLotHistoryInput Input)
        {
            return JsonForGridPaging(iHoldLotHistoryLogic.QueryHoldLotHistoryListSync(Input));
        }
    }
}