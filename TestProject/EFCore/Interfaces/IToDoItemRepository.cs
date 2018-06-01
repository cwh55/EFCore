using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{

    public interface IToDoItemRepository
    {
        IEnumerable<ToDoItem> GetList();

        int GetCount();
        int GetCompletedCount();
        double GetAveragePriority();
    }




   



}
