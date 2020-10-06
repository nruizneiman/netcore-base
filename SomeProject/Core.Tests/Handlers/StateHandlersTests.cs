﻿using Core.State.Handlers;
using Core.State.Queries;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests.Handlers
{
    public class StateHandlersTests
    {
        private readonly Mock<IRepository<Domain.Entities.State>> _stateRepositoryMock;

        public StateHandlersTests()
        {
            _stateRepositoryMock = new Mock<IRepository<Domain.Entities.State>>();
        }

        [Fact]
        public async Task GetAllShouldBeExecutedAsync()
        {
            const int countryId = 5;

            var handler = new GetStatesByCountryHandler(_stateRepositoryMock.Object);
            var request = new GetStatesByCountryQuery(countryId);

            var states = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(states);
            _stateRepositoryMock.Verify(x => x.Get(), Times.Once);
        }
    }
}
