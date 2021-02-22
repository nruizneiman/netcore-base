using Core;
using Core.Country.DTOs;
using Core.Country.Queries;
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
    public class CountriesController : ControllerBase
    {
        private readonly IFileBuilder<CountryDto> _fileBuilder;
        private readonly IMediator _mediator;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ILogger<CountriesController> logger, IMediator mediator, IFileBuilder<CountryDto> fileBuilder)
        {
            _logger = logger;
            _mediator = mediator;
            _fileBuilder = fileBuilder;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllCountriesQuery()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet("csv")]
        public async Task<IActionResult> GetCountriesAsCsvAsync()
        {
            try
            {
                var countries = await _mediator.Send(new GetAllCountriesQuery());

                return File(_fileBuilder.ToCsv(countries), "application/CSV", "Countries.csv");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GetCountriesAsPdfAsync()
        {
            try
            {
                var countries = await _mediator.Send(new GetAllCountriesQuery());

                return File(_fileBuilder.ToPdf(countries), "application/PDF", "Countries.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
