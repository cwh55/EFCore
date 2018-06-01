using EFCore.Data;
using EFCore.Models;
using EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IList<Student> GetAllById(int id);
    }
}
