using Bogus;
using FluentAssertions;
using Moq;
using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;
using NLW_Auction.API.Enums;
using NLW_Auction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        // AAA:
        // 1 - ARRANGE (Initialize everything we need for the test)
        // 2 - ACT  (Action)
        // 3 - ASSERT (Check if the result is what we were expecting)

        // ARRANGE
        var auctionData = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 10))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 100),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id,
                }
            }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetAuction()).Returns(new Auction());

        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        // ACT
        var auction = useCase.Execute();

        // ASSERT
        auction.Should().NotBeNull();
    }
}
