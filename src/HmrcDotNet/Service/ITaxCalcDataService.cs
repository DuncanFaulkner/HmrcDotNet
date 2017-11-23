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
    public interface ITaxCalcDataService : IBaseService
    {
        Task<ServiceResponse<TaxCalculationResponse>> CalculateTax(string nino, string taxYear);
    }

    public class TaxCalcDataService : ITaxCalcDataService
    {
        private readonly ICommonDataService _commonDataService;
        private string _token;

        public TaxCalcDataService(ICommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public void SetToken(string token)
        {
            _token = token;
        }
        
        public async Task<ServiceResponse<TaxCalculationResponse>> CalculateTax(string nino, string taxYear)
        {
            var response = new ServiceResponse<TaxCalculationResponse>(){Data= new TaxCalculationResponse()};
            Validator.ValidateNinoandTaxYear(nino,taxYear,response);

            if (!response.IsValid)
            {
                var calcresponse = await _commonDataService.CallApiAsync<CreateTaxCalcResponse>($"/self-assessment/ni/{nino}/calculations", _token, HttpRequestType.Get);
                if (calcresponse.IsValid)
                {
                    var delay = calcresponse.Data.etaSeconds;
                    //Delay for a few seconds to try again
                    await Task.Delay(delay * 1000);
                    //TODO either recover the detail from the header but I have logged a case.
                    //response = _commonDataService.CallApiAsync<CreateTaxCalcResponse>($"/self-assessment/ni/{nino}/calculations/{taxCalculationId}", _token, HttpRequestType.Get);
                }

            }

            return response;
        }
    }
}
