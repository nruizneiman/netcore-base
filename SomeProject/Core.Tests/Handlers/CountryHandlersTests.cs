using AutoMapper;
using Core.Country.Handlers;
using Core.Country.Queries;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests.Handlers
{
    public class CountryHandlersTests
    {
        private readonly Mock<IRepository<Domain.Entities.Country>> _countryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public CountryHandlersTests()
        {
            _countryRepositoryMock = new Mock<IRepository<Domain.Entities.Country>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllShouldBeExecutedAsync()
        {
            var handler = new GetAllCountriesHandler(_countryRepositoryMock.Object, _mapperMock.Object);
            var request = new GetAllCountriesQuery();

            var countries = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(countries);
            _countryRepositoryMock.Verify(x => x.Get(), Times.Once);
        }
    }
}
