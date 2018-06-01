using EFCore.Interfaces;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Infrastructure
{
    public class StudentOldRepository:IStudentRepository
    {
        public IList<Student> GetAllById(int id)
        {
            throw new NotImplementedException();
        }




        public IQueryable<Student> All()
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<Student> Filter(Expression<Func<Student, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<Student> Filter(Expression<Func<Student, bool>> filter, out int total, int index = 0,
                                               int size = 50)
        {
            throw new NotImplementedException();
        }

        public virtual void Create(Student TObject)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Student TObject)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(Expression<Func<Student, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(Student TObject)
        {
            throw new NotImplementedException();
        }


        public bool Contains(Expression<Func<Student, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Student Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public virtual Student Find(Expression<Func<Student, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Student FirstOrDefault(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

    }
}
