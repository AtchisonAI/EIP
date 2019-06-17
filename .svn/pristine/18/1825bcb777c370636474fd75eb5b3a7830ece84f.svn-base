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
    public class ProductController : BaseController
    {

        private readonly IProductLogic _ProductLogicLogic;

        public ProductController(IProductLogic ProductLogicLogic)
        {
            _ProductLogicLogic = ProductLogicLogic;
        }
        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("Jason Xiong")]
        [Description("Reporting-视图-列表")]
        public ViewResultBase ProductInfo()
        {
            return View();
        }

        /// <summary>
        ///     读取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CreateBy("Jason Xiong")]
        [Description("Reporting-视图-获取数据")]
        public async Task<JsonResult> QueryProduct(ProductNameInput input)
        {
            return JsonForGridPaging(await _ProductLogicLogic.QueryProduct(input));
        }

    }
}