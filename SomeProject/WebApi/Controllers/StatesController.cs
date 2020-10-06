using Core.State.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StatesController> _logger;

        public StatesController(ILogger<StatesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetStatesByCountryAsync([FromQuery]int countryId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetStatesByCountryQuery(countryId)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
