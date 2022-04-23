using Addendum_C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace Addendum_C.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexModel indexModel = new();
            indexModel.Switch = false;

            return View(indexModel);
        }

        [HttpPost]
        public IActionResult Index(IndexModel value)
        {
            IndexModel indexModel = new();

            try
            {
                if (ModelState.IsValid)
                {
                    int[] arrayNum = new int[13];
                    int[] arrayDate = new int[13];

                    for (int i = 0; i < value.IdNumber.Length; i++)
                    {
                        arrayNum[i] = (int)char.GetNumericValue(value.IdNumber[i]);
                        arrayDate[i] = (int)char.GetNumericValue(value.IdNumber[i]);
                    }

                    for (int i = 0; i < arrayNum.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            if (arrayNum[i] * 2 > 9)
                            {
                                string multStringNum = (arrayNum[i] * 2).ToString();
                                int charNum1 = (int)char.GetNumericValue(multStringNum[0]);
                                int charNum2 = (int)char.GetNumericValue(multStringNum[1]);
                                arrayNum[i] = charNum1 + charNum2;
                            }
                            else
                            {
                                arrayNum[i] *= 2;
                            }
                        }
                    }

                    if (arrayNum.Sum() % 10 == 0)
                    {
                        int year = Convert.ToInt32(string.Format("{0}{1}", arrayDate[0], arrayDate[1]));
                        int month = Convert.ToInt32(string.Format("{0}{1}", arrayDate[2], arrayDate[3]));
                        int day = Convert.ToInt32(string.Format("{0}{1}", arrayDate[4], arrayDate[5]));

                        var cultureYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(year);
                        DateTime determindBirthDate = new(cultureYear, month, day);
                        indexModel.BirthDate = determindBirthDate.ToString("yyyy/MM/dd");
                        indexModel.Age = DateTime.Now.Year - determindBirthDate.Year;
                        ViewData["Message"] = "Your Id Number Is Valid";
                        indexModel.Valid = true;
                    }
                    else
                    {
                        ViewData["Message"] = "Your Id Number Is Invalid";
                        indexModel.Valid = false;
                    }

                    indexModel.Switch = true;
                    indexModel.Error = false;
                }
            }
            catch (Exception)
            {
                indexModel.Switch = true;
                indexModel.Error = true;
                ViewData["Message"] = "Please Enter The Field Correctly";
                return View(indexModel);
            }

            return View(indexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}