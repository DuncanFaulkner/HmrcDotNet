using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HmrcDotNet.Service;
using HmrcDotNet.Web.Data;
using HmrcDotNet.Web.Data.Seed;
using Microsoft.AspNetCore.Mvc;
using HmrcDotNet.Web.Models;

namespace HmrcDotNet.Web.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _applicationDbContext;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<IActionResult> Index()
        {
            await SeedIndividual.SeedData(_applicationDbContext);
            return View();
        }


     

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
