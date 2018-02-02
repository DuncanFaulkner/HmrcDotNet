using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Auth;
using HmrcDotNet.Service;
using HmrcDotNet.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HmrcDotNet.Web.Controllers
{
    public class HmrcAuthController : Controller
    {
        //TODO I will change this I just want to confirm the best way to use the new oauth stuff in Core 2.0

        private HmrcSettings _hmrcSettings;
        private ICommonDataService _commonDataService;
        private ApplicationDbContext _applicationDbContext;

        public HmrcAuthController(IOptions<HmrcSettings> hmrcSettings, ICommonDataService commonDataService, ApplicationDbContext applicationDbContext)
        {
            _hmrcSettings = hmrcSettings.Value;
            _commonDataService = commonDataService;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Connect(Guid id)
        {
            var scope = "read:individual-benefits";
            return Redirect($"{_hmrcSettings.BaseUrl}/oauth/authorize?response_type=code&client_id={_hmrcSettings.ClientId}&scope={scope}&state={id.ToString()}&redirect_uri={_hmrcSettings.CallbackUrl}");
        }

        public async Task<IActionResult> Callback(string state, string code)
        {
            var response = await _commonDataService.ExchangeToken(state, code);
            //Save the reponse to the user
            var individual =await _applicationDbContext.Individuals.FirstOrDefaultAsync(o => o.IndividualId == Guid.Parse(state));
            if (individual != null)
            {
                //TODO encrypt
                individual.AuthJsonPayLoad = JsonConvert.SerializeObject(response.Data);
                await _applicationDbContext.SaveChangesAsync();
            }


            return RedirectToAction("Index", "Individual");

        }
    }
}
