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
    public class URD_DueDateController : BaseController
    {

        private readonly IURD_DueDateLogic _URD_DueDateLogicLogic;

        public URD_DueDateController(IURD_DueDateLogic URD_DueDateLogicLogic)
        {
            _URD_DueDateLogicLogic = URD_DueDateLogicLogic;
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
        public JsonResult QueryInfo(QueryInfoInputForDueDate input)
        {
            return JsonForGridPaging(_URD_DueDateLogicLogic.QueryInfo(input));
        }


    }
}