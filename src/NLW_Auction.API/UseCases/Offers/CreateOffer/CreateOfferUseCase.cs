using NLW_Auction.API.Communication.Requests;
using NLW_Auction.API.Entities;
using NLW_Auction.API.Repositories;
using NLW_Auction.API.Services;

namespace NLW_Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new NLW_AuctionDbContext();

        var loggedUser = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = loggedUser.Id,
        };

        repository.Offers.Add(offer);

        repository.SaveChanges();

        return offer.Id;
    }
}
