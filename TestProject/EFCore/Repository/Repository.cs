using EFCore.Data;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }
      

        public IQueryable<T> All()
        {
            return Context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0,
                                               int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null
                                ? Context.Set<T>().Where<T>(filter).AsQueryable()
                                : Context.Set<T>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual void Create(T TObject)
        {
            Context.Set<T>().Add(TObject);
        }

        [HttpDelete]
        public virtual void Delete(T TObject)
        {
            Context.Set<T>().Remove(TObject);
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                Context.Set<T>().Remove(obj);
            return Context.SaveChanges();
        }

        public virtual void Update(T TObject)
        {
            try
            {
                var entry = Context.Entry(TObject);
                Context.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }

        public virtual T Find(params object[] keys)
        {
            return Context.Set<T>().Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault<T>(predicate);
        }


        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return All().FirstOrDefault(expression);
        }







        #region  
        //public SchoolContext _entitys;
        //public DbSet<Student> Entities
        //{
        //    get
        //    {
        //        return _entitys.Set<Student>();
        //    }
        //}


        //public int Insert(Student entity)
        //{
        //    Entities.Add(entity);
        //    return _entitys.SaveChanges();
        //}

        //public int Insert(IEnumerable<Student> entities)
        //{
        //    Entities.AddRange(entities);
        //    return _entitys.SaveChanges();
        //}

        //public int Put(Student entity)
        //{
        //    _entitys.Entry<Student>(entity).State = EntityState.Modified;
        //    return _entitys.SaveChanges();
        //}

        //public int Delete(object id)
        //{
        //    return 0;
        //}

        //public Student GetByKey(object key)
        //{
        //    return Entities.Find(key);
        //}
        #endregion






        #region
        //private DbSet<T> entities;
        //private DbSet<T> Entities
        //{
        //    get
        //    {
        //        if (entities == null)
        //        {
        //            entities = context.Set<T>();
        //        }
        //        return entities;
        //    }
        //}

        //public virtual IQueryable<T> Table
        //{
        //    get
        //    {
        //        return this.Entities;
        //    }
        //}


        //public T GetById(object id)
        //{
        //    return this.Entities.Find(id);
        //}


        //public void Insert(T entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }
        //        this.Entities.Add(entity);
        //        this.context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public void Update(T entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }
        //        this.context.SaveChanges();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}

        //public void Delete(T entity)
        //{
        //    try
        //    {

        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }
        //        this.Entities.Remove(entity);
        //        this.context.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        #endregion
    }
}
