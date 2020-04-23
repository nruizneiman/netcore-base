using NUnit.Framework;
using SP.Domain.Base.IRepository;
using SP.Domain.Entities;
using System.Linq;

namespace SP.Infrastructure.Tests
{
    public class Tests
    {
        private readonly IRepository<Country> _countryRepository;

        public Tests(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InsertNewCountry()
        {
            try
            {
                _countryRepository.Create(new Country
                {
                    Name = "Argentina",
                    ShortName = "ARG",
                    CurrencyCode = "087",
                    Flag = null
                });

                Assert.Pass();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        [Test]
        public void GetCountries()
        {
            var countries = _countryRepository.GetAll().Result;

            Assert.GreaterOrEqual(1, countries.Count());
        }
    }
}