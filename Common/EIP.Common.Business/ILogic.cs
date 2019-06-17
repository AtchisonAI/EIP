using System.Collections.Generic;
using EIP.Common.Entities;

namespace EIP.Common.Business
{
    /// <summary>
    /// 业务逻辑基类
    /// </summary>
    /// <typeparam name="T">实体信息</typeparam>
    public interface ILogic<T> where T : class 
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">新增实体</param>
        /// <returns></returns>
        OperateStatus Insert(T entity, bool throwException = false);

        /// <summary>
        /// Dapper批量新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        OperateStatus InsertMultipleDapper(IEnumerable<T> list, bool throwException = false);

        /// <summary>
        /// SqlBulkCopy批量新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        OperateStatus InsertMultiple(IEnumerable<T> list, bool throwException = false);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="current">更新实体</param>
        /// <returns></returns>
        OperateStatus Update(T current, bool throwException = false);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        OperateStatus Delete(T entity, bool throwException = false);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        OperateStatus Delete(object id, bool throwException = false);

        /// <summary>
        /// 删除匹配项
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        OperateStatus DeleteBatch(string ids, bool throwException = false);

        /// <summary>
        /// 获取集合数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllEnumerable();

        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);
    }
}