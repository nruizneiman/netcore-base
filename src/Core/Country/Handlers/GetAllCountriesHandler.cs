using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(IRepository<Domain.Entities.Country> countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                _mapper.Map<IEnumerable<CountryDto>>(_countryRepository.Get()
                .OrderBy(x => x.Name)
                .ToList()));
        }
    }
}
