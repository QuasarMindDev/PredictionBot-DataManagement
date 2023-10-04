using DataModuleInfrastructure.Services;
using Microsoft.Extensions.Options;
using PredictionBot_DataManagement_Domain.Commons;
using PredictionBot_DataManagement_Infrastructure.Models.Configuration;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Services;
using System.Net.Http.Json;

namespace TwelveDataServices
{
    public class TwelveDataService : ITwelveDataService
    {
        private readonly IHistoricalDataService _historicalDataService;
        private readonly HttpClient _httpClient;
        private readonly TwelveDataConnection _twelveDataOptions;

        public TwelveDataService(IHistoricalDataService historicalDataService, IHttpClientFactory httpClient, IOptions<TwelveDataConnection> twelveDataOptions)
        {
            _httpClient = httpClient.CreateClient(Constant.GetDataHttpClientName);
            _twelveDataOptions = twelveDataOptions.Value;
            _historicalDataService = historicalDataService;
        }

        public async Task<HistoricalDataDto> DataSeries(string currency, string interval)
        {
            string url = $"{_twelveDataOptions.Url}time_series?symbol={currency}&interval={interval}&apikey={_twelveDataOptions.Token}&outputsize=100";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrieve exchange rate data from Twelve Data. StatusCode={response.StatusCode}");
            }

            var historicalData = await response.Content.ReadFromJsonAsync<HistoricalDataDto>();

            if (historicalData == null || historicalData.Status != "ok")
            {
                throw new HttpRequestException("Failed to retrieve exchange rate data from Twelve Data. No data returned.");
            }

            _historicalDataService.CreateHistoricalData(historicalData);

            return historicalData;
        }
    }
}