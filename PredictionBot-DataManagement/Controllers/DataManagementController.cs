using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Services;

namespace PredictionBot_DataManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataManagementController : ControllerBase
    {
        private readonly ILogger<DataManagementController> _logger;
        private readonly IHistoricalDataService _historicalDataRepository;
        private readonly IValidator<HistoricalDataRequestDto> _validator;

        public DataManagementController(ILogger<DataManagementController> logger, IHistoricalDataService historicalDataRepository, IValidator<HistoricalDataRequestDto> validator)
        {
            _logger = logger;
            _historicalDataRepository = historicalDataRepository;
            _validator = validator;
        }

        [HttpPost("DatabaseHistoricalData")]
        public async Task<ActionResult<HistoricalDataDatabaseDto>> GetHistoricalDataFromDatabase(HistoricalDataRequestDto metadata)
        {
            _logger.LogInformation("Getting historical data from database");
            await _validator.ValidateAsync(metadata);
            return Ok(await _historicalDataRepository.GetHistoricalData(metadata));
        }
    }
}