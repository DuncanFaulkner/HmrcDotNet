using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Auth;
using HmrcDotNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace HmrcDotNet.Web.Controllers
{
    public class HmrcAuthController : Controller
    {
        //TODO I will change this I just want to confirm the best way to use the new oauth stuff in Core 2.0

        private HmrcSettings _hmrcSettings;
        private ICommonDataService _commonDataService;

        public IActionResult Connect(Guid id)
        {
            var clientId = _hmrcSettings.ClientId;
            var callbackUrl = _hmrcSettings.CallbackUrl;
            var state = id.ToString();
            var scope = "read:individual-benefits";
            return Redirect($"https://api.service.hmrc.gov.uk/oauth/authorize?response_type=code&client_id={clientId}&scope={scope}&state={state}&redirect_uri={callbackUrl}");
        }

        public async Task<IActionResult> Callback(string state, string code, string realmId)
        {
            var response = await _commonDataService.ExchangeToken(state, code, realmId);
            //Save the reponse to the user


            return RedirectToAction("GetBenefits", "Individual", new {utr = "", taxYear = ""});

        }
    }
}
