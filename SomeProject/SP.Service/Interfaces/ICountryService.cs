using SP.Service.DTOs.Country;
using System.Collections.Generic;

namespace SP.Service.Interfaces
{
    public interface ICountryService
    {
        long Create(CountryDto country);
        void Update(CountryDto country);
        void Delete(long id);
        IEnumerable<CountryDto> GetAll();
        CountryDto GetById(long id);
    }
}
