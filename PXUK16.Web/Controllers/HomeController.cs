using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PXUK16.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PXUK16.Web.Controllers
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
            List<Manufactory> manufactories = new List<Manufactory>();
            manufactories = Helper.APIHelper<List<Manufactory>>.HttpGetAsync("api/manufactory/gets");
            return View(manufactories);
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateManufactory createManufactory)
        {
            if (ModelState.IsValid)
            {
                var result = new CreateManufactoryResult();
                result = Helper.APIHelper<CreateManufactoryResult>.HttpPostAsync("api/manufactory/create", "POST", createManufactory);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                return View(createManufactory);
            }
            return View(createManufactory);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateManufactory updateManufactory)
        {
            if (ModelState.IsValid)
            {
                var result = new UpdateManufactoryResult();           
                result = Helper.APIHelper<UpdateManufactoryResult>.HttpPostAsync("api/manufactory/update", "POST", updateManufactory);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                return View(updateManufactory);
            }
            return View(updateManufactory);
        }
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(DeleteManufactory deleteManufactory)
        {
            if (ModelState.IsValid)
            {
                var result = new DeleteManufactoryResult();
                result = Helper.APIHelper<DeleteManufactoryResult>.HttpPostAsync("api/manufactory/delete", "POST", deleteManufactory);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                return View(deleteManufactory);
            }
            return View(deleteManufactory);
        }
    }
}
