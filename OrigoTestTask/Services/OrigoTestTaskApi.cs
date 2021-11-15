using Microsoft.Extensions.Configuration;
using OrigoTestTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrigoTestTask.Services
{
    public interface IOrigoTestTaskApi
    {
        Task<CustomerSearchResponse> GetAll();
        Task<CreateCustomerResponse> Create(CreateCustomerRequest request);
    }
    public class OrigoTestTaskApi : IOrigoTestTaskApi
    {
        private static string _originTestTaskApiUrl;
        private readonly HttpClient _httpClient;
        public OrigoTestTaskApi(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _originTestTaskApiUrl = config.GetSection("Services")["apiURL"];


        }
        public async Task<CustomerSearchResponse> GetAll() {

            try
            {

                var response = await _httpClient.GetAsync(new Uri($"{_originTestTaskApiUrl}/Customers")).ConfigureAwait(false);
                CustomerSearchResponse result = new CustomerSearchResponse();
                if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    result = await JsonSerializer.DeserializeAsync
                        <CustomerSearchResponse>(responseStream, options);
                   
                }
                else
                {
                    result.ErrorMessages = new List<string> { "Error while processing request...." };
                }
                return result;
            }
            catch
            (Exception)
            {
                CustomerSearchResponse result = new CustomerSearchResponse();
                result.ErrorMessages = new List<string> { "Error while processing request...." };
                return result;

            }
        }
        public async Task<CreateCustomerResponse> Create(CreateCustomerRequest request)
        {

            try
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var response = await _httpClient.PostAsJsonAsync(new Uri($"{_originTestTaskApiUrl}/Customers"), request, options).ConfigureAwait(false);
                CreateCustomerResponse result = new CreateCustomerResponse();

                if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    result = await JsonSerializer.DeserializeAsync
                        <CreateCustomerResponse>(responseStream, options);


                }
                else
                {
                    result.ErrorMessages = new List<string> { "Error while processing request...." };
                }
                return result;
            }
            catch
            (Exception ex)
            {
                CreateCustomerResponse result = new CreateCustomerResponse();
                result.ErrorMessages = new List<string> { "Error while processing request...." };
                return result;

            }
        }
    }
}
