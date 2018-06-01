using EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.Service
{
    public class StatisticsService
    {
        //private readonly IToDoItemRepository _toDoItemRepository;
        //public StatisticsService(IToDoItemRepository toDoItemRepository)
        //{
        //    _toDoItemRepository = toDoItemRepository;
        //}

        private readonly ToDoItemRepository _toDoItemRepository;
        public HomeController(ToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }



        public int GetCount()
        {
            return _toDoItemRepository.List().Count();
        }

        public int GetCompletedCount()
        {
            return _toDoItemRepository.List().Count(x => x.IsDone);
        }

        public double GetAveragePriority()
        {
            if (_toDoItemRepository.List().Count() == 0)
            {
                return 0.0;
            }

            return _toDoItemRepository.List().Average(x => x.Priority);
        }


    }
}
