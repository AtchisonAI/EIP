using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EIP.Common.Dapper;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.DataAccess.Permission
{
    public class SystemPermissionUserRepository : DapperAsyncRepository<SystemPermissionUser>,
        ISystemPermissionUserRepository
    {
        /// <summary>
        ///     �����û�Idɾ��Ȩ���û���Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<int> DeletePermissionUser(IdInput input)
        {
            const string sql = "DELETE FROM System_PermissionUser WHERE PrivilegeMasterUserId=@userId";
            return SqlMapperUtil.InsertUpdateOrDeleteSql<SystemPermissionUser>(sql, new { userId = input.Id });
        }

        /// <summary>
        ///     ��������Idɾ��Ȩ���û���Ϣ
        /// </summary>
        /// <param name="privilegeMaster">��������:��֯��������ɫ����λ�����</param>
        /// <param name="privilegeMasterValue">��������Id:��֯��������ɫ����λ�����</param>
        /// <returns></returns>
        public Task<int> DeletePermissionUser(EnumPrivilegeMaster privilegeMaster,
            Guid privilegeMasterValue)
        {
            const string sql = "DELETE FROM System_PermissionUser WHERE PrivilegeMaster=@privilegeMaster AND PrivilegeMasterValue=@privilegeMasterValue";
            return SqlMapperUtil.InsertUpdateOrDeleteSql<SystemPermissionUser>(sql,
                new
                {
                    privilegeMaster = (byte)privilegeMaster,
                    privilegeMasterValue
                });
        }

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMasterValue">��������Id:��֯��������ɫ����λ����</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        public Task<int> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            Guid privilegeMasterValue,
            EnumPrivilegeMaster privilegeMaster)
        {
            const string sql = "DELETE FROM System_PermissionUser WHERE PrivilegeMaster=@privilegeMaster AND PrivilegeMasterUserId=@privilegeMasterUserId AND PrivilegeMasterValue=@privilegeMasterValue";
            return SqlMapperUtil.InsertUpdateOrDeleteSql<SystemPermissionUser>(sql,
                new { privilegeMaster = (byte)privilegeMaster, privilegeMasterUserId, privilegeMasterValue });
        }


        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        public Task<int> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            EnumPrivilegeMaster privilegeMaster)
        {
            const string sql = "DELETE FROM System_PermissionUser WHERE PrivilegeMaster=@privilegeMaster AND PrivilegeMasterUserId=@privilegeMasterUserId";
            return SqlMapperUtil.InsertUpdateOrDeleteSql<SystemPermissionUser>(sql,
                new { privilegeMaster = (byte)privilegeMaster, privilegeMasterUserId });
        }

        /// <summary>
        ///     �����û�Idɾ���û���������
        /// </summary>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <returns></returns>
        public Task<int> DeletePermissionMaster(EnumPrivilegeMaster privilegeMaster,
            Guid privilegeMasterUserId)
        {
            const string sql = "DELETE FROM System_PermissionUser WHERE PrivilegeMaster=@privilegeMaster AND PrivilegeMasterUserId=@privilegeMasterUserId";
            return SqlMapperUtil.InsertUpdateOrDeleteSql<SystemPermissionUser>(sql,
                new { privilegeMaster = (byte)privilegeMaster, privilegeMasterUserId });
        }

        /// <summary>
        ///     �����û�Id��ȡ��ɫ���顢��λ��Ϣ
        /// </summary>
        /// <param name="input">��ԱId</param>
        /// <returns></returns>
        public Task<IEnumerable<SystemPrivilegeDetailListOutput>> GetSystemPrivilegeDetailOutputsByUserId(IdInput input)
        {
            var sql = string.Format(@"SELECT PrivilegeMaster,PrivilegeMasterValue,
                       CASE PrivilegeMaster 
                        WHEN {0} THEN --��ɫ
                        (SELECT Name FROM dbo.System_Role WHERE RoleId=PrivilegeMasterValue) 
                         WHEN {1} THEN --��
                        (SELECT Name FROM dbo.System_Group WHERE GroupId=PrivilegeMasterValue) 
                         WHEN {2} THEN --��λ
                        (SELECT Name FROM dbo.System_Post WHERE PostId=PrivilegeMasterValue)
                         WHEN {3} THEN --��֯����
                        (SELECT Name FROM dbo.System_Organization WHERE OrganizationId=PrivilegeMasterValue)
                        END Name,

                        CASE PrivilegeMaster 
                        WHEN {0} THEN --��ɫ
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT OrganizationId FROM dbo.System_Role WHERE RoleId=PrivilegeMasterValue)
                        ) 
                         WHEN {1} THEN --��
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT OrganizationId FROM dbo.System_Group WHERE GroupId=PrivilegeMasterValue) 
                        )
                         WHEN {2} THEN --��λ
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT OrganizationId FROM dbo.System_Post WHERE PostId=PrivilegeMasterValue)
                        )
                        END Organization
                        FROM dbo.System_PermissionUser WHERE PrivilegeMasterUserId=@userId AND PrivilegeMaster IN ({0},{1},{2},{3})",
                (byte)EnumPrivilegeMaster.��ɫ, (byte)EnumPrivilegeMaster.��, (byte)EnumPrivilegeMaster.��λ, (byte)EnumPrivilegeMaster.��֯����);
            return SqlMapperUtil.SqlWithParams<SystemPrivilegeDetailListOutput>(sql, new
            {
                userId = input.Id
            });
        }

        /// <summary>
        ///     ������Ȩ���ͼ���Ȩid��ȡ��Ȩ�û���Ϣ
        /// </summary>
        /// <param name="privilegeMaster">��Ȩ����</param>
        /// <param name="privilegeMasterValue">��Ȩid</param>
        /// <returns></returns>
        public Task<IEnumerable<SystemPermissionUser>> GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(
            EnumPrivilegeMaster privilegeMaster,
            Guid? privilegeMasterValue = null)
        {
            var sql =
                new StringBuilder("SELECT * FROM System_PermissionUser WHERE PrivilegeMaster=@privilegeMaster");
            if (privilegeMasterValue != null)
            {
                sql.Append(" AND PrivilegeMasterValue=@privilegeMasterValue");
            }
            return SqlMapperUtil.SqlWithParams<SystemPermissionUser>(sql.ToString(),
                new { privilegeMaster, privilegeMasterValue });
        }

        /// <summary>
        ///     ��ȡ�˵����ֶζ�Ӧӵ������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemPrivilegeDetailListOutput>> GetSystemPrivilegeDetailOutputsByAccessAndValue(
            SystemPrivilegeDetailInput input)
        {
            var sql = string.Format(@"SELECT PrivilegeMaster,
                        CASE PrivilegeMaster 
                        WHEN {0} THEN --��ɫ
                        (SELECT Name FROM dbo.System_Role WHERE RoleId=per.PrivilegeMasterValue) 
						WHEN  {1} THEN --��֯����
                        (SELECT Name FROM dbo.System_Organization WHERE OrganizationId=per.PrivilegeMasterValue) 
                         WHEN {2} THEN --��
                        (SELECT Name FROM dbo.System_Group WHERE GroupId=per.PrivilegeMasterValue) 
                         WHEN {3} THEN --��λ
                        (SELECT Name FROM dbo.System_Post WHERE PostId=per.PrivilegeMasterValue)
						WHEN  {4} THEN --��Ա
                        (SELECT Name FROM dbo.System_UserInfo WHERE UserId=per.PrivilegeMasterValue) 
                        END Name,--����

                        CASE PrivilegeMaster 
                        WHEN {0} THEN --��ɫ
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT OrganizationId FROM dbo.System_Role WHERE RoleId=per.PrivilegeMasterValue)
                        ) 
						WHEN  {1} THEN --��֯����
                        (SELECT Name FROM dbo.System_Organization WHERE OrganizationId=per.PrivilegeMasterValue) 
                         WHEN {2} THEN --��
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT OrganizationId FROM dbo.System_Group WHERE GroupId=per.PrivilegeMasterValue) 
                        )
                         WHEN {3} THEN --��λ
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT OrganizationId FROM dbo.System_Post WHERE PostId=per.PrivilegeMasterValue)
                        )
						WHEN  {4} THEN --��Ա
                        (
                        SELECT Name FROM dbo.System_Organization WHERE OrganizationId =
                        (SELECT PrivilegeMasterValue FROM System_PermissionUser u
						 WHERE  u.PrivilegeMaster={1} AND u.PrivilegeMasterUserId=per.PrivilegeMasterValue)
                        )
                        END Organization --��֯����		
                        FROM  dbo.System_Permission per
						WHERE PrivilegeAccessValue=@privilegeAccessValue AND PrivilegeAccess=@privilegeAccess AND PrivilegeMaster IN ({0},{1},{2},{3},{4})",
                (byte)EnumPrivilegeMaster.��ɫ,
                (byte)EnumPrivilegeMaster.��֯����,
                (byte)EnumPrivilegeMaster.��,
                (byte)EnumPrivilegeMaster.��λ,
                (byte)EnumPrivilegeMaster.��Ա);
            return SqlMapperUtil.SqlWithParams<SystemPrivilegeDetailListOutput>(sql, new
            {
                privilegeAccessValue = input.Id,
                privilegeAccess = (byte)input.Access
            });
        }
    }
}