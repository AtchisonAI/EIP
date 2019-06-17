using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Config
{
    public interface ISystemDistrictLogic : IAsyncLogic<SystemDistrict>
    {
        /// <summary>
        ///     ���ݸ�����ѯ�����Ӽ����νṹ
        /// </summary>
        /// <param name="input">����Id</param>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetDistrictTreeByParentId(IdInput<string> input);

        /// <summary>
        ///     ���ݸ�����ѯ�����Ӽ�
        /// </summary>
        /// <param name="input">����Id</param>
        /// <returns></returns>
        Task<IEnumerable<SystemDistrict>> GetDistrictByParentId(IdInput<string> input);

        /// <summary>
        ///     ������Id��ȡʡ����Id
        /// </summary>
        /// <param name="input">��Id</param>
        /// <returns></returns>
        Task<SystemDistrict> GetDistrictByCountId(IdInput<string> input);

        /// <summary>
        ///     �������Ƿ��Ѿ������ظ���
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        Task<OperateStatus> CheckDistrictId(CheckSameValueInput input);

        /// <summary>
        ///     ����ʡ������Ϣ
        /// </summary>
        /// <param name="systemDistrict">ʡ������Ϣ</param>
        /// <returns></returns>
        Task<OperateStatus> SaveDistrict(SystemDistrict systemDistrict);

        /// <summary>
        ///     ɾ��ʡ���ؼ��¼�����
        /// </summary>
        /// <param name="input">����id</param>
        /// <returns></returns>
        Task<OperateStatus> DeleteDistrict(IdInput<string> input);
    }
}