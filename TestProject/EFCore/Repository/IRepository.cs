using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Repository
{
   public interface IRepository<T> where T : class
    {

        IQueryable<T> All();
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        void Create(T t);
        void Delete(T t);
        int Delete(Expression<Func<T, bool>> predicate);
        void Update(T t);

        bool Contains(Expression<Func<T, bool>> predicate);
        T Find(params object[] keys);
        T Find(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> expression);



        #region 
        //DbSet<T> Entities { get; }

        ////增加单个实体
        //int Insert(T entity);

        ////增加多个实体
        //int Insert(IEnumerable<T> entities);

        ////更新实体
        //int Put(T entity);

        ////删除
        //int Delete(object id);

        ////根据主键获取实体
        //T GetByKey(object key);
        #endregion
    }
}
