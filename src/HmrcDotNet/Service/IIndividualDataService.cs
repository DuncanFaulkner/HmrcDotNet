using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model.Individual.Request;
using HmrcDotNet.Model.Individual.Response;

namespace HmrcDotNet.Service
{
    public interface IIndividualDataService:IBaseService
    {
        Task<ServiceResponse<IndividualBenefits>> GetBenefitsAsync(string utr, string taxYear);
        Task<ServiceResponse<IndividualEmployments>> GetIndividualEmploymentsAsync(string utr, string taxYear);
        Task<ServiceResponse<IndividualIncome>> GetIndividualIncomeAsync(string utr, string taxYear);
        Task<ServiceResponse<IndividualTax>> GetIndividualTaxAsync(string utr, string taxYear);
        Task<ServiceResponse<LifetimeIsa>> GetLifetimeIsaAsync(string lisaManagerReferenceNumber);
        Task<ServiceResponse<MarriageAllowanceEligibility>> GetMarriageAllowanceEligibilityAsync(string utr);
        Task<ServiceResponse<MarriageAllowanceStatus>> GetMarriageAllowanceStatusAsync(string utr);
        Task<ServiceResponse<NationalInsurance>> GetNationalInsuranceAsync(string utr, string taxYear);
        Task<ServiceResponse<ReliefAtSource>> GetReliefAtSourceAsync(string customeruuid);
        
        Task<ServiceResponse<CreateTestUserResponse>> CreateTestUserAsync();
        Task<ServiceResponse<IndividualBenefits>> CreateBenefits(string utr, string taxYear);
        Task<ServiceResponse<IndividualEmployments>> CreateEmployments(string utr, string taxYear);
        Task<ServiceResponse<IndividualIncome>> CreateIncome(string utr, string taxYear);
        Task<ServiceResponse<IndividualTax>> CreateTax(string utr, string taxYear);
        Task<ServiceResponse<MarriageAllowanceStatus>> CreateMarriageStatus(string utr, string taxYear);
        Task<ServiceResponse<MarriageAllowanceEligibility>> CreateMarriageEligibility(string nino, string taxYear);
        Task<ServiceResponse<NationalInsurance>> CreateNationalInsurance(string utr, string taxYear);
    }

