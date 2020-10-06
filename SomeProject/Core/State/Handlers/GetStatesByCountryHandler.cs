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

        public GetStatesByCountryHandler(IRepository<Domain.Entities.State> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<IEnumerable<StateDto>> Handle(GetStatesByCountryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                _stateRepository.Get().Where(x => x.Country.Id == request.CountryId)
                .Select(x => new StateDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).OrderBy(x => x.Name)
                .ToList()
            );
        }
    }
}
