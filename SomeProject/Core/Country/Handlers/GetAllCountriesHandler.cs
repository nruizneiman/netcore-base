using Core.Country.DTOs;
using Core.Country.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Country.Handlers
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly IRepository<Domain.Entities.Country> _countryRepository;

        public GetAllCountriesHandler(IRepository<Domain.Entities.Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                _countryRepository.Get().Select(x => new CountryDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .OrderBy(x => x.Name)
                .ToList()
                );
        }
    }
}
