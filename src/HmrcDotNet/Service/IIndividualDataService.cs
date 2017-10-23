using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model;

namespace HmrcDotNet.Service
{
    public interface IIndividualDataService
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
    }

    public class IndividualDataService : IIndividualDataService
    {
        private ICommonDataService _commonDataService;

        public IndividualDataService(ICommonDataService commonDataService)
        {
            _commonDataService = commonDataService;
        }

        public async Task<ServiceResponse<IndividualBenefits>> GetBenefitsAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualBenefits>(){Data = new IndividualBenefits()};
           
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualBenefits>($"/individual-benefits/sa/{utr}/annual-summary/{taxYear}",  HttpRequestType.Get);
            }
            return response;
        }
        public async Task<ServiceResponse<IndividualEmployments>> GetIndividualEmploymentsAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualEmployments>(){ Data = new IndividualEmployments()}; 
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualEmployments>($"/individual-employment/sa/{utr}/annual-summary/{taxYear}", HttpRequestType.Get);
            }

            return response;
        }

        public async Task<ServiceResponse<IndividualIncome>> GetIndividualIncomeAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualIncome>() { Data = new IndividualIncome() };
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualIncome>($"/individual-income/sa/{utr}/annual-summary/{taxYear}", HttpRequestType.Get);
            }

            return response;
        }

        public async Task<ServiceResponse<IndividualTax>> GetIndividualTaxAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<IndividualTax>() { Data = new IndividualTax() };
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<IndividualTax>($"/individual-tax/sa/{utr}/annual-summary/{taxYear}", HttpRequestType.Get);

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
                response = await _commonDataService.CallApiAsync<LifetimeIsa>($"/lifetime-isa/manager/{lisaManagerReferenceNumber}", HttpRequestType.Get);
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
                response = await _commonDataService.CallApiAsync<MarriageAllowanceEligibility>($"/marriage-allowance/sa/{utr}/status", HttpRequestType.Get);

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
                response = await _commonDataService.CallApiAsync<MarriageAllowanceStatus>($"/marriage-allowance/sa/{utr}/eligibility", HttpRequestType.Get);

            }

            return response;
        }

        public async Task<ServiceResponse<NationalInsurance>> GetNationalInsuranceAsync(string utr, string taxYear)
        {
            var response = new ServiceResponse<NationalInsurance>() { Data = new NationalInsurance() };
            ValidateUtRandTaxYear(utr, taxYear, response);
            if (!response.IsValid)
            {
                response = await _commonDataService.CallApiAsync<NationalInsurance>($"/national-insurance/sa/{utr}/annual-summary/{taxYear}", HttpRequestType.Get);
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
                response = await _commonDataService.CallApiAsync<ReliefAtSource>($"/relief-at-source/customer/{customeruuid}/residency-status", HttpRequestType.Get);
            }
            return response;
        }

        private static void ValidateUtRandTaxYear(string utr, string taxYear, ServiceResponse response)
        {
            if (!Regex.Match(utr, @"^\d{10}$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("UTR", "The UTR needs to be 10 characters");
            }
            if (!Regex.Match(taxYear, @"^[0-9]{4}-[0-1][0-9]$", RegexOptions.IgnoreCase).Success)
            {
                response.AddError("Year", "The Year is in the wrong format");
            }
        }
    }
}
