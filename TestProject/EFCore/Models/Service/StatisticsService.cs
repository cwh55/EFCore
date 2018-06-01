using EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.Service
{
    public class StatisticsService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        public StatisticsService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }


        public int GetCount()
        {
            return _toDoItemRepository.GetList().Count();
        }

        public int GetCompletedCount()
        {
            return _toDoItemRepository.GetList().Count(x => x.IsDone);
        }

        public double GetAveragePriority()
        {
            if (_toDoItemRepository.GetList().Count() == 0)
            {
                return 0.0;
            }

            return _toDoItemRepository.GetList().Average(x => x.Priority);
        }


    }
}
