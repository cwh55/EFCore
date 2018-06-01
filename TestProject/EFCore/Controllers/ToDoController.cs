using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoController(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        [Route("Todo")]
        public IActionResult Index()
        {
            var model = _toDoItemRepository.List();
            return View(model);
        }
    }
}
