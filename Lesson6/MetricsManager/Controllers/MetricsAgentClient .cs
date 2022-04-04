using MetricsManager.Responses;
using MetricsManager.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.ServiceModel;



namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public MetricsAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public AllHddMetricsResponse GetAllHddMetrics(GetAllHddMetricsRequest
        request)
        {
            var fromParameter = request.FromTime.TotalSeconds;
            var toParameter = request.ToTime.TotalSeconds;
            var httpRequest = new HttpRequestMessage    (HttpMethod.Get,
            $"{request.ClientBaseAddress}/api/hddmetrics/from/{fromParameter}/to/{toParameter}");

            try
            {
                HttpResponseMessage response =
                _httpClient.SendAsync(httpRequest).Result;
                using var responseStream =
                response.Content.ReadAsStreamAsync().Result;
                return
                JsonSerializer.DeserializeAsync<AllHddMetricsResponse>(responseStream).Result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public AllRamMetricsResponse GetAllRamMetrics(GetAllRamMetricsRequest request)
        {
            var fromParameter = request.FromTime.TotalSeconds;
            var toParameter = request.ToTime.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
            $"{request.ClientBaseAddress}/api/rammetrics/from/{fromParameter}/to/{toParameter}");

            try
            {
                HttpResponseMessage response =
                _httpClient.SendAsync(httpRequest).Result;
                using var responseStream =
                response.Content.ReadAsStreamAsync().Result;
                return
                JsonSerializer.DeserializeAsync<AllRamMetricsResponse>(responseStream).Result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public AllCpuMetricsResponse GetCpuMetrics(GetAllCpuMetricsRequest request)
        {
            var fromParameter = request.FromTime.TotalSeconds;
            var toParameter = request.ToTime.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
            $"{request.ClientBaseAddress}/api/cpumetrics/from/{fromParameter}/to/{toParameter}");

            try
            {
                HttpResponseMessage response =
                _httpClient.SendAsync(httpRequest).Result;
                using var responseStream =
                response.Content.ReadAsStreamAsync().Result;
                return
                JsonSerializer.DeserializeAsync<AllCpuMetricsResponse>(responseStream).Result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public AllDotNetMetricsResponse GetDonNetMetrics(DonNetMetricsRequest request)
        {
            var fromParameter = request.FromTime.TotalSeconds;
            var toParameter = request.ToTime.TotalSeconds;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
            $"{request.ClientBaseAddress}/api/dotnetmetrics/from/{fromParameter}/to/{toParameter}");

            try
            {
                HttpResponseMessage response =
                _httpClient.SendAsync(httpRequest).Result;
                using var responseStream =
                response.Content.ReadAsStreamAsync().Result;
                return
                JsonSerializer.DeserializeAsync<AllDotNetMetricsResponse>(responseStream).Result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
    // остальные методы реализовать самим
}
