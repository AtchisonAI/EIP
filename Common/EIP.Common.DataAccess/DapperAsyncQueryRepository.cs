using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Dapper;
using EIP.Common.Entities.Paging;
using System.Data;

namespace EIP.Common.DataAccess
{
    /// <summary>
    ///     DapperAsyncQueryRepository仓储,T代表实体信息,规范约束为T必须继承IEntityBase接口
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public class DapperQueryRepository : BaseRepository, IAsyncQueryRepository
    {

        public DapperQueryRepository()
            : base()
        {

        }

        public DapperQueryRepository(string connectionName)
            : base(connectionName)
        {

        }

        #region 异步查询

        public virtual Task<IEnumerable<T>> QueryAsync<T>(string querySql, dynamic parms =null)
        {
            return SqlMapperUtil.SqlWithParams<T>(querySql, parms);
        }

        public virtual Task<DataTable> QueryAsyncDataTable(string querySql, string tableName = "Result")
        {
            return SqlMapperUtil.SqlWithParamsDataTable(querySql, tableName);
        }


        public virtual Task<DataTable> QueryAsyncDataTable(string querySql, QueryParam queryParam, string tableName = "Result")
        {
            return SqlMapperUtil.SqlWithParamsDataTable(querySql, tableName,  queryParam.GetManualParams() );
        }

        public virtual Task<DataTable> QueryAsyncDataTable(string querySql, string tableName, dynamic parms = null)
        {
            return SqlMapperUtil.SqlWithParamsDataTable(querySql, tableName, parms);
        }

        public virtual Task<IEnumerable<dynamic>> QueryAsync(string querySql, dynamic parms = null)
        {
            return SqlMapperUtil.SqlWithParamsDynamic(querySql, parms);
        }


        /// <summary>
        ///     复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        ///     注意事项：
        ///     1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        ///     2.实体中需增加扩展属性，作记录总数输出：RecordCount
        ///     3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        ///     4.示例参考:
        /// </remarks>
        public virtual Task<PagedResults> PagingQueryAsyncDataTable(string querySql, QueryParam queryParam)
        {
            return SqlMapperUtil.PagingQueryAsyncDataTable(querySql, queryParam);
        }



        /// <summary>
        ///     复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        ///     注意事项：
        ///     1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        ///     2.实体中需增加扩展属性，作记录总数输出：RecordCount
        ///     3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        ///     4.示例参考:
        /// </remarks>
        public virtual Task<PagedResults<T>> PagingQueryAsync<T>(string querySql, QueryParam queryParam)
        {
            return SqlMapperUtil.PagingQueryAsync<T>(querySql, queryParam);
        }

        /// <summary>
        ///     复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        ///     注意事项：
        ///     1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        ///     2.实体中需增加扩展属性，作记录总数输出：RecordCount
        ///     3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        ///     4.示例参考:
        /// </remarks>
        public virtual Task<PagedResults<dynamic>> PagingQueryAsyncDynamic(string querySql, QueryParam queryParam)
        {
            return SqlMapperUtil.PagingQueryAsyncDynamic(querySql, queryParam);
        }

        public virtual Task<T> GetDetailAsync<T>(string querySql, dynamic queryParam = null)
        {

            return SqlMapperUtil.SqlWithParamsSingle<T>(querySql, queryParam);
        }
        #endregion



        #region 同步查询

        public virtual IEnumerable<T> Query<T>(string querySql, dynamic parms = null)
        {
            return SqlMapperUtil.SqlWithParams<T>(querySql, parms);
        }

        public virtual DataTable QueryDataTable(string querySql, string tableName = "Result", dynamic parms = null)
        {
            return SqlMapperUtil.SqlWithParamsDataTableSync(querySql, tableName, parms);
        }

        public virtual DataTable QueryDataTable(string querySql, string tableName = "Result")
        {
            return SqlMapperUtil.SqlWithParamsDataTableSync(querySql, tableName);
        }


        public virtual DataTable QueryDataTable(string querySql, QueryParam queryParam, string tableName = "Result")
        {
            return SqlMapperUtil.SqlWithParamsDataTableSync(querySql, tableName, queryParam.GetManualParams());
        }


        public virtual IEnumerable<dynamic> Query(string querySql, dynamic parms = null)
        {
            return SqlMapperUtil.SqlWithParamsDynamic(querySql, parms).Results;
        }


        /// <summary>
        ///     复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        ///     注意事项：
        ///     1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        ///     2.实体中需增加扩展属性，作记录总数输出：RecordCount
        ///     3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        ///     4.示例参考:
        /// </remarks>
        public virtual PagedResults PagingQueryDataTable(string querySql, QueryParam queryParam)
        {
            return SqlMapperUtil.PagingQueryAsyncDataTable(querySql, queryParam).Result;
        }



        /// <summary>
        ///     复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        ///     注意事项：
        ///     1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        ///     2.实体中需增加扩展属性，作记录总数输出：RecordCount
        ///     3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        ///     4.示例参考:
        /// </remarks>
        public virtual PagedResults<T> PagingQuery<T>(string querySql, QueryParam queryParam)
        {
            return SqlMapperUtil.PagingQueryAsync<T>(querySql, queryParam).Result;
        }

        /// <summary>
        ///     复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        ///     注意事项：
        ///     1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        ///     2.实体中需增加扩展属性，作记录总数输出：RecordCount
        ///     3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        ///     4.示例参考:
        /// </remarks>
        public virtual PagedResults<dynamic> PagingQueryDynamic(string querySql, QueryParam queryParam)
        {
            return SqlMapperUtil.PagingQueryAsyncDynamic(querySql, queryParam).Result;
        }

        public virtual T GetDetail<T>(string querySql, dynamic queryParam = null)
        {

            return SqlMapperUtil.SqlWithParamsSingle<T>(querySql, queryParam);
        }
        #endregion
    }
}