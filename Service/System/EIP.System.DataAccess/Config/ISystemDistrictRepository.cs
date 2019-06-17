using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    public interface ISystemDistrictRepository : IAsyncRepository<SystemDistrict>
    {
        /// <summary>
        ///     ���ݸ�����ѯ�����Ӽ����νṹ
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetDistrictTreeByParentId(IdInput<string> input);

        /// <summary>
        ///     ���ݸ�����ѯ�����Ӽ�
        /// </summary>
        /// <param name="input">����Id</param>
        /// <returns></returns>
        Task<IEnumerable<SystemDistrict>> GetDistrictByParentId(IdInput<string> input);

        /// <summary>
        ///     ����ֵ����:Ψһ�Լ��
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        Task<bool> CheckDistrictId(CheckSameValueInput input);

        /// <summary>
        ///     ������Id��ȡʡ����Id
        /// </summary>
        /// <param name="input">��Id</param>
        /// <returns></returns>
        Task<SystemDistrict> GetDistrictByCountId(IdInput<string> input);
    }
}