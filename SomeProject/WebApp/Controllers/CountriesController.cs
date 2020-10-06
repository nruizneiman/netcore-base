using Core.Country.Queries;
using Core.State.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Authorize]
    public class CountriesController : Controller
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly IMediator _mediator;

        public CountriesController(ILogger<CountriesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCountriesQuery()));
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var states = await _mediator.Send(new GetStatesByCountryQuery(id));

            if (states == null)
            {
                return NotFound();
            }

            return View(states);
        }
    }
}
