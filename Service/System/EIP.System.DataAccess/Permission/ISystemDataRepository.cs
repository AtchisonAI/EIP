using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Permission
{
    public interface ISystemDataRepository : IAsyncRepository<SystemData>
    {
        /// <summary>
        ///     ���ݲ˵�Id��ȡ����Ȩ�޹���
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemDataDoubleWayDto>> GetDataByMenuId(NullableIdInput<Guid> input = null);
    }
}