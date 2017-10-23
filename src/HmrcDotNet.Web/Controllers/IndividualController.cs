using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace HmrcDotNet.Web.Controllers
{
    public class IndividualController : Controller
    {
        private IIndividualDataService _individualDataService;

        public IndividualController(IIndividualDataService individualDataService)
        {
            _individualDataService = individualDataService;
        }

        public async Task<IActionResult> GetBenefits(string utr, string taxYear)
        {
            _individualDataService.SetToken("");
            var response = await _individualDataService.GetBenefitsAsync(utr, taxYear);
            return ViewBag(response.Data);
        }
    }
}
