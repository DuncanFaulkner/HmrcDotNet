using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model.Generic;
using HmrcDotNet.Model.VAT;
using HmrcDotNet.Model.VAT.Request;
using HmrcDotNet.Model.VAT.Response;
using Newtonsoft.Json;

namespace HmrcDotNet.Service
{
    public interface IVATDataService
    {
        Task<ServiceResponse<VATObligationsResponse>> GetVATObligations(string token ,string vrn, DateTime to, DateTime from, VATStatus vatStatus);
        Task<ServiceResponse<VATReturnResponse>> SendVATReturn(string token, string vrn, VATReturnRequest model);

    }

    public class VATDataService : IVATDataService
    {
        private readonly IHmrcCommonDataService _commonDataService;
        

        public VATDataService(IHmrcCommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public async Task<ServiceResponse<VATObligationsResponse>> GetVATObligations(string token,string vrn, DateTime from, DateTime to, VATStatus vatStatus)
        {
            var response = new ServiceResponse<VATObligationsResponse>(){Data = new VATObligationsResponse()};
            
            if (String.IsNullOrEmpty(vrn))
            {
                response.AddError("VRN", "Please enter a VAT Registration Number");
            }
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<VATObligationsResponse>($"vat/{vrn}/obligations?from={from.ToString("yyyy-MM-dd")}&to={to.ToString("yyyy-MM-dd")}&status={vatStatus.ToString()}", token, HttpRequestType.Get);

            }
            return response;
        }

        public async Task<ServiceResponse<VATReturnResponse>> SendVATReturn(string token, string vrn,VATReturnRequest model)
        {
            var response = new ServiceResponse<VATReturnResponse>(){Data= new VATReturnResponse()};

            response = await _commonDataService.CallApiAsync<VATReturnResponse, VATReturnRequest>($"vat/{vrn}/return", token, model, HttpRequestType.Post);
            
            return response;
        }
    }
}
