using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Dapper;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Config;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    /// <summary>
    /// ���ݿⱸ�ݲ���
    /// </summary>
    public class SystemDataBaseBackUpRepository : DapperAsyncRepository<SystemDataBaseBackUp>, ISystemDataBaseBackUpRepository
    {
        /// <summary>
        /// ��ȡ���ݿⱸ���ļ�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseBackUpOutput>> GetDataBaseBackUpOrRestore(IdInput input)
        {
            var sql = new StringBuilder();
            sql.Append("SELECT BackUpId,Name,BackUpTime,RestoreTime,[From],Size,[Path] FROM System_DataBaseBackUp WHERE DataBaseId=@id ORDER BY BackUpTime");
            return  SqlMapperUtil.SqlWithParams<SystemDataBaseBackUpOutput>(sql.ToString(), new
            {
                id = input.Id
            });
        }
    }
}
