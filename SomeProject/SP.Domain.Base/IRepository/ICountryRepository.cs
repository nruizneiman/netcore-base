using SP.Domain.Entities;
using System.Collections.Generic;

namespace SP.Domain.IRepository
{
    public interface ICountryRepository
    {
        long Create(Country country);
        void Delete(long id);
        IEnumerable<Country> GetAll();
        Country GetById(long id);
        void Update(Country country);
    }
}
