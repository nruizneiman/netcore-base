using Core.State.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Core.State.Queries
{
    public class GetStatesByCountryQuery : IRequest<IEnumerable<StateDto>>
    {
        public GetStatesByCountryQuery(int countryId)
        {
            CountryId = countryId;
        }

        public int CountryId { get; private set; }
    }
}
