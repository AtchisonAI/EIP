﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Dapper;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Config;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Config
{
    /// <summary>
    ///     数据库操作接口实现
    /// </summary>
    public class SystemDataBaseRepository : DapperAsyncRepository<SystemDataBase>, ISystemDataBaseRepository
    {
        private SqlMapperUtil _CurrentSelectedDB;

        #region 外键Sql
        const string FkSql = @"SELECT
                    ThisTable  = FK.TABLE_NAME,
                    ThisColumn = CU.COLUMN_NAME,
                    OtherTable  = PK.TABLE_NAME,
                    OtherColumn = PT.COLUMN_NAME, 
                    Constraint_Name = C.CONSTRAINT_NAME,
                    Owner = FK.TABLE_SCHEMA
                FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                INNER JOIN
                    (	
                        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
                        FROM  INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                    ) 
                PT ON PT.TABLE_NAME = PK.TABLE_NAME
                WHERE FK.Table_NAME=@tableName OR PK.Table_NAME=@tableName";
        #endregion

        #region 表Sql
        const string TableSqlSqlServer = @"SELECT tbs.name TableName,ds.value Description ,crdate CreateTime
                                    FROM  sysobjects tbs
                                    LEFT JOIN  sys.extended_properties ds ON ds.major_id=tbs.id AND ds.minor_id=0
                                    WHERE   xtype='U' ORDER BY tbs.name";

        const string TableSqlOracle = @"
SELECT OBJECT_NAME TableName,CMT.COMMENTS Description,CREATED CreateTime FROM user_objects UO
LEFT JOIN user_tab_comments CMT
ON UO.OBJECT_NAME = CMT.table_name where object_type = 'TABLE' ORDER BY OBJECT_NAME";
        #endregion

        #region 列Sql
        const string ColumnSqlSqlServer = @"SELECT 
		        columns.TABLE_CATALOG AS [Database],
		        columns.TABLE_SCHEMA AS Owner, 
		        columns.TABLE_NAME AS TableName, 
		        columns.COLUMN_NAME AS ColumnName, 
		        columns.ORDINAL_POSITION AS OrdinalPosition, 
		        columns.COLUMN_DEFAULT AS DefaultSetting, 
		        columns.IS_NULLABLE AS IsNullable, columns.DATA_TYPE AS DataType, 
		        columns.CHARACTER_MAXIMUM_LENGTH AS MaxLength, 
		        columns.DATETIME_PRECISION AS DatePrecision,
		        COLUMNPROPERTY(object_id(columns.TABLE_SCHEMA + '.' + TABLE_NAME), columns.COLUMN_NAME, 'IsIdentity') AS IsIdentity,
		        COLUMNPROPERTY(object_id(columns.TABLE_SCHEMA + '.' + TABLE_NAME), columns.COLUMN_NAME, 'IsComputed') as IsComputed,
		        properties.value   as   ColumnDescription  
	        FROM  INFORMATION_SCHEMA.COLUMNS columns 
	        LEFT   join   sys.extended_properties   properties   
	          ON   object_Id(columns.Table_Name)   =   properties.major_id   
	          AND   columns.Ordinal_position   =   properties.minor_id
	          WHERE columns.TABLE_NAME = @tablename
	        ORDER BY OrdinalPosition ASc";

        const string ColumnSqlOracle = " SELECT '{0}' \"DataBase\","+ @"
        '{1}' Owner,
        CCMT.TABLE_NAME TableName,
        COL.COLUMN_NAME AS ColumnName,
        COL.COLUMN_ID AS OrdinalPosition,
        DATA_DEFAULT DefaultSetting,
        NULLABLE IsNullable,
        DATA_TYPE DataType,
        DATA_LENGTH MaxLength,
        0 DatePrecision,
        0 IsIdentity,
        0 IsComputed,
        CCMT.comments ColumnDescription
   FROM USER_COL_COMMENTS CCMT, USER_TAB_COLUMNS COL
  WHERE COL.TABLE_NAME = :tablename -- CM_USER的表
 AND
  COL.TABLE_NAME = CCMT.TABLE_NAME
  AND COL.COLUMN_NAME = CCMT.COLUMN_NAME ORDER BY COLUMN_ID ASC";
        #endregion

        /// <summary>
        /// 查看对应数据库空间占用情况
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseSpaceOutput>> GetDataBaseSpaceused(IdInput input)
        {
            ResetConnection(input);
            const string procName = @"System_Proc_Spaceused";
            return _CurrentSelectedDB.StoredProcWithParams<SystemDataBaseSpaceOutput>(procName, null, false);
        }

        /// <summary>
        /// 获取对应数据库表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseTableDoubleWay>> GetDataBaseTables(IdInput input)
        {
            ResetConnection(input);
            if (_CurrentSelectedDB.ProviderName.IndexOf("Oracle") >= 0)
                return _CurrentSelectedDB.SqlWithParams<SystemDataBaseTableDoubleWay>(TableSqlOracle);
            else
                return _CurrentSelectedDB.SqlWithParams<SystemDataBaseTableDoubleWay>(TableSqlSqlServer);
        }

        /// <summary>
        /// 获取对应表列信息
        /// </summary>
        /// <param name="doubleWayDto"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseColumnDoubleWay>> GetDataBaseColumns(SystemDataBaseTableDoubleWay doubleWayDto)
        {
            var dataBase  = ResetConnection(doubleWayDto);
            if (_CurrentSelectedDB.ProviderName.IndexOf("Oracle") >= 0)
                return _CurrentSelectedDB.SqlWithParams<SystemDataBaseColumnDoubleWay>(ColumnSqlOracle, new { tablename = doubleWayDto.TableName });
            else
            {
                string sql = string.Format(ColumnSqlOracle, dataBase.CatalogName, dataBase.UserId);
                return _CurrentSelectedDB.SqlWithParams<SystemDataBaseColumnDoubleWay>(ColumnSqlSqlServer, new { tablename = doubleWayDto.TableName });
            }
        }

        /// <summary>
        /// 获取外键信息
        /// </summary>
        /// <param name="doubleWayDto"></param>
        /// <returns></returns>
        public Task<IEnumerable<SystemDataBaseFkColumnOutput>> GetdatabsefFkColumn(SystemDataBaseTableDoubleWay doubleWayDto)
        {
            return _CurrentSelectedDB.SqlWithParams<SystemDataBaseFkColumnOutput>(FkSql);
        }

        /// <summary>
        /// 重置连接字符串
        /// </summary>
        /// <param name="input"></param>
        public SystemDataBase ResetConnection(IdInput input)
        {
            const string sql = "SELECT * FROM System_DataBase WHERE DataBaseId=@id";
            SystemDataBase dataBase = Task.Run(async () => await SqlMapperUtil.SqlWithParamsSingle<SystemDataBase>(sql, new { id = input.Id })).Result;
            _CurrentSelectedDB = new SqlMapperUtil(dataBase.ConnectionString,dataBase.ProviderName);

            return dataBase;
        }
    }
}