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
    public class AdminController : Controller
    {
        private readonly MockDBContext mockDBContexts = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            AdminViewModel adminVM = new();
            adminVM.Show = true;
            adminVM.MarkList = mockDBContexts.Marks.ToList();

            return View(adminVM);
        }

        [HttpPost]
        public IActionResult AddStudent(AdminViewModel value)
        {
            AdminViewModel adminVM = value;

            try
            {
                if (ModelState.IsValid)
                {
                    mockDBContexts.Add(adminVM.SingleStudent);
                    mockDBContexts.SaveChanges();
                    ViewData["Message"] = "A Student Have Been Added";
                    adminVM.Show = false;
                    adminVM.Submited = true;
                }
                else
                {
                    adminVM.Show = true;
                    return View(adminVM);
                }
            }
            catch (Exception)
            {
                ViewData["Message"] = "Enter A Unique Student Number And Enter The Information Accordingly";
                adminVM.Show = false;
                adminVM.Submited = false;

                return View(adminVM);
            }

            return View(adminVM);
        }

        public IActionResult UpdateMark()
        {
            AdminViewModel adminVM = new();
            adminVM.Show = true;
            adminVM.Submited = false;
            adminVM.MarkList = mockDBContexts.Marks.ToList();

            return View(adminVM);
        }

        [HttpPost]
        public IActionResult UpdateMark(AdminViewModel value)
        {
            AdminViewModel adminVM = value;

            try
            {
                if (ModelState.IsValid)
                {
                    mockDBContexts.UpdateRange(adminVM.MarkList);
                    mockDBContexts.SaveChanges();
                    ViewData["Message"] = "The Marks Have Been Updated";
                    adminVM.Show = false;
                    adminVM.Submited = true;
                }
                else
                {
                    adminVM.Show = true;
                    return View(adminVM);
                }
            }
            catch (Exception)
            {
                ViewData["Message"] = "The Marks Have Not Been Updated";
                adminVM.Show = false;
                adminVM.Submited = false;

                return View(adminVM);
            }

            return View(adminVM);
        }

        public IActionResult DeleteClass()
        {
            AdminViewModel adminVM = new();
            adminVM.Show = true;
            adminVM.Submited = false;
            adminVM.ClassList = mockDBContexts.Classes.ToList();

            return View(adminVM);
        }

        [HttpPost]
        public IActionResult DeleteClass(int id)
        {
            AdminViewModel adminVM = new();
            Class deleteClass = mockDBContexts.Classes.FirstOrDefault(x => x.Id == id);

            try
            {
                if (ModelState.IsValid)
                {
                    mockDBContexts.Remove(deleteClass);
                    mockDBContexts.SaveChanges();
                    adminVM.ClassList = mockDBContexts.Classes.ToList();
                    ViewData["Message"] = "A Class Have Been Removed";
                    adminVM.Show = false;
                    adminVM.Submited = true;
                }
                else
                {
                    adminVM.Show = true;
                    return View(adminVM);
                }
            }
            catch (Exception)
            {
                ViewData["Message"] = "A Class Have Not Been Removed";
                adminVM.Show = false;
                adminVM.Submited = false;

                return View(adminVM);
            }

            return View(adminVM);
        }
    }
}