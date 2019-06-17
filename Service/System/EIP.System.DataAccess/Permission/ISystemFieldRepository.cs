using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Paging;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Permission
{
    public interface ISystemFieldRepository : IAsyncRepository<SystemField>
    {
        /// <summary>
        ///     ���ݲ˵�Id��ȡ��Ӧ���ֶ���Ϣ
        /// </summary>
        /// <param name="fieldPagingDto">�ֶη�ҳ��Ϣ</param>
        /// <returns></returns>
        Task<PagedResults<SystemFieldOutput>> GetFieldByMenuId(SystemFieldPagingInput fieldPagingDto);
    }
}