using NLW_Auction.API.Communication.Requests;
using NLW_Auction.API.Contracts;
using NLW_Auction.API.Entities;
using NLW_Auction.API.Repositories;
using NLW_Auction.API.Services;

namespace NLW_Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var loggedUser = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = loggedUser.Id,
        };

        _repository.CreateOffer(offer);

        return offer.Id;
    }
}
