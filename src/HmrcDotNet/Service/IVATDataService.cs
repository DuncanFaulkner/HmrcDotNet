using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
        Task<ServiceResponse<VATReturnResponse>> GetVATReturn(string token ,string vrn, string periodKey);
        Task<ServiceResponse<VATLiabilityResponse>> GetVATLiabilities(string token ,string vrn, DateTime from, DateTime to);
        Task<ServiceResponse<VATPaymentResponse>> GetVATPayments(string token ,string vrn, DateTime from, DateTime to);
        Task<ServiceResponse<SendVATReturnResponse>> SendVATReturn(string token, string vrn, VATReturnRequest model);

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

        public async Task<ServiceResponse<VATReturnResponse>> GetVATReturn(string token, string vrn, string periodKey)
        {
            var response = new ServiceResponse<VATReturnResponse>() { Data = new VATReturnResponse() };

            if (String.IsNullOrEmpty(vrn))
            {
                response.AddError("VRN", "Please enter a VAT Registration Number");
            }
            if (String.IsNullOrEmpty(periodKey))
            {
                response.AddError("PeriodKey", "Please enter a Period Key");
            }
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<VATReturnResponse>($"vat/{vrn}/returns/{periodKey}", token, HttpRequestType.Get);
            }
            return response;
        }

        public async Task<ServiceResponse<VATLiabilityResponse>> GetVATLiabilities(string token, string vrn, DateTime @from, DateTime to)
        {
            var response = new ServiceResponse<VATLiabilityResponse>(){Data =  new VATLiabilityResponse()};
            if (String.IsNullOrEmpty(vrn))
            {
                response.AddError("VRN", "Please enter a VAT Registration Number");
            }
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<VATLiabilityResponse>($"vat/{vrn}/liabilities?from={from.ToString("yyyy-MM-dd")}&to={to.ToString("yyyy-MM-dd")}", token, HttpRequestType.Get);
            }
            return response;
        }

        public async Task<ServiceResponse<VATPaymentResponse>> GetVATPayments(string token, string vrn, DateTime @from, DateTime to)
        {
            var response = new ServiceResponse<VATPaymentResponse>() { Data = new VATPaymentResponse() };
            if (String.IsNullOrEmpty(vrn))
            {
                response.AddError("VRN", "Please enter a VAT Registration Number");
            }
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<VATPaymentResponse>($"vat/{vrn}/payments?from={from.ToString("yyyy-MM-dd")}&to={to.ToString("yyyy-MM-dd")}", token, HttpRequestType.Get);
            }
            return response;
        }

        public async Task<ServiceResponse<SendVATReturnResponse>> SendVATReturn(string token, string vrn,VATReturnRequest model)
        {
            var response = new ServiceResponse<SendVATReturnResponse>(){Data= new SendVATReturnResponse()};
            var encodedPeriodKey = HttpUtility.UrlEncode(model.periodKey);
            response = await _commonDataService.CallApiAsync<SendVATReturnResponse, VATReturnRequest>($"vat/{vrn}/returns/{model.periodKey}", token, model, HttpRequestType.Post);
            
            return response;
        }
    }
}
