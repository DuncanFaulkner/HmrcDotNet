using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Auth;
using HmrcDotNet.Service;
using HmrcDotNet.Web.Data;
using HmrcDotNet.Web.Data.Model;
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

        public async Task<IActionResult> CreateIndividual()
        {
            //Very Hacky
            var authUser = await _applicationDbContext.Individuals.FirstOrDefaultAsync(o => o.AuthJsonPayLoad != null);
            var authToken = JsonConvert.DeserializeObject<AuthToken>(authUser.AuthJsonPayLoad);
            _individualDataService.SetToken(authToken.AccessToken);
            
            var response =  await _individualDataService.CreateTestUserAsync();
            if (response.IsValid)
            {
                var individual = new Individual();
                individual.IndividualId = new Guid();
                individual.HmrcUserId = response.Data.userId;
                individual.SaUTR = response.Data.saUtr;
                individual.Nino = response.Data.nino;
                individual.IndividualName = response.Data.userFullName;
                individual.MtdItId = response.Data.mtdItId;
                individual.EmailAddress = response.Data.emailAddress;
                _applicationDbContext.Individuals.Add(individual);
                await _applicationDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
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
