using Bogus;
using FluentAssertions;
using Moq;
using NLW_Auction.API.Communication.Requests;
using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;
using NLW_Auction.API.Services;
using NLW_Auction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Fact]
    public void Success()
    {
        // ARRANGE
        var requestData = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(50, 800)).Generate();

        var offerRepositoryMock = new Mock<IOfferRepository>();
        var loggedUserMock = new Mock<ILoggedUser>();

        loggedUserMock.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUserMock.Object, offerRepositoryMock.Object);

        // ACT
        var act = () => useCase.Execute(0, requestData);

        // ASSERT
        act.Should().NotThrow();
    }
}
