using DataModuleInfrastructure.Models;
using DataModuleInfrastructure.Services;
using Mapster;
using Microsoft.Extensions.Options;
using PredictionBot_DataManagement_Domain.Dtos;
using PredictionBot_DataManagement_Domain.Models;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;
using PredictionBot_DataManagement_Infrastructure.Services;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace TwelveDataServices
{
    public class TwelveDataService : ITwelveDataService
    {
        private readonly IHistoricalDataService _historicalDataService;
        private readonly HttpClient _httpClient;
        private readonly TwelveDataConnection _twelveDataOptions;

        public TwelveDataService(IHistoricalDataService historicalDataService, IHttpClientFactory httpClient, IOptions<TwelveDataConnection> twelveDataOptions)
        {
            _httpClient = httpClient.CreateClient("GetData");
            _twelveDataOptions = twelveDataOptions.Value;
            _historicalDataService = historicalDataService;
        }

        public async Task<HistoricalDataDto> DataSeries(string currency, string interval)
        {
            string url = $"{_twelveDataOptions.Url}time_series?symbol={currency}&interval={interval}&apikey={_twelveDataOptions.Token}&outputsize=100";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to retrieve exchange rate data from Twelve Data. StatusCode={response.StatusCode}");
                }

                var historicalData = await response.Content.ReadFromJsonAsync<HistoricalDataDto>();

                if (historicalData == null || historicalData.Status != "ok")
                {
                    throw new Exception("Failed to retrieve exchange rate data from Twelve Data. No data returned.");
                }

                _historicalDataService.CreateHistoricalData(historicalData);

                return historicalData;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to retrieve exchange rate data from Twelve Data", ex);
            }
        }
    }
}