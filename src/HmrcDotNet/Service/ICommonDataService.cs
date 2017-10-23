using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Auth;
using HmrcDotNet.Helpers;
using Microsoft.Extensions.Options;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace HmrcDotNet.Service
{
    public interface ICommonDataService
    {
        Task<ServiceResponse<T>> CallApiAsync<T>(string query, string content, HttpRequestType httpRequestType);
        Task<ServiceResponse<T>> CallApiAsync<T>(string query, HttpRequestType httpRequestType);
    }

    public class CommonDataService : ICommonDataService
    {
        private HmrcSettings _hmrcSettings;
        private string _token { get; set; }
        public CommonDataService(IOptions<HmrcSettings> hmrcSettings)
        {
            _hmrcSettings = hmrcSettings.Value;
            _token = "TODO";
        }

        public async Task<ServiceResponse<T>> CallApiAsync<T>(string query, string content, HttpRequestType httpRequestType)
        {
            var response = new ServiceResponse<T>();
            //TODO GET TOKEN

            var url = _hmrcSettings.BaseUrl + query;
            var httpContent = new StringContent(content, Encoding.UTF8, "application/text");
            var accept = "application/json";
            var client = url.WithHeaders(new
            {
                Accept = accept,
            });
            client.WithOAuthBearerToken(_token);
            try
            {
                if (httpRequestType == HttpRequestType.Get)
                {
                    var objectResponse1 = await client.GetAsync();
                    var jString = await objectResponse1.Content.ReadAsStringAsync();
                    response.Data = JsonConvert.DeserializeObject<T>(jString);
                }

                if (httpRequestType == HttpRequestType.Post)
                {
                    var objectResponse1 = await client.PostAsync((HttpContent)httpContent);
                    var jString = await objectResponse1.Content.ReadAsStringAsync();
                    response.Data = JsonConvert.DeserializeObject<T>(jString);
                }
            }
            catch (FlurlHttpTimeoutException)
            {
                response.AddError("TimeOut", "The request timed out");
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == HttpStatusCode.Unauthorized)
                {
                    response.AddError("Error", "Failed with code Unauthorised");
                }

                if (ex.Call.Response != null)
                    response.AddError("Error", "Failed with response code " + ex.Call.Response.StatusCode);
                else
                    response.AddError("Error", ex.Message);
            }
            catch (Exception ex)
            {
                response.AddError("Error", ex.Message);
            }
            return response;

        }

        public async Task<ServiceResponse<T>> CallApiAsync<T>(string query, HttpRequestType httpRequestType)
        {
            return await CallApiAsync<T>(query, "", httpRequestType);
        }
    }
}
