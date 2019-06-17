using System;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.System.DataAccess.Config;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Config
{
    /// <summary>
    ///     �������ű�ҵ���߼��ӿ�ʵ��
    /// </summary>
    public class SystemArticleLogic : AsyncLogic<SystemArticle>, ISystemArticleLogic
    {
        #region ���캯��

        private readonly ISystemArticleRepository _systemArticleRepository;

        public SystemArticleLogic(ISystemArticleRepository systemArticleRepository)
            : base(systemArticleRepository)
        {
            _systemArticleRepository = systemArticleRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="model">ʵ��</param>
        /// <returns></returns>
        public async Task<OperateStatus> Save(SystemArticle model)
        {
            if (!model.ArticleId.IsEmptyGuid())
            {
                model.UpdateTime = DateTime.Now;
                model.UpdateOrganizationId = model.CreateOrganizationId;
                model.UpdateOrganizationName = model.CreateOrganizationName;
                model.UpdateUserId = model.CreateUserId;
                model.UpdateUserName = model.CreateUserName;

                var article = await GetByIdAsync(model.ArticleId);
                model.CreateTime = article.CreateTime;
                model.CreateOrganizationId = article.CreateOrganizationId;
                model.CreateOrganizationName = article.CreateOrganizationName;
                model.CreateUserId = article.CreateUserId;
                model.CreateUserName = article.CreateUserName;
                return await UpdateAsync(model);
            }
            model.ArticleId = CombUtil.NewComb();
            model.CreateTime = DateTime.Now;
            return await InsertAsync(model);
        }

        /// <summary>
        ///     �����������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveViewNums(IdInput input)
        {
            var article = await GetByIdAsync(input.Id);
            article.ViewNums += 1;
            return await UpdateAsync(article);
        }

        #endregion
    }
}