using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using HmrcDotNet.Auth;
using HmrcDotNet.Helpers;
using HmrcDotNet.Model.Generic;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HmrcDotNet.Service
{
    public interface IHmrcCommonDataService
    {
        Task<ServiceResponse<T>> CallApiAsync<T,TL>(string query,string token, TL content, HttpRequestType httpRequestType);
       
        Task<ServiceResponse<T>> CallApiAsync<T>(string query, string token, string content, HttpRequestType httpRequestType);
        Task<ServiceResponse<T>> CallApiAsync<T>(string query, string token, HttpRequestType httpRequestType);
        Task<ServiceResponse<AuthToken>> ExchangeToken(string state, string code);
        Task<ServiceResponse<AuthToken>> CallAuthApi(string id, Dictionary<string, string> submissionModel);
    }

    public class HmrcCommonDataService : IHmrcCommonDataService
    {
        private HmrcSettings _hmrcSettings;

        public HmrcCommonDataService(IOptions<HmrcSettings> hmrcSettings)
        {
            _hmrcSettings = hmrcSettings.Value;
        }


        

        public async Task<ServiceResponse<T>> CallApiAsync<T, TL>(string query, string token, TL content, HttpRequestType httpRequestType)
        {
            return await CallApiAsync<T>(query, token, JsonConvert.SerializeObject(content), httpRequestType);
        }

        public async Task<ServiceResponse<T>> CallApiAsync<T>(string query, string token, string content, HttpRequestType httpRequestType)
        {
            var response = new ServiceResponse<T>();
            var url = _hmrcSettings.BaseUrl + query;
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var accept = "application/vnd.hmrc.1.0+json";
            var client = url.WithHeaders(new
            {
                Accept = accept,
            });
            client.WithOAuthBearerToken(token);
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
                    response.Location = objectResponse1.Headers.Location.AbsoluteUri;
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
                {
                    response.AddError("Error", "Failed with response code " + ex.Call.Response.StatusCode);
                    if (ex.Call.ErrorResponseBody != null)
                    {
                        var errorResponse = JsonConvert.DeserializeObject<ErrorResponseModel>(ex.Call.ErrorResponseBody);
                        var i = 0;
                        foreach (var errorResponseError in errorResponse.errors)
                        {
                            response.AddError(errorResponseError.code + i,errorResponseError.message + " - " + errorResponseError.path);
                            i++;
                        }
                    }
                   
                }
                else
                    response.AddError("Error", ex.Message);
            }
            catch (Exception ex)
            {
                response.AddError("Error", ex.Message);
            }
            return response;

        }

        public async Task<ServiceResponse<T>> CallApiAsync<T>(string query, string token, HttpRequestType httpRequestType)
        {
            return await CallApiAsync<T>(query, token, "", httpRequestType);
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
            return await CallAuthApi(state, tokenRequestParameters);
        }




        public async Task<ServiceResponse<AuthToken>> CallAuthApi(string id, Dictionary<string, string> submissionModel)
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

                    authToken.EntityId = id;
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