    public class IndividualDataService : IIndividualDataService
    {
        private readonly ICommonDataService _commonDataService;
        private string _token;
        public IndividualDataService(ICommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public async Task<ServiceResponse<IndividualBenefits>> GetBenefitsAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualBenefits>(){Data = new IndividualBenefits()};
           
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualBenefits>($"/individual-benefits/sa/{utr}/annual-summary/{taxYear}", _token, HttpRequestType.Get);
            }
            return response;
        }
        public async Task<ServiceResponse<IndividualEmployments>> GetIndividualEmploymentsAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualEmployments>(){ Data = new IndividualEmployments()}; 
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualEmployments>($"/individual-employment/sa/{utr}/annual-summary/{taxYear}",_token, HttpRequestType.Get);
            }

            return response;
        }

        public async Task<ServiceResponse<IndividualIncome>> GetIndividualIncomeAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualIncome>() { Data = new IndividualIncome() };
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualIncome>($"/individual-income/sa/{utr}/annual-summary/{taxYear}", _token, HttpRequestType.Get);
            }

            return response;
        }

        public async Task<ServiceResponse<IndividualTax>> GetIndividualTaxAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualTax>() { Data = new IndividualTax() };
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualTax>($"/individual-tax/sa/{utr}/annual-summary/{taxYear}", _token, HttpRequestType.Get);

            }

            return response;
        }

        public async Task<ServiceResponse<LifetimeIsa>> GetLifetimeIsaAsync(string lisaManagerReferenceNumber)
        {
            var response = new ServiceResponse<LifetimeIsa>() { Data = new LifetimeIsa() };
            if (!Regex.Match(lisaManagerReferenceNumber, @"^Z([0-9]{4}|[0-9]{6})$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("lisaManagerReferenceNumber", "The lisaManagerReferenceNumber needs to be the following format eg Z1234");
            }
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<LifetimeIsa>($"/lifetime-isa/manager/{lisaManagerReferenceNumber}", _token, HttpRequestType.Get);
            }

            return response;
        }

        public async Task<ServiceResponse<MarriageAllowanceEligibility>> GetMarriageAllowanceEligibilityAsync(string utr)
        {
            var response = new ServiceResponse<MarriageAllowanceEligibility>() { Data = new MarriageAllowanceEligibility() };
            if (!Regex.Match(utr, @"^\d{10}$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("UTR", "The UTR needs to be 10 characters");
            }
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<MarriageAllowanceEligibility>($"/marriage-allowance/sa/{utr}/status", _token, HttpRequestType.Get);

            }

            return response;
        }

        public async Task<ServiceResponse<MarriageAllowanceStatus>> GetMarriageAllowanceStatusAsync(string utr)
        {
            var response = new ServiceResponse<MarriageAllowanceStatus>() { Data = new MarriageAllowanceStatus() };
            if (!Regex.Match(utr, @"^\d{10}$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("UTR", "The UTR needs to be 10 characters");
            }
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<MarriageAllowanceStatus>($"/marriage-allowance/sa/{utr}/eligibility", _token, HttpRequestType.Get);

            }

            return response;
        }

        public async Task<ServiceResponse<NationalInsurance>> GetNationalInsuranceAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<NationalInsurance>() { Data = new NationalInsurance() };
            Validator.ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<NationalInsurance>($"/national-insurance/sa/{utr}/annual-summary/{taxYear}", _token, HttpRequestType.Get);
            }

            return response;
        }

        public async Task<ServiceResponse<ReliefAtSource>> GetReliefAtSourceAsync(string customeruuid)
        {
            var response = new ServiceResponse<ReliefAtSource>(){Data = new ReliefAtSource()};
            if (!Regex.Match(customeruuid, @"^[0-9A-Fa-f]{8}(-[0-9A-Fa-f]{4}){3}-[0-9A-Fa-f]{12}$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("Customeruuid", "The customeruuid needs to be the following format 6b853b58-625f-4e64-955e-43a7cdff5c03");
            }
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<ReliefAtSource>($"/relief-at-source/customer/{customeruuid}/residency-status", _token, HttpRequestType.Get);
            }
            return response;
        }

        public void SetToken(string token)
        {
            _token = token;
        }

        

        public async Task<ServiceResponse<CreateTestUserResponse>> CreateTestUserAsync()
        {
            var response = new ServiceResponse<CreateTestUserResponse>(){Data = new CreateTestUserResponse()};

            var testUserRequest = new CreateTestUserRequest();
            testUserRequest.serviceNames.Add("national-insurance");
            testUserRequest.serviceNames.Add("self-assessment");
            testUserRequest.serviceNames.Add("mtd-income-tax");


            response = await _commonDataService.CallApiAsync<CreateTestUserResponse,CreateTestUserRequest>($"/create-test-user/individuals", _token, testUserRequest , HttpRequestType.Post);
            
            return response;
        }

        public async Task<ServiceResponse<IndividualBenefits>> CreateBenefits(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualBenefits>(){ Data = new IndividualBenefits()};
            var createIndividualRequest = new CreateIndividualRequest();
            createIndividualRequest.scenario = "HAPPY_PATH_1";
            response = await _commonDataService.CallApiAsync<IndividualBenefits, CreateIndividualRequest>($"/individual-paye-test-support/sa/{utr}/benefits/annual-summary/{taxYear}", _token, createIndividualRequest, HttpRequestType.Post);
            return response;
        }

        public async Task<ServiceResponse<IndividualEmployments>> CreateEmployments(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualEmployments>() { Data = new IndividualEmployments() };
            var createIndividualRequest = new CreateIndividualRequest();
            createIndividualRequest.scenario = "HAPPY_PATH_1";
            response = await _commonDataService.CallApiAsync<IndividualEmployments, CreateIndividualRequest>($"/individual-paye-test-support/sa/{utr}/employments/annual-summary/{taxYear}", _token, createIndividualRequest, HttpRequestType.Post);
            return response;
        }

        public async Task<ServiceResponse<IndividualIncome>> CreateIncome(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualIncome>() { Data = new IndividualIncome() };
            var createIndividualRequest = new CreateIndividualRequest();
            createIndividualRequest.scenario = "HAPPY_PATH_1";
            response = await _commonDataService.CallApiAsync<IndividualIncome, CreateIndividualRequest>($"/individual-paye-test-support/sa/{utr}/income/annual-summary/{taxYear}", _token, createIndividualRequest, HttpRequestType.Post);
            return response;
        }

        public async Task<ServiceResponse<IndividualTax>> CreateTax(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualTax>() { Data = new IndividualTax() };
            var createIndividualRequest = new CreateIndividualRequest();
            createIndividualRequest.scenario = "HAPPY_PATH_1";
            response = await _commonDataService.CallApiAsync<IndividualTax, CreateIndividualRequest>($"/individual-paye-test-support/sa/{utr}/tax/annual-summary/{taxYear}", _token, createIndividualRequest, HttpRequestType.Post);
            return response;
        }

        public async Task<ServiceResponse<MarriageAllowanceStatus>> CreateMarriageStatus(string utr, string taxYear)
        {
            var response = new ServiceResponse<MarriageAllowanceStatus>() { Data = new MarriageAllowanceStatus() };
            var marriageAllowanceStatus = new MarriageAllowanceStatus();
            marriageAllowanceStatus.Status = "Recipient";
            marriageAllowanceStatus.Deceased = false;
            response = await _commonDataService.CallApiAsync<MarriageAllowanceStatus, MarriageAllowanceStatus>($"/marriage-allowance-test-support/sa/{utr}/status/{taxYear}", _token, marriageAllowanceStatus, HttpRequestType.Post);
            return response;
        }

        public async Task<ServiceResponse<MarriageAllowanceEligibility>> CreateMarriageEligibility(string nino, string taxYear)
        {
            var response = new ServiceResponse<MarriageAllowanceEligibility>() { Data = new MarriageAllowanceEligibility() };
            var allowanceEligibility = new MarriageAllowanceEligibility();
            allowanceEligibility.Eligible = true;
            response = await _commonDataService.CallApiAsync<MarriageAllowanceEligibility, MarriageAllowanceEligibility>($"/marriage-allowance-test-support/nino/{nino}/eligibility/{taxYear}", _token, allowanceEligibility, HttpRequestType.Post);
            return response;
        }

        public async Task<ServiceResponse<NationalInsurance>> CreateNationalInsurance(string utr, string taxYear)
        {
            var response = new ServiceResponse<NationalInsurance>() { Data = new NationalInsurance() };
            var createNi = new CreateIndividualRequest();
            createNi.scenario = "HAPPY_PATH_1";
            response = await _commonDataService.CallApiAsync<NationalInsurance, CreateIndividualRequest>($"/national-insurance-test-support/sa/{utr}/annual-summary/{taxYear}", _token, createNi, HttpRequestType.Post);
            return response;
        }


        
    }
}
