using EFCore.Data;
using EFCore.Interfaces;
using EFCore.Models;
using EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Infrastructure
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly SchoolContext _context;
        public StudentRepository(SchoolContext dc): base(dc)
        {
            _context = dc;
        }


        public IList<Student> GetAllById(int id)
        {
            //.GetTable<Student>()
            var listDinner = from c in _context.Students 
                             where c.ID == id
                             select c;
            return listDinner.ToList();
        }


    }
}
