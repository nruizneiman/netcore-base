using Core.Country.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Core.Country.Queries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
    {
    }
}
