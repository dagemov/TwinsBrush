﻿using Newtonsoft.Json;
using System.Collections.Generic;
using Twins.Shared.Responses;

namespace Twins.Api.Services
{
    public class ApiService : IApiService
    {
        private readonly string _urlBase;
        private readonly string _tokenName;
        private readonly string _tokenValue;

        public ApiService(IConfiguration configuration)
        {
            _urlBase = configuration["CountriesAPI:urlBase"]!;
            _tokenName = configuration["CountriesAPI:tokenName"]!;
            _tokenValue = configuration["CountriesAPI:tokenValue"]!;
        }
        public async Task<Response> GetAsync<T>(string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new()
                {
                    BaseAddress = new Uri(_urlBase),
                };
                //rember urlBase api.url
                client.DefaultRequestHeaders.Add(_tokenName, _tokenValue);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                var responseData = JsonConvert.DeserializeObject(result)!;
                return new Response
                {
                    IsSuccess = true,
                    Result = responseData
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response> GetListAsync<T>(string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new()
                {
                    BaseAddress = new Uri(_urlBase),
                };
                //rember urlBase api.url
                client.DefaultRequestHeaders.Add(_tokenName, _tokenValue);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result)!;
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

    }
}
