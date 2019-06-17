using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Core.Extensions;
using EIP.Common.Dapper;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    /// <summary>
    ///     �ֵ����ݷ��ʽӿ�ʵ��
    /// </summary>
    public class SystemDictionaryRepository : DapperAsyncRepository<SystemDictionary>, ISystemDictionaryRepository
    {
        /// <summary>
        ///     ���������ֶ���Ϣ
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetDictionaryTree()
        {
            var sql = new StringBuilder();
            sql.Append("SELECT DictionaryId id,ParentId pId,name,code FROM System_Dictionary ORDER BY OrderNo");
            return  SqlMapperUtil.SqlWithParams<TreeEntity>(sql.ToString());
        }

        /// <summary>
        ///     ���ݸ�����ѯ�¼�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDictionary>> GetDictionariesParentId(IdInput input)
        {
            var sql = new StringBuilder();
            sql.Append("SELECT * FROM System_Dictionary WHERE ParentId=@pId ORDER BY OrderNo");
            return  SqlMapperUtil.SqlWithParams<SystemDictionary>(sql.ToString(), new { pId = input.Id });
        }

        /// <summary>
        ///     �����ֵ�����ȡ��Ӧ�¼�ֵ
        /// </summary>
        /// <param name="code">����ֵ</param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDictionary>> GetDictionaryByCode(string code)
        {
            var sql = new StringBuilder();
            sql.Append(
                "SELECT DictionaryId,Name FROM dbo.System_Dictionary WHERE ParentId IN (SELECT DictionaryId FROM dbo.System_Dictionary WHERE Code=@code) ORDER BY dbo.System_Dictionary.OrderNo");
            return  SqlMapperUtil.SqlWithParams<SystemDictionary>(sql.ToString(), new { code });
        }

        /// <summary>
        ///     ����ֵ����:Ψһ�Լ��
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        public Task<bool> CheckDictionaryCode(CheckSameValueInput input)
        {
            var sql = "SELECT DictionaryId FROM System_Dictionary WHERE Code=@param";
            if (!input.Id.IsNullOrEmptyGuid())
            {
                sql += " AND DictionaryId!=@dictionaryId";
            }
            return SqlMapperUtil.SqlWithParamsBool<SystemDictionary>(sql, new
            {
                param = input.Param,
                dictionaryId = input.Id
            });
        }

        /// <summary>
        ///     �����ֵ�����ȡ�ֵ���Ϣ
        /// </summary>
        /// <param name="code">����ֵ</param>
        /// <returns></returns>
        public Task<SystemDictionary> GetThisDictionaryByCode(string code)
        {
            const string sql = "SELECT * FROM System_Dictionary WHERE Code=@param";
            return  SqlMapperUtil.SqlWithParamsSingle<SystemDictionary>(sql, new
            {
                param = code
            });
        }

        /// <summary>
        /// ��ȡ
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetDictionaryTreeByCode(string code)
        {
            var sql = new StringBuilder();
            sql.Append(@"SELECT DictionaryId id,ParentId pId,name,code FROM System_Dictionary WHERE Code like '" + (code + "_").Replace("_", @"\_") + "%" + "' escape '\\' OR Code ='" + code + "' ORDER BY OrderNo");
            return  SqlMapperUtil.SqlWithParams<TreeEntity>(sql.ToString());
        }
    }
}