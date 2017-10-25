using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Auth;
using HmrcDotNet.Service;
using HmrcDotNet.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HmrcDotNet.Web.Controllers
{
    public class IndividualController : Controller
    {
        private IIndividualDataService _individualDataService;
        private ApplicationDbContext _applicationDbContext;

        public IndividualController(IIndividualDataService individualDataService, ApplicationDbContext applicationDbContext)
        {
            _individualDataService = individualDataService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var individuals = await _applicationDbContext.Individuals.ToListAsync();
            return View(individuals);
        }
    

        public async Task<IActionResult> GetBenefits(Guid id, string utr, string taxYear)
        {
            var individual = await _applicationDbContext.Individuals.FirstOrDefaultAsync(o => o.IndividualId == id);
            if (individual != null)
            {
                var token = JsonConvert.DeserializeObject<AuthToken>(individual.AuthJsonPayLoad);
                _individualDataService.SetToken(token.AccessToken);
                var response = await _individualDataService.GetBenefitsAsync(utr, taxYear);
                return View(response.Data);
            }
            //Throw validation error

            return RedirectToAction("Index");

        }
    }
}
