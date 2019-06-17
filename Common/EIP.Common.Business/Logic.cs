using System;
using System.Collections.Generic;
using EIP.Common.DataAccess;
using EIP.Common.Entities;
using EIP.Common.Core.Resource;

namespace EIP.Common.Business
{
    public abstract class Logic<T> : ILogic<T> where T : class, new()
    {
        protected Logic()
        {
        }

        protected Logic(IRepository<T> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository", "repository not null");
            }
            Repository = repository;
        }

        private IRepository<T> Repository { get; set; }

        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="entity">新增实体</param>
        /// <returns></returns>
        public virtual OperateStatus Insert(T entity, bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.Insert(entity);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message); 
            }
            return operateStatus;
        }

        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual OperateStatus InsertMultipleDapper(IEnumerable<T> list,bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.InsertMultipleDapper(list);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message);               
            }
            return operateStatus;
        }

        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual OperateStatus InsertMultiple(IEnumerable<T> list, bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.InsertMultiple(list);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message); 
            }
            return operateStatus;
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="current">更新实体</param>
        /// <returns></returns>
        public virtual OperateStatus Update(T current, bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.Update(current);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message); 
            }
            return operateStatus;
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public virtual OperateStatus Delete(T entity, bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.Delete(entity);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message); 
            }
            return operateStatus;
        }

        /// <summary>
        ///     根据主键删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual OperateStatus Delete(object id, bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                //获取需要删除的数据
                var t = GetById(id);
                if (t == null)
                {
                    operateStatus.ResultSign = ResultSign.Error;
                    operateStatus.Message =  string.Format( Chs.Error,Chs.HaveDelete) ;
                    return operateStatus;
                }
                var resultNum = Repository.Delete(id);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message); 
            }
            return operateStatus;
        }

        /// <summary>
        ///     删除匹配项
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual OperateStatus DeleteBatch(string ids, bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.DeleteBatch(ids);
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message); 
            }
            return operateStatus;
        }

        /// <summary>
        ///     删除匹配项
        /// </summary>
        /// <returns></returns>
        public virtual OperateStatus DeleteAll(bool throwException = false)
        {
            var operateStatus = new OperateStatus();
            try
            {
                var resultNum = Repository.DeleteAll();
                operateStatus.ResultSign = resultNum > 0 ? ResultSign.Successful : ResultSign.Error;
                operateStatus.Message = resultNum > 0 ? Chs.Successful : Chs.Error;
            }
            catch (Exception exception)
            {
                if (throwException)
                {
                    throw exception;
                }
                operateStatus.Message = string.Format(Chs.Error, exception.Message);
            }
            return operateStatus;
        }

        /// <summary>
        ///     获取集合数据
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllEnumerable()
        {
            return Repository.GetAllEnumerable();
        }

        /// <summary>
        ///     根据主键获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return Repository.GetById(id);
        }
    }
}