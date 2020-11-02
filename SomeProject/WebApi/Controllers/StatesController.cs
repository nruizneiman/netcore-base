using Core.State.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> GetStatesByCountryAsync([FromQuery]int countryId)
        {
            if(countryId == 0)
            {
                return BadRequest();
            }

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
