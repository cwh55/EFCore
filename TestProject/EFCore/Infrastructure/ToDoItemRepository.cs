using EFCore.Interfaces;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Infrastructure
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private  List<ToDoItem> _items = new List<ToDoItem>();

        public ToDoItemRepository()
        {
            for (int i = 0; i < 10; i++)
            {
                _items.Add(new ToDoItem()
                {
                    IsDone = i % 3 == 0,
                    Name = "Task " + (i + 1),
                    Priority = i % 5 + 1
                });
            }
        }
        public IEnumerable<ToDoItem> GetList()
        {
            return _items.AsEnumerable();
        }



        public int GetCount()
        {
            return _items.Count();
        }

        public int GetCompletedCount()
        {
            return _items.Count(x => x.IsDone);
        }

        public double GetAveragePriority()
        {
            if (_items.Count() == 0)
            {
                return 0.0;
            }

            return _items.Average(x => x.Priority);
        }







    }
}
