using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Entities.Paging;

namespace EIP.Common.DataAccess
{
    public interface IAsyncQueryRepository
    {


        /// <summary>
        /// 复杂查询分页
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="querySql">查询语句</param>
        /// <param name="queryParam">查询参数</param>
        /// <returns>分页结果</returns>
        /// <remarks>
        /// 注意事项：
        /// 1.sql语句中需要加上@where、@orderBy、@rowNumber、@recordCount标记
        ///     如: "select *, @rowNumber, @recordCount from ADM_Rule @where"
        /// 2.实体中需增加扩展属性，作记录总数输出：RecordCount
        /// 3.标记解释:
        ///     @where：      查询条件
        ///     @orderBy：    排序
        ///     @x：          分页记录起点
        ///     @y：          分页记录终点
        ///     @recordCount：记录总数
        ///     @rowNumber：  行号
        /// 4.示例参考:
        /// </remarks>
        Task<PagedResults<T>> PagingQueryAsync<T>(string querySql, QueryParam queryParam);

        Task<PagedResults> PagingQueryAsyncDataTable(string querySql, QueryParam queryParam);

        Task<PagedResults<dynamic>> PagingQueryAsyncDynamic(string querySql, QueryParam queryParam);

        Task<IEnumerable<T>> QueryAsync<T>(string querySql, dynamic parms);
        Task<IEnumerable<dynamic>> QueryAsync(string querySql, dynamic parms);
        Task<T> GetDetailAsync<T>(string querySql, dynamic queryParam = null);
    }
}