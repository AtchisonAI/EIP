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
    public class ProductIndicesController : BaseController
    {

        private readonly IProductIndicesLogic _ProductIndicesLogicLogic;

        public ProductIndicesController(IProductIndicesLogic ProductIndicesLogicLogic)
        {
            _ProductIndicesLogicLogic = ProductIndicesLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("Jason")]
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
        [CreateBy("Jason")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryInfo(ProductIndicesInput InfoInput)
        {
            return JsonForGridPaging(_ProductIndicesLogicLogic.QueryInfo(InfoInput));
        }

        public JsonResult QueryInfo1(ProductIndicesInput InfoInput)
        {
            return JsonForGridPaging(_ProductIndicesLogicLogic.QueryInfo1(InfoInput));
        }

        public JsonResult QueryInfo2(ProductIndicesInput InfoInput)
        {
            return JsonForGridPaging(_ProductIndicesLogicLogic.QueryInfo2(InfoInput));
        }

        public JsonResult QueryInfo3(ProductIndicesInput InfoInput)
        {
            return JsonForGridPaging(_ProductIndicesLogicLogic.QueryInfo3(InfoInput));
        }

        public JsonResult QueryInfo4(ProductIndicesInput InfoInput)
        {
            return JsonForGridPaging(_ProductIndicesLogicLogic.QueryInfo4(InfoInput));
        }



        [CreateBy("Jason")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase StartDetails(string Date, string type, string part)
        {
            ViewBag.date = Date;
            ViewBag.type = type;
            ViewBag.part = part;
            return View();
        }

        [CreateBy("Jason")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase ScrapDetails(string Date, string type, string part)
        {
            ViewBag.date = Date;
            ViewBag.type = type;
            ViewBag.part = part;
            return View();
        }

        public ViewResultBase UnscrapDetails(string Date, string type, string part)
        {
            ViewBag.date = Date;
            ViewBag.type = type;
            ViewBag.part = part;
            return View();
        }

        public ViewResultBase HoldDetails(string Date, string type, string part)
        {
            ViewBag.date = Date;
            ViewBag.type = type;
            ViewBag.part = part;
            return View();
        }

        public ViewResultBase ReworkDetails(string Date, string type, string part)
        {
            ViewBag.date = Date;
            ViewBag.type = type;
            ViewBag.part = part;
            return View();
        }

        public JsonResult QueryDetails(SubPageInput InfoInput)
        {
            return JsonForGridPaging(_ProductIndicesLogicLogic.SubPageDetails(InfoInput));
        }


    }
}