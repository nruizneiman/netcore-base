using AutoMapper;
using Core.State.DTOs;
using Core.State.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.State.Handlers
{
    public class GetStatesByCountryHandler : IRequestHandler<GetStatesByCountryQuery, IEnumerable<StateDto>>
    {
        private readonly IRepository<Domain.Entities.State> _stateRepository;
        private readonly IMapper _mapper;

        public GetStatesByCountryHandler(IRepository<Domain.Entities.State> stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StateDto>> Handle(GetStatesByCountryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<StateDto>>(_stateRepository.Get()
                .Where(x => x.Country.Id == request.CountryId)
                .OrderBy(x => x.Name)
                .ToList())
            );
        }
    }
}
