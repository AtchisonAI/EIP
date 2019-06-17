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
    public class EQPUpTimeRptController : BaseController
    {
        private readonly IEQPUpTimeTotalLogic _EQPUpTimeTotal;

        public EQPUpTimeRptController(IEQPUpTimeTotalLogic EQPUpTimeTotal)
        {
            _EQPUpTimeTotal = EQPUpTimeTotal;
        }

        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("lwf")]
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
        [CreateBy("lwf")]
        [global::System.ComponentModel.Description("Reporting-视图-获取年度数据")]
        public JsonResult QueryYearTotalInfo(QueryTotalInput input)
        {
            return JsonForGridPaging(_EQPUpTimeTotal.QueryYearTotalInfo(input));
        }



        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("lwf")]
        [global::System.ComponentModel.Description("Reporting-视图-获取12个月的数据")]
        public JsonResult QueryMonthTotalInfo(QueryTotalInput input)
        {
            return JsonForGridPaging(_EQPUpTimeTotal.QueryMonthTotalInfo(input));
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("lwf")]
        [global::System.ComponentModel.Description("Reporting-视图-获取单状态数据")]
        public JsonResult QuerySingleInfo(QueryTotalInput input)
        {
            return JsonForGridPaging(_EQPUpTimeTotal.QuerySingleInfo(input));
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("lwf")]
        [global::System.ComponentModel.Description("Reporting-视图-获取数据单台设备")]
        public JsonResult QueryToolInfo(QueryTotalInput input)
        {
            return JsonForGridPaging(_EQPUpTimeTotal.QueryToolInfo(input));
        }

    }
}