using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Core.Extensions;
using EIP.Common.Dapper;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    public class SystemDistrictRepository : DapperAsyncRepository<SystemDistrict>, ISystemDistrictRepository
    {
        /// <summary>
        ///     ���ݸ�����ѯ�����Ӽ����νṹ
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        public Task<IEnumerable<TreeEntity>> GetDistrictTreeByParentId(IdInput<string> input)
        {
            const string sql = "SELECT DistrictId id,name ,ParentId pid FROM System_District WHERE ParentId=@parentId";
            return  SqlMapperUtil.SqlWithParams<TreeEntity>(sql, new { parentId = input.Id });
        }

        /// <summary>
        ///     ���ݸ�����ѯ�����Ӽ�
        /// </summary>
        /// <param name="input">����Id</param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDistrict>> GetDistrictByParentId(IdInput<string> input)
        {
            const string sql = "SELECT * FROM System_District WHERE ParentId=@parentId";
            return  SqlMapperUtil.SqlWithParams<SystemDistrict>(sql, new { parentId = input.Id });
        }

        /// <summary>
        ///     ����ֵ����:Ψһ�Լ��
        /// </summary>
        /// <param name="input">Ψһ�Լ��</param>
        /// <returns></returns>
        public Task<bool> CheckDistrictId(CheckSameValueInput input)
        {
            var sql = "SELECT DistrictId FROM System_District WHERE DistrictId=@param";
            if (!input.Id.IsNullOrEmptyGuid())
            {
                sql += " AND DistrictId!=@districtId";
            }
            return SqlMapperUtil.SqlWithParamsBool<SystemDistrict>(sql, new
            {
                param = input.Param,
                districtId = input.Id
            });
        }

        /// <summary>
        ///     ������Id��ȡʡ����Id
        /// </summary>
        /// <param name="input">��Id</param>
        /// <returns></returns>
        public Task<SystemDistrict> GetDistrictByCountId(IdInput<string> input)
        {
            const string selectSql =
                "SELECT Id,ParentId,(SELECT ParentId FROM System_District WHERE DistrictId=dis.ParentId) ProvinceId FROM System_District dis WHERE DistrictId=@countId";
            return  SqlMapperUtil.SqlWithParamsSingle<SystemDistrict>(selectSql, new { countId = input.Id });
        }
    }
}