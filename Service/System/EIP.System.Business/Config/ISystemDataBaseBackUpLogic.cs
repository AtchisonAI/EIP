using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Config;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Config
{
    /// <summary>
    /// ���ݿⱸ�ݲ���
    /// </summary>
    public interface ISystemDataBaseBackUpLogic : IAsyncLogic<SystemDataBaseBackUp>
    {
        /// <summary>
        /// ���ݿⱸ��
        /// </summary>
        /// <param name="doubleWay"></param>
        /// <returns></returns>
        Task<OperateStatus> SystemDataBaseBackUp(SystemDataBaseBackUpDoubleWay doubleWay);

        /// <summary>
        /// ���ݿ⻹ԭ
        /// </summary>
        /// <param name="doubleWay"></param>
        /// <returns></returns>
        Task<OperateStatus> SystemDataBaseRestore(SystemDataBaseBackUpDoubleWay doubleWay);

        /// <summary>
        /// ��ȡ���ݿⱸ����Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemDataBaseBackUpOutput>> GetDataBaseBackUpOrRestore(IdInput input);
    }
}
