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
    public class ScrapController : BaseController
    {

        private readonly IScrapLogic _ScrapLogicLogic;

        public ScrapController(IScrapLogic ScrapLogicLogic)
        {
            _ScrapLogicLogic = ScrapLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("LU")]
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
        [CreateBy("LU")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult Summaryscrap(ScrapInput input)
        {
            return JsonForGridPaging(_ScrapLogicLogic.Summaryscrap(input));
        }
    }
}