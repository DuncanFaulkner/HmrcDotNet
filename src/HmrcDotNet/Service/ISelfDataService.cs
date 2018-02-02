using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model.Self.Request;
using HmrcDotNet.Model.Self.Response;
using HmrcDotNet.Model.VAT;
using HmrcDotNet.Model.VAT.Response;

namespace HmrcDotNet.Service
{
    public interface ISelfDataService : IBaseService
    {
        Task<ServiceResponse<SelfEmploymentObligationsResponse>> GetEmploymentObligations(string token, string nino,
            string selfEmploymentId);

        Task<ServiceResponse<string>> AddSelfEmployment(string token, string nino, CreateSelfEmploymentRequest model);
        Task<ServiceResponse<List<SelfEmploymentResponse>>> GetEmployments(string token, string nino);
    }

    public class SelfDataService : ISelfDataService
    {
        private readonly IHmrcCommonDataService _commonDataService;
        private string _token;

        public SelfDataService(IHmrcCommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public void SetToken(string token)
        {
            _token = token;
        }

        public async Task<ServiceResponse<SelfEmploymentObligationsResponse>> GetEmploymentObligations(string token, string nino,string selfEmploymentId)
        {
            var response = new ServiceResponse<SelfEmploymentObligationsResponse>() { Data = new SelfEmploymentObligationsResponse() };

            if (String.IsNullOrEmpty(nino))
            {
                response.AddError("NINO", "Please enter a National Insurance Number");
            }
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<SelfEmploymentObligationsResponse>($"/self-assessment/ni/{nino}/self-employments/{selfEmploymentId}/obligations", token, HttpRequestType.Get);
            }
            return response;
        }

        public async Task<ServiceResponse<string>> AddSelfEmployment(string token, string nino, CreateSelfEmploymentRequest model)
        {
            //This should only be used in TEST
            var response = new ServiceResponse<string>();
            if (String.IsNullOrEmpty(nino))
            {
                response.AddError("NINO", "Please enter a National Insurance Number");
            }
            if (response.IsValid)
            {
                var createResponse =  await _commonDataService.CallApiAsync<CreateSelfEmploymentResponse,CreateSelfEmploymentRequest>($"/self-assessment/ni/{nino}/self-employments", token,model, HttpRequestType.Post);
                response.Data = createResponse.Location;
            }
            return response;
        }

        public async Task<ServiceResponse<List<SelfEmploymentResponse>>> GetEmployments(string token, string nino)
        {
            //This should only be used in TEST
            var response = new ServiceResponse<List<SelfEmploymentResponse>>(){Data = new List<SelfEmploymentResponse>()};
            if (String.IsNullOrEmpty(nino))
            {
                response.AddError("NINO", "Please enter a National Insurance Number");
            }
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<List<SelfEmploymentResponse>>($"/self-assessment/ni/{nino}/self-employments", token,  HttpRequestType.Get);
                
            }
            return response;
        }
    }
}
