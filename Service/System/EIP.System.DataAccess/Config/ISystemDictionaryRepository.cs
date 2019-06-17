using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    /// <summary>
    /// �ֵ����ݷ��ʽӿ�
    /// </summary>
    public interface ISystemDictionaryRepository : IAsyncRepository<SystemDictionary>
    {
        /// <summary>
        ///     ���������ֶ���Ϣ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetDictionaryTree();

        /// <summary>
        ///     ���ݸ�����ѯ�¼�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemDictionary>> GetDictionariesParentId(IdInput input);

        /// <summary>
        ///     �����ֵ�����ȡ��Ӧ�¼�ֵ
        /// </summary>
        /// <param name="code">����ֵ</param>
        /// <returns></returns>
        Task<IEnumerable<SystemDictionary>> GetDictionaryByCode(string code);

        /// <summary>
        ///     �����ֵ�����ȡ�ֵ���Ϣ
        /// </summary>
        /// <param name="code">����ֵ</param>
        /// <returns></returns>
        Task<SystemDictionary> GetThisDictionaryByCode(string code);

        /// <summary>
        ///     ���ݴ����ȡֵ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetDictionaryTreeByCode(string code);

        /// <summary>
        ///     ����ֵ����:Ψһ�Լ��
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        Task<bool> CheckDictionaryCode(CheckSameValueInput input);
    }
}