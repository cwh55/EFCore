using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Models;
using EFCore.Interfaces;
using EFCore.Filters;
using EFCore.Middleware;
using EFCore.Infrastructure;

namespace EFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWorkRepository;

        public HomeController(IToDoItemRepository toDoItemRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWorkRepository)
        {
            _toDoItemRepository = toDoItemRepository;
            _studentRepository = studentRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public IActionResult Index()
        {
            IList<Student> list1=_studentRepository.GetAllById(1);
            var studentRepository = _unitOfWorkRepository.GetRepository<IStudentRepository>();
            IList<Student> list = studentRepository.GetAllById(1);
            return View();
        }


       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        //[TypeFilter(typeof(AuthorizationFilter))]
        //[TypeFilter(typeof(CustomExceptionFilter))]  
        //[MiddlewareFilter(typeof(LocalizationPipeline))]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            var model = _toDoItemRepository.GetList();

            var count = _toDoItemRepository.GetCount();
            ViewData["Count"] = count;
            int abc = _toDoItemRepository.GetCompletedCount();

            ViewData["CompletedCount"] = abc;
            double ade = _toDoItemRepository.GetAveragePriority();
            ViewData["AveragePriority"] = ade;
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
