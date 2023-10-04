using DataModuleInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;

namespace DataModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataAcquisitionController : ControllerBase
    {
        private readonly ITwelveDataService _dataService;
        private readonly ILogger<DataAcquisitionController> _logger;

        public DataAcquisitionController(ILogger<DataAcquisitionController> logger, ITwelveDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet("HistoricalData")]
        public async Task<ActionResult<HistoricalDataDto>> GetHistoricalData(string currency, string interval)
        {
            _logger.LogInformation("Getting historical data for {currency} with interval {interval}", currency, interval);
            return Ok(await _dataService.DataSeries(currency, interval));
        }
    }
}