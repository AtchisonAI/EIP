using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using EIP.Common.Core.Attributes;
using EIP.Common.Core.Extensions;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using EIP.Common.Web;
using HiDM.Reporting.Business;
using HiDM.Reporting.Models.JobConfig;

namespace EIP.Web.Areas.Reporting.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    public class JobConfigController : BaseController
    {
        #region 构造函数
        private readonly IRPTTBLJOBCONFIGLogic _rPTTBLJOBCONFIGLogic;

        public JobConfigController(IRPTTBLJOBCONFIGLogic rPTTBLJOBCONFIGLogic)
        {
            _rPTTBLJOBCONFIGLogic = rPTTBLJOBCONFIGLogic;
        }
        #endregion

        #region 视图
        /// <summary>
        ///     列表
        /// </summary>
        /// <returns></returns>
        [CreateBy("孙泽伟")]
        [Description("应用系统--列表")]
        public ViewResultBase List()
        {
            return View();
        }

        /// <summary>
        ///     编辑
        /// </summary>
        /// <returns></returns>
        [CreateBy("孙泽伟")]
        [Description("应用系统--编辑")]
        public async Task<ViewResultBase> Edit(NullableIdInput input)
        {
            RPTTBLJOBCONFIG model = new RPTTBLJOBCONFIG();
            if (!input.Id.IsNullOrEmptyGuid())
            {
                model = _rPTTBLJOBCONFIGLogic.GetById(input.Id);
            }
            return View(model);
        }
        #endregion

        #region 方法

        /// <summary>
        ///     获取
        /// </summary>
        /// <returns></returns>
        [CreateBy("孙泽伟")]
        [Description("应用系统--方法-获取")]
        public JsonResult GetList()
        {
            return Json(_rPTTBLJOBCONFIGLogic.GetAllEnumerable());
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <returns></returns>
        [CreateBy("孙泽伟")]
        [Description("应用系统--方法-保存")]
        public JsonResult Save(RPTTBLJOBCONFIG model)
        {
            return Json(_rPTTBLJOBCONFIGLogic.Save(model));
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <returns></returns>
        [CreateBy("孙泽伟")]
        [Description("应用系统--方法-删除")]
        public JsonResult Delete(string id)
        {
            return Json(_rPTTBLJOBCONFIGLogic.Delete(id));
        }

        public JsonResult PagingConfigQuery(RPTJOBCONFIGPagingInput paging)
        {
            return JsonForGridPaging(_rPTTBLJOBCONFIGLogic.PagingConfigQuery(paging));
        }


        public JsonResult PagingConfigParamQuery(RPTJOBCONFIGPARAMSPagingInput paging)
        {
            return JsonForGridPaging(_rPTTBLJOBCONFIGLogic.PagingConfigParamsQuery(paging));
        }


        #endregion
    }
}
