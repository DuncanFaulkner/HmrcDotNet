using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model.TaxCalc.Response;

namespace HmrcDotNet.Service
{
    public interface ITaxCalcDataService
    { 
        Task<ServiceResponse<TaxCalculationResponse>> CalculateTax(string token, string nino, string taxYear);
    }

    public class TaxCalcDataService : ITaxCalcDataService
    {
        private readonly IHmrcCommonDataService _commonDataService;
       
        public TaxCalcDataService(IHmrcCommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }
        
        public async Task<ServiceResponse<TaxCalculationResponse>> CalculateTax(string token, string nino, string taxYear)
        {
            var response = new ServiceResponse<TaxCalculationResponse>(){Data= new TaxCalculationResponse()};
            Validator.ValidateNinoandTaxYear(nino,taxYear,response);

            if (!response.IsValid)
            {
                var calcresponse = await _commonDataService.CallApiAsync<CreateTaxCalcResponse>($"/self-assessment/ni/{nino}/calculations", token, HttpRequestType.Get);
                if (calcresponse.IsValid)
                {
                    var delay = calcresponse.Data.etaSeconds;
                    //Delay for a few seconds to try again
                    await Task.Delay(delay * 1000);
                    response = await _commonDataService.CallApiAsync<TaxCalculationResponse>($"{calcresponse.Location}", token, HttpRequestType.Get);
                }
            }
            return response;
        }
    }
}
