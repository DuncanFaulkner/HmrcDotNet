using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        void SetToken(string token);
        Task<ServiceResponse<AuthToken>> ExchangeToken(string state, string code);
    }

    public class CommonDataService : ICommonDataService
    {
        private HmrcSettings _hmrcSettings;
        private string _token { get; set; }
        public CommonDataService(IOptions<HmrcSettings> hmrcSettings)
        {
            _hmrcSettings = hmrcSettings.Value;
        }


        public async Task<ServiceResponse<T>> CallApiAsync<T>(string query, string content, HttpRequestType httpRequestType)
        {
            var response = new ServiceResponse<T>();
            //TODO GET TOKEN

            var url = _hmrcSettings.BaseUrl + query;
            var httpContent = new StringContent(content, Encoding.UTF8, "application/text");
            var accept = "application/vnd.hmrc.1.0+json";
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

        public void SetToken(string token)
        {
            //TODO probably change how this is done.
            _token = token;
        }

        public async Task<ServiceResponse<AuthToken>> ExchangeToken(string state, string code)
        {
            var response = new ServiceResponse();

            var tokenRequestParameters = new Dictionary<string, string>()
            {
                {"client_id", _hmrcSettings.ClientId},
                {"redirect_uri", _hmrcSettings.CallbackUrl},
                {"client_secret", _hmrcSettings.ClientSecret},
                {"code", code},
                {"grant_type", "authorization_code"},
            };
            return await CallAuthApi(Guid.Parse(state),  tokenRequestParameters);
        }

        public async Task<ServiceResponse<AuthToken>> CallAuthApi(Guid id,  Dictionary<string, string> submissionModel)
        {
            var response = new ServiceResponse<AuthToken>() { Data = new AuthToken() };

            var url = _hmrcSettings.BaseUrl + _hmrcSettings.TokenUrl;

            var requestContent = new FormUrlEncodedContent(submissionModel);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Content = requestContent;

            using (var client = new HttpClient())
            {
                client.MaxResponseContentBufferSize = 1024 * 1024 * 10;
                client.DefaultRequestHeaders.Connection.Add("keep-alive");
                var clientResponse = await client.SendAsync(requestMessage);
                if (clientResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseObj = await clientResponse.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseExchangeToken>(responseObj);

                    var authToken = new AuthToken();
                    
                    authToken.IndividualId = id;
                    authToken.AccessToken = result.access_token;
                    authToken.RefreshToken = result.refresh_token;
                    authToken.TokenExpiration = DateTime.UtcNow.AddSeconds(result.expires_in);
                    authToken.RefreshTokenExpiration = DateTime.UtcNow.AddSeconds(result.x_refresh_token_expires_in);

                    response.Data = authToken;
                    
                }
                else
                {
                    response.AddError("HMRC", "There was an issue with connecting to HMRC");
                }
            }


            return response;
        }
    }
}
