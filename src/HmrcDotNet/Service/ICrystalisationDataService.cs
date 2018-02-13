using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model.Crystalise.Request;
using HmrcDotNet.Model.Crystalise.Response;
using HmrcDotNet.Model.TaxCalc.Response;

namespace HmrcDotNet.Service
{
    public interface ICrystalisationDataService
    {
        Task<ServiceResponse<TaxCalculationResponse>> IntentToCrystalise(string token,string nino, string taxYear);
        Task<ServiceResponse<CrystalisationResponse>> Crystalise(string token,string nino, string taxYear, string calculationId);
    }

    public class CrystalisationDataService : ICrystalisationDataService
    {
        private IHmrcCommonDataService _commonDataService;
        private ITaxCalcDataService _taxCalcDataService;
        public CrystalisationDataService(IHmrcCommonDataService commonDataService, ITaxCalcDataService taxCalcDataService)
        {
            _commonDataService = commonDataService;
            _taxCalcDataService = taxCalcDataService;
        }

        public async Task<ServiceResponse<TaxCalculationResponse>> IntentToCrystalise(string token, string nino, string taxYear)
        {
            var response = new ServiceResponse<TaxCalculationResponse>() { Data = new TaxCalculationResponse() };
            Validator.ValidateNinoandTaxYear(nino, taxYear, response);

            if (!response.IsValid)
            {
                var createResponse = await _commonDataService.CallApiAsync<CrystalisationIntentResponse>($"/self-assessment/ni/{nino}/{taxYear}/intent-to-crystallise", token, HttpRequestType.Post);
                if (createResponse.IsValid)
                {
                    var taxCalcLocation = createResponse.Location;
                    var taxCalulationId = taxCalcLocation.Split('/').Last();
                    //I Imagine there will be a delay here

                    response = await _commonDataService.CallApiAsync<TaxCalculationResponse>($"{createResponse.Location}", token, HttpRequestType.Get);
                    
                }
            }
            return response;
        }

        public async Task<ServiceResponse<CrystalisationResponse>> Crystalise(string token, string nino, string taxYear, string calculationId)
        {
            var response = new ServiceResponse<CrystalisationResponse>() { Data = new CrystalisationResponse() };
            Validator.ValidateNinoandTaxYear(nino, taxYear, response);

            var postModel = new CrystalisationRequest();
            postModel.calculationId = calculationId;
            if (!response.IsValid)
            {
                var createResponse = await _commonDataService.CallApiAsync<CrystalisationResponse, CrystalisationRequest>($"/self-assessment/ni/{nino}/{taxYear}/crystallisation", token,postModel, HttpRequestType.Post);
            }
            return response;
        }
    }
}
