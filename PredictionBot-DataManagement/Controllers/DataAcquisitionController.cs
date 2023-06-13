using DataModuleInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using PredictionBot_DataManagement_Domain.Dtos;

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
        public async Task<HistoricalDataDto> GetHistoricalData(string currency, string interval)
        {
            return await _dataService.DataSeries(currency, interval);
        }
    }
}