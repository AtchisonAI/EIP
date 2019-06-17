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
    public class LotHistoryZLController : BaseController
    {

        private readonly ILotHistoryLogic _LotHistoryLogicLogic;

        public LotHistoryZLController(ILotHistoryLogic LotHistoryLogicLogic)
        {
            _LotHistoryLogicLogic = LotHistoryLogicLogic;
        }


        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("🦌")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase LotHistoryZLIndex()
        {
            return View();
        }


        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("🦌")]
        [Description("Reporting-视图-获取数据")]
        public JsonResult QueryLotHistory(LotStepHistoryInput input)
        {
            return JsonForGridPaging(_LotHistoryLogicLogic.GetLotStepHistory(input));
        }


        }

    }
