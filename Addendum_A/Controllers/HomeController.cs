using System;
using Addendum_A.Models;
using Addendum_A.ViewModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Addendum_A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MockDBContext mockDBContexts = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            StudentViewModel studentVM = new();
            studentVM.StudentList = mockDBContexts.Students.ToList();

            return View(studentVM);
        }

        public IActionResult Mark(int id)
        {
            StudentViewModel studentVM = new();
            studentVM.SingleStudent = mockDBContexts.Students.FirstOrDefault(x => x.Id == id);

            return View(studentVM);
        }

        public IActionResult Class(int id)
        {
            StudentViewModel studentVM = new();
            studentVM.SingleStudent = mockDBContexts.Students.FirstOrDefault(x => x.Id == id);

            return View(studentVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